using System.Diagnostics.Contracts;

namespace FP_Playground.Either;

public static class EitherExtensions
{
    /// <summary>
    /// Bind extension
    /// Maps the value of an Either to the input of a
    /// function that returns an new Either
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <typeparam name="TNextRight">Right</typeparam>
    /// <param name="either">Either value</param>
    /// <param name="nextFunc">Function to bind</param>
    /// <returns>Either output of nextFunc</returns>
    public static Either<TLeft, TNextRight> Bind<TLeft, TRight, TNextRight>(this Either<TLeft, TRight> either,
        Func<TRight, Either<TLeft, TNextRight>> nextFunc) =>
        either.Match(
            nextFunc,
            Left<TLeft, TNextRight>
        );

    /// <summary>
    /// Bind extension
    /// Maps the value of an async Either to the input of an
    /// async function that returns an new Either
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <typeparam name="TNextRight">Right</typeparam>
    /// <param name="eitherAsync">Either value</param>
    /// <param name="nextFunc">Function to bind</param>
    /// <returns>Async Either output of nextFunc</returns>
    public static async Task<Either<TLeft, TNextRight>> BindAsync<TLeft, TRight, TNextRight>(
        this Task<Either<TLeft, TRight>> eitherAsync,
        Func<TRight, Task<Either<TLeft, TNextRight>>> nextFunc)
    {
        var val = await eitherAsync;
        return await val.Match(
            nextFunc,
            left => Task.FromResult(Left<TLeft, TNextRight>(left))
        );
    }

    /// <summary>
    /// Bind extension
    /// Maps the value of an async Either to the input of a
    /// function that returns an new Either
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <typeparam name="TNextRight">Right</typeparam>
    /// <param name="eitherAsync">Either value</param>
    /// <param name="nextFunc">Function to bind</param>
    /// <returns>Async Either output of nextFunc</returns>
    public static async Task<Either<TLeft, TNextRight>> BindAsync<TLeft, TRight, TNextRight>(
        this Task<Either<TLeft, TRight>> eitherAsync,
        Func<TRight, Either<TLeft, TNextRight>> nextFunc)
    {
        var val = await eitherAsync;
        return val.Match(
            nextFunc,
            Left<TLeft, TNextRight>
        );
    }

    /// <summary>
    /// Bind extension
    /// Maps the value of an Either to the input of an
    /// async function that returns an new Either
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <typeparam name="TNextRight">Right</typeparam>
    /// <param name="either">Either value</param>
    /// <param name="nextFunc">Function to bind</param>
    /// <returns>Async Either output of nextFunc</returns>
    public static Task<Either<TLeft, TNextRight>> BindAsync<TLeft, TRight, TNextRight>(this Either<TLeft, TRight> either,
        Func<TRight, Task<Either<TLeft, TNextRight>>> nextFunc) =>
        either.Match(
            nextFunc,
            left => Task.FromResult(Left<TLeft, TNextRight>(left))
        );

    /// <summary>
    /// Map extension
    /// Maps the value of an Either to the input of an
    /// function that returns a new type and converts it to an Either
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <typeparam name="TNextRight">Right</typeparam>
    /// <param name="either">Either value</param>
    /// <param name="nextFunc">Function to bind</param>
    /// <returns>Output of nextFunc as Either</returns>
    public static Either<TLeft, TNextRight> Map<TLeft, TRight, TNextRight>(this Either<TLeft, TRight> either,
        Func<TRight, TNextRight> nextFunc) =>
        either.Match(
            right => Right<TLeft, TNextRight>(nextFunc(right)),
            Left<TLeft, TNextRight>
        );

    /// <summary>
    /// Map extension
    /// Maps the value of an async Either to the input of an
    /// async function that returns a new type and converts it to an Either
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <typeparam name="TNextRight">Right</typeparam>
    /// <param name="eitherAsync">Either value</param>
    /// <param name="nextFunc">Function to map</param>
    /// <returns>Output of nextFunc converted to an Either type</returns>
    public static async Task<Either<TLeft, TNextRight>> MapAsync<TLeft, TRight, TNextRight>(
        this Task<Either<TLeft, TRight>> eitherAsync,
        Func<TRight, Task<TNextRight>> nextFunc)
    {
        var val = await eitherAsync;
        return await val.Match(
            async right => Right<TLeft, TNextRight>(await nextFunc(right)),
            left => Task.FromResult(Left<TLeft, TNextRight>(left))
        );
    }

    /// <summary>
    /// Map extension
    /// Maps the value of an async Either to the input of a
    /// function that returns a new type and converts it to an Either
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <typeparam name="TNextRight">Right</typeparam>
    /// <param name="eitherAsync">Either value</param>
    /// <param name="nextFunc">Function to map</param>
    /// <returns>Output of nextFunc converted to an Either type</returns>
    public static async Task<Either<TLeft, TNextRight>> MapAsync<TLeft, TRight, TNextRight>(
        this Task<Either<TLeft, TRight>> eitherAsync,
        Func<TRight, TNextRight> nextFunc) =>
        (await eitherAsync).Match(
            right => Right<TLeft, TNextRight>(nextFunc(right)),
            Left<TLeft, TNextRight>
        );

    /// <summary>
    /// Map extension
    /// Maps the value of Either to the input of an
    /// async function that returns a new type and converts it to an Either
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <typeparam name="TNextRight">Right</typeparam>
    /// <param name="either">Either value</param>
    /// <param name="nextFunc">Function to map</param>
    /// <returns>Output of nextFunc converted to an Either type</returns>
    public static Task<Either<TLeft, TNextRight>> MapAsync<TLeft, TRight, TNextRight>(this Either<TLeft, TRight> either,
        Func<TRight, Task<TNextRight>> nextFunc) =>
        either.Match(
            async right => Right<TLeft, TNextRight>(await nextFunc(right)),
            left => Task.FromResult(Left<TLeft, TNextRight>(left))
        );

    /// <summary>
    /// Match Extension
    /// Matches async either value to left/right functions
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <typeparam name="TNextRight">Right</typeparam>
    /// <param name="asyncEither">Async either to match against</param>
    /// <param name="rightFunc">Function to execute if Either is in Right state</param>
    /// <param name="leftFunc">Function to execute if Either is in Left state</param>
    /// <returns>A new value of type TNextRight</returns>
    public static async Task<TNextRight> MatchAsync<TLeft, TRight, TNextRight>(this Task<Either<TLeft, TRight>> asyncEither,
        Func<TRight, TNextRight> rightFunc, Func<TLeft, TNextRight> leftFunc) =>
        (await asyncEither).Match(
            rightFunc,
            leftFunc
        );

    /// <summary>
    /// Either constructor
    /// Constructs an Either in a Left state
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <param name="value">Left value</param>
    /// <returns>A new Either instance</returns>
    [Pure]
    public static Either<TLeft, TRight> Left<TLeft, TRight>(TLeft value) => new(value);

    /// <summary>
    /// Either constructor
    /// Constructs an Either in a Right state
    /// </summary>
    /// <typeparam name="TLeft">Left</typeparam>
    /// <typeparam name="TRight">Right</typeparam>
    /// <param name="value">Right value</param>
    /// <returns>A new Either instance</returns>
    [Pure]
    public static Either<TLeft, TRight> Right<TLeft, TRight>(TRight value) => new(value);
}
