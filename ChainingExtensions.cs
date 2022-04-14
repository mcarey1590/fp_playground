namespace FP_Playground;

public static class ChainingExtensions
{
    /// <summary>
    /// Takes the output of the function and passes it as the first argument of another function
    /// </summary>
    /// <param name="input">Output of prior function</param>
    /// <param name="mapping">Function that accepts input as first argument</param>
    /// <typeparam name="TIn">Input type of mapping function</typeparam>
    /// <typeparam name="TOut">Output type of mapping function</typeparam>
    public static TOut AndThen<TIn, TOut>(this TIn input, Func<TIn, TOut> mapping) =>
        mapping(input);

    /// <summary>
    /// Takes the output of the function and passes it as the first argument of another function
    /// </summary>
    /// <param name="input">Output of prior function</param>
    /// <param name="mapping">Async function that accepts input as first argument</param>
    /// <param name="token">Cancellation token</param>
    /// <typeparam name="TIn">Input type of mapping function</typeparam>
    /// <typeparam name="TOut">Output type of mapping function</typeparam>
    public static async Task<TOut> AndThenAsync<TIn, TOut>(this TIn input,
        Func<TIn, CancellationToken, Task<TOut>> mapping,
        CancellationToken token) =>
        await mapping(input, token).ConfigureAwait(false);

    /// <summary>
    /// Takes the output of the function and passes it as the first argument of another function
    /// </summary>
    /// <param name="input">Output of prior function</param>
    /// <param name="mapping">Async function that accepts input as first argument</param>
    /// <typeparam name="TIn">Input type of mapping function</typeparam>
    /// <typeparam name="TOut">Output type of mapping function</typeparam>
    public static async Task<TOut> AndThenAsync<TIn, TOut>(this TIn input,
        Func<TIn, Task<TOut>> mapping) =>
        await mapping(input).ConfigureAwait(false);

    /// <summary>
    /// Takes the output of the function and passes it as the first argument of another function
    /// </summary>
    /// <param name="inputTask">Task output of prior function</param>
    /// <param name="mapping">Async function that accepts input as first argument</param>
    /// <param name="token">Cancellation token</param>
    /// <typeparam name="TIn">Input type of mapping function</typeparam>
    /// <typeparam name="TOut">Output type of mapping function</typeparam>
    public static async Task<TOut> AndThenAsync<TIn, TOut>(this Task<TIn> inputTask,
        Func<TIn, CancellationToken, Task<TOut>> mapping,
        CancellationToken token)
    {
        var input = await inputTask;
        return await mapping(input, token);
    }

    /// <summary>
    /// Takes the output of the function and passes it as the first argument of another function
    /// </summary>
    /// <param name="inputTask">Task output of prior function</param>
    /// <param name="mapping">Async function that accepts input as first argument</param>
    /// <typeparam name="TIn">Input type of mapping function</typeparam>
    /// <typeparam name="TOut">Output type of mapping function</typeparam>
    public static async Task<TOut> AndThenAsync<TIn, TOut>(this Task<TIn> inputTask,
        Func<TIn, Task<TOut>> mapping)
    {
        var input = await inputTask;
        return await mapping(input);
    }

    /// <summary>
    /// Takes the output of the function and passes it as the first argument of another function
    /// </summary>
    /// <param name="inputTask">Task output of prior function</param>
    /// <param name="mapping">Async function that accepts input as first argument</param>
    /// <typeparam name="TIn">Input type of mapping function</typeparam>
    /// <typeparam name="TOut">Output type of mapping function</typeparam>
    public static async Task<TOut> AndThenAsync<TIn, TOut>(this Task<TIn> inputTask,
        Func<TIn, TOut> mapping)
    {
        var input = await inputTask;
        return mapping(input);
    }
}
