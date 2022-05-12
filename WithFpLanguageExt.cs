using BenchmarkDotNet.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FP_Playground.Either;
using static FP_Playground.Either.EitherExtensions;

namespace FP_Playground;

public class WithFpLanguageExt
{
    public Result<SampleClass> DoSomethingWithId(Guid id)
    {
        return ValidateId(id)
            .Bind(FetchEntityById)
            .Bind(DoSomethingWithEntity)
            .Match(
                Result<SampleClass>.Success,
                Result<SampleClass>.Error
            );
    }

    private Either<string, SampleClass> DoSomethingWithEntity(SampleClass model)
    {
        return DoSubRoutine(model);
    }

    private Either<string, SampleClass> DoSubRoutine(SampleClass model)
    {
        return DoSubSubRoutine1(model)
            .Bind(DoSubSubRoutine2);
    }

    private Either<string, SampleClass> DoSubSubRoutine1(SampleClass model)
    {
        // do something here
        return model;
    }

    private Either<string, SampleClass> DoSubSubRoutine2(SampleClass model)
    {
        return DoSubSubSubRoutine(model).Bind((result) =>
        {
            if (!string.IsNullOrEmpty(result.Name)) return result;
            return Left<string, SampleClass>("Does not have a name!");

        });
    }

    private Either<string, SampleClass> DoSubSubSubRoutine(SampleClass model)
    {
        var returnVal = new SampleClass();
        if (model.Id == Guid.Parse("11111111-1111-1111-1111-111111111111"))
        {
            returnVal.Name = "The One!";
        }

        return returnVal;
    }

    private Either<string, SampleClass> FetchEntityById(Guid id)
    {
        return new SampleClass {Id = id};
    }

    private Either<string, Guid> ValidateId(Guid id)
    {
        if (id == Guid.Empty)
        {
            return Left<string, Guid>("Must provide a valid Guid Id!");
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