using FP_Playground;

public class ExampleClass
{
    public Result<object> DoSomethingWithId(Guid id)
    {
        try
        {
            var result = id
                .AndThen(ValidateId)
                .AndThen(FetchEntityById)
                .AndThen(DoSomethingWithEntity);
            return Result<object>.Success(result);
        }
        catch (PlatformServiceException e)
        {
            return Result<object>.Error(e.Message);
        }
    }

    private object DoSomethingWithEntity(object model)
    {
        return DoSubRoutine(model);
    }

    private object DoSubRoutine(object model)
    {
        return DoSubSubRoutine1(model)
            .AndThen(DoSubSubRoutine2);
    }

    private object DoSubSubRoutine1(object model)
    {
        return new object();
    }

    private object DoSubSubRoutine2(object model)
    {
        var subSubSubRoutineResult = DoSubSubSubRoutine(model);

        var someCondition = false;
        if (!someCondition)
        {
            throw new PlatformServiceException("DoSubSubRoutine2 error");
        }

        return new object();
    }

    private object DoSubSubSubRoutine(object model)
    {
        return new object();
    }

    private object FetchEntityById(Guid id)
    {
        return new object();
    }

    private Guid ValidateId(Guid id)
    {
        return id;
    }
}