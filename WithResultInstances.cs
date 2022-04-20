using BenchmarkDotNet.Attributes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FP_Playground;

public class WithResultInstances
{
    public Result<SampleClass> DoSomethingWithId(Guid id)
    {
        var validatedIdResult = ValidateId(id);
        if (!validatedIdResult.WasSuccessful)
        {
            return Result<SampleClass>.Error(validatedIdResult.Message);
        }

        var fetchEntityResult = FetchEntityById(validatedIdResult.Model);

        if (!fetchEntityResult.WasSuccessful)
        {
            return fetchEntityResult;
        }

        var doSomethingResult = DoSomethingWithEntity(fetchEntityResult.Model);

        if (!doSomethingResult.WasSuccessful)
        {
            return doSomethingResult;
        }

        return doSomethingResult;
    }

    private Result<SampleClass> DoSomethingWithEntity(SampleClass model)
    {
        var subRoutineResult = DoSubRoutine(model);
        if (!subRoutineResult.WasSuccessful)
        {
            return subRoutineResult;
        }

        return Result<SampleClass>.Success(subRoutineResult.Model);
    }

    private Result<SampleClass> DoSubRoutine(SampleClass model)
    {
        var subSubRoutine1Result = DoSubSubRoutine1(model);

        if (!subSubRoutine1Result.WasSuccessful)
        {
            return subSubRoutine1Result;
        }

        var subSubRoutine2Result = DoSubSubRoutine2(model);

        if (!subSubRoutine2Result.WasSuccessful)
        {
            return subSubRoutine2Result;
        }

        return Result<SampleClass>.Success(subSubRoutine2Result.Model);
    }

    private Result<SampleClass> DoSubSubRoutine1(SampleClass model)
    {
        return Result<SampleClass>.Success(model);
    }

    private Result<SampleClass> DoSubSubRoutine2(SampleClass model)
    {
        var result = DoSubSubSubRoutine(model);

        if (!result.WasSuccessful)
        {
            return result;
        }

        if (string.IsNullOrEmpty(result.Model.Name))
        {
            return Result<SampleClass>.Error("Does not have a name!");
        }

        return result;
    }

    private Result<SampleClass> DoSubSubSubRoutine(SampleClass model)
    {
        var returnVal = new SampleClass { Id = model.Id };
        if (model.Id == Guid.Parse("11111111-1111-1111-1111-111111111111"))
        {
            returnVal.Name = "The One!";
        }

        return Result<SampleClass>.Success(returnVal);
    }

    private Result<SampleClass> FetchEntityById(Guid id)
    {
        return Result<SampleClass>.Success(new SampleClass {Id = id});
    }

    private Result<Guid> ValidateId(Guid id)
    {
        if (id == Guid.Empty)
        {
            return Result<Guid>.Error("Must provide a valid Guid Id!");
        }

        return Result<Guid>.Success(id);
    }
}

[TestClass]
public class WithResultInstancesTests
{
    [TestMethod]
    [Benchmark]
    public void DoSomethingWithId_EmptyGuid_ReturnsErrorMessage()
    {
        var res = new WithResultInstances().DoSomethingWithId(Guid.Empty);
        Assert.IsFalse(res.WasSuccessful);
        Assert.AreEqual("Must provide a valid Guid Id!", res.Message);
    }

    [TestMethod]
    [Benchmark]
    public void DoSomethingWithId_RandomGuid_ReturnsErrorMessage()
    {
        var res = new WithResultInstances().DoSomethingWithId(Guid.NewGuid());
        Assert.IsFalse(res.WasSuccessful);
        Assert.AreEqual("Does not have a name!", res.Message);
    }

    [TestMethod]
    [Benchmark]
    public void DoSomethingWithId_TheOne_ReturnsSuccessful()
    {
        var res = new WithResultInstances().DoSomethingWithId(Guid.Parse("11111111-1111-1111-1111-111111111111"));
        Assert.IsTrue(res.WasSuccessful);
        Assert.AreEqual("The One!", res.Model.Name);
    }
}