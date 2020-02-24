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
    
    public static Dictionary<TKey, List<TValue>> GroupByDictionary<TKey, TValue>(
            this IEnumerable<TValue> items,
            Func<TValue, TKey> keySelector)
    {
        var dictionary = new Dictionary<TKey, List<TValue>>();
        foreach (var item in items)
        {
            var key = keySelector(item);
            if (!dictionary.TryGetValue(key, out var grouping))
            {
                grouping = new List<TValue>(1);
                dictionary.Add(key, grouping);
            }

            grouping.Add(item);
        }

        return dictionary;
    }

    public static Dictionary<TKey, List<TValue>> GroupByDictionary<TOutput, TKey, TValue>(
        this IEnumerable<TOutput> items,
        Func<TOutput, TKey> keySelector, Func<TOutput, TValue> valueSelector)
    {
        var dictionary = new Dictionary<TKey, List<TValue>>();
        foreach (var item in items)
        {
            var key = keySelector(item);
            if (!dictionary.TryGetValue(key, out var grouping))
            {
                grouping = new List<TValue>(1);
                dictionary.Add(key, grouping);
            }

            grouping.Add(valueSelector(item));
        }

        return dictionary;
    }
}
