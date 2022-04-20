using BenchmarkDotNet.Attributes;
using LanguageExt;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LanguageExt.Prelude;

namespace FP_Playground;

public class WithFpLanguageExt
{
    public Result<SampleClass> DoSomethingWithId(Guid id)
    {
        return ValidateId(id)
            .Bind(FetchEntityById)
            .Bind(DoSomethingWithEntity)
            .Match(
                Succ: Result<SampleClass>.Success,
                Fail: errors => Result<SampleClass>.Error(errors.First())
            );
    }

    private Validation<string, SampleClass> DoSomethingWithEntity(SampleClass model)
    {
        return DoSubRoutine(model);
    }

    private Validation<string, SampleClass> DoSubRoutine(SampleClass model)
    {
        return DoSubSubRoutine1(model)
            .Bind(DoSubSubRoutine2);
    }

    private Validation<string, SampleClass> DoSubSubRoutine1(SampleClass model)
    {
        // do something here
        return model;
    }

    private Validation<string, SampleClass> DoSubSubRoutine2(SampleClass model)
    {
        return DoSubSubSubRoutine(model).Bind((result) =>
        {
            if (!string.IsNullOrEmpty(result.Name)) return result;
            return Fail<string, SampleClass>("Does not have a name!");

        });
    }

    private Validation<string, SampleClass> DoSubSubSubRoutine(SampleClass model)
    {
        var returnVal = new SampleClass();
        if (model.Id == Guid.Parse("11111111-1111-1111-1111-111111111111"))
        {
            returnVal.Name = "The One!";
        }

        return returnVal;
    }

    private Validation<string, SampleClass> FetchEntityById(Guid id)
    {
        return new SampleClass {Id = id};
    }

    private Validation<string, Guid> ValidateId(Guid id)
    {
        if (id == Guid.Empty)
        {
            return Fail<string, Guid>("Must provide a valid Guid Id!");
        }

        return id;
    }
}

[TestClass]
[MemoryDiagnoser]
public class WithFpLanguageExtTests
{
    [TestMethod]
    [Benchmark]
    public void DoSomethingWithId_EmptyGuid_ReturnsErrorMessage()
    {
        var res = new WithFpLanguageExt().DoSomethingWithId(Guid.Empty);
        Assert.IsFalse(res.WasSuccessful);
        Assert.AreEqual("Must provide a valid Guid Id!", res.Message);
    }

    [TestMethod]
    [Benchmark]
    public void DoSomethingWithId_RandomGuid_ReturnsErrorMessage()
    {
        var res = new WithFpLanguageExt().DoSomethingWithId(Guid.NewGuid());
        Assert.IsFalse(res.WasSuccessful);
        Assert.AreEqual("Does not have a name!", res.Message);
    }

    [TestMethod]
    [Benchmark]
    public void DoSomethingWithId_TheOne_ReturnsSuccessful()
    {
        var res = new WithFpLanguageExt().DoSomethingWithId(Guid.Parse("11111111-1111-1111-1111-111111111111"));
        Assert.IsTrue(res.WasSuccessful);
        Assert.AreEqual("The One!", res.Model.Name);
    }
}