using BenchmarkDotNet.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FP_Playground;

public class WithLocalException
{
    public Result<SampleClass> DoSomethingWithId(Guid id)
    {
        try
        {
            var result = id
                .AndThen(ValidateId)
                .AndThen(FetchEntityById)
                .AndThen(DoSomethingWithEntity);
            return Result<SampleClass>.Success(result);
        }
        catch (PlatformServiceException e)
        {
            return Result<SampleClass>.Error(e.Message);
        }
    }

    private SampleClass DoSomethingWithEntity(SampleClass model)
    {
        return DoSubRoutine(model);
    }

    private SampleClass DoSubRoutine(SampleClass model)
    {
        return DoSubSubRoutine1(model)
            .AndThen(DoSubSubRoutine2);
    }

    private SampleClass DoSubSubRoutine1(SampleClass model)
    {
        return model;
    }

    private SampleClass DoSubSubRoutine2(SampleClass model)
    {
        var result = DoSubSubSubRoutine(model);

        if (string.IsNullOrEmpty(result.Name))
        {
            throw new PlatformServiceException("Does not have a name!");
        }

        return result;
    }

    private SampleClass DoSubSubSubRoutine(SampleClass model)
    {
        var returnVal = new SampleClass();
        if (model.Id == Guid.Parse("11111111-1111-1111-1111-111111111111"))
        {
            returnVal.Name = "The One!";
        }

        return returnVal;
    }

    private SampleClass FetchEntityById(Guid id)
    {
        return new SampleClass {Id = id};
    }

    private Guid ValidateId(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new PlatformServiceException("Must provide a valid Guid Id!");
        }

        return id;
    }
}

[TestClass]
public class WithLocalExceptionTests
{
    [TestMethod]
    [Benchmark]
    public void DoSomethingWithId_EmptyGuid_ReturnsErrorMessage()
    {
        var res = new WithLocalException().DoSomethingWithId(Guid.Empty);
        Assert.IsFalse(res.WasSuccessful);
        Assert.AreEqual("Must provide a valid Guid Id!", res.Message);
    }

    [TestMethod]
    [Benchmark]
    public void DoSomethingWithId_RandomGuid_ReturnsErrorMessage()
    {
        var res = new WithLocalException().DoSomethingWithId(Guid.NewGuid());
        Assert.IsFalse(res.WasSuccessful);
        Assert.AreEqual("Does not have a name!", res.Message);
    }

    [TestMethod]
    [Benchmark]
    public void DoSomethingWithId_TheOne_ReturnsSuccessful()
    {
        var res = new WithLocalException().DoSomethingWithId(Guid.Parse("11111111-1111-1111-1111-111111111111"));
        Assert.IsTrue(res.WasSuccessful);
        Assert.AreEqual("The One!", res.Model.Name);
    }
}