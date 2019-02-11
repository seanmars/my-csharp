/** Reference: https://compiledexperience.com/blog/posts/abusing-tuples
 */

public static class TaskExtensions
{
    public static async Task<ValueTuple<T1, T2>> WhenAll<T1, T2>(this ValueTuple<Task<T1>, Task<T2>> tasks)
    {
        await Task.WhenAll(tasks.Item1, tasks.Item2);

        return (tasks.Item1.Result, tasks.Item2.Result);
    }
}
