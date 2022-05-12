namespace FP_Playground.Either;

[Serializable]
public struct Either<TLeft, TRight>
{
    private readonly TLeft _left;
    private readonly TRight _right;
    private readonly bool _isLeft;

    public bool IsLeft => _isLeft;
    public bool IsRight => !_isLeft;

    public Either(TLeft left)
    {
        _left = left;
        _right = default;
        _isLeft = true;
    }

    public Either(TRight right)
    {
        _right = right;
        _left = default;
        _isLeft = false;
    }

    public TNextRight Match<TNextRight>(Func<TRight, TNextRight> rightFunc, Func<TLeft, TNextRight> leftFunc)
        => _isLeft ? leftFunc(_left) : rightFunc(_right);

    public static implicit operator Either<TLeft, TRight>(TLeft left) => new(left);

    public static implicit operator Either<TLeft, TRight>(TRight right) => new(right);
}