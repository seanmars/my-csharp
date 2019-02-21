using System.Collections.Generic;

public static class EnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int chunksize)
    {
        while (source.Any())
        {
            yield return source.Take(chunksize);
            source = source.Skip(chunksize);
        }
    }
}
