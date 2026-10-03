namespace apps._public;

public interface IAsync
{
    /// <summary>
    /// Gets the result from a task synchronously.
    /// </summary>
    /// <typeparam name="T">The type of the result.</typeparam>
    /// <param name="task">The task to get result from.</param>
    /// <returns>The result of the task.</returns>
    T GetResult<T>(Task<T> task);
}
