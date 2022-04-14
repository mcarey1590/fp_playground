namespace FP_Playground;

public class Original
{
    public Result<object> DoSomethingWithId(Guid id)
    {
        var validatedIdResult = ValidateId(id);
        if (!validatedIdResult.WasSuccessful)
        {
            return Result<object>.Error("validatedIdResult error");
        }

        var fetchEntityResult = FetchEntityById(id);
        var doSomethingResult = DoSomethingWithEntity(fetchEntityResult.Model);

        if (!doSomethingResult.WasSuccessful)
        {
            return Result<object>.Error("doSomethingResult error");
        }

        return Result<object>.Success(new object());
    }

    private Result<object> DoSomethingWithEntity(object model)
    {
        var subRoutineResult = DoSubRoutine(model);
        if (!subRoutineResult.WasSuccessful)
        {
            return Result<object>.Error("subRoutineResult error");
        }

        return Result<object>.Success(new object());
    }

    private Result<object> DoSubRoutine(object model)
    {
        var subSubRoutine1Result = DoSubSubRoutine1(model);

        if (!subSubRoutine1Result.WasSuccessful)
        {
            return Result<object>.Error("DoSubSubRoutine1 error");
        }
        var subSubRoutine2Result = DoSubSubRoutine2(model);

        if (!subSubRoutine2Result.WasSuccessful)
        {
            return Result<object>.Error("subSubRoutine2Result error");
        }

        return Result<object>.Success(new object());
    }

    private Result<object> DoSubSubRoutine1(object model)
    {
        return Result<object>.Success(new object());
    }

    private Result<object> DoSubSubRoutine2(object model)
    {
        var subSubSubRoutineResult = DoSubSubSubRoutine(model);

        if (!subSubSubRoutineResult.WasSuccessful)
        {
            return Result<object>.Error("subSubSubRoutineResult error");
        }
        return Result<object>.Success(new object());
    }

    private Result<object> DoSubSubSubRoutine(object model)
    {
        return Result<object>.Success(new object());
    }

    private Result<object> FetchEntityById(Guid id)
    {
        return Result<object>.Success(new object());
    }

    private Result<object> ValidateId(Guid id)
    {
        return Result<object>.Success(new object());
    }
}