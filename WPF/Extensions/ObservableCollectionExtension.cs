using System;
using System.Collections.Immutable;
using System.Collections.ObjectModel;

namespace WPF.Extensions
{
    public static class ObservableCollectionExtension
    {
        public static bool Update<T>(this ObservableCollection<T> collection, T newData, Predicate<T> predicate)
        {
            if (predicate == null)
            {
                return false;
            }

            var index = collection
                .ToImmutableList()
                .FindIndex(predicate);

            if (index == -1)
            {
                return false;
            }

            collection[index] = newData;
            return true;
        }
    }
}
