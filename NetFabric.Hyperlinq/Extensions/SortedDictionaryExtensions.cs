﻿using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class SortedDictionaryExtensions
    {
        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source.Count;

        public static int Count<TKey, TValue>(this SortedDictionary<TKey, TValue> source, Func<KeyValuePair<TKey, TValue>, bool> predicate)
            => ReadOnlyCollection.Count<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static ReadOnlyCollection.SelectReadOnlyCollection<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult> Select<TKey, TValue, TResult>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, TResult> selector) 
            => ReadOnlyCollection.Select<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> Where<TKey, TValue>(
            this SortedDictionary<TKey, TValue> source,
            Func<KeyValuePair<TKey, TValue>, bool> predicate) 
            => Enumerable.Where<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source, predicate);

        public static KeyValuePair<TKey, TValue> First<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.First<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> FirstOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.FirstOrDefault<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> Single<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.Single<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue> SingleOrDefault<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.SingleOrDefault<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);
        public static IEnumerable<KeyValuePair<TKey, TValue>> AsEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source;

        public static IReadOnlyCollection<KeyValuePair<TKey, TValue>> AsReadOnlyCollection<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => source;

        public static Enumerable.AsValueEnumerableEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> AsValueEnumerable<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => Enumerable.AsValueEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>> AsValueReadOnlyCollection<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static KeyValuePair<TKey, TValue>[] ToArray<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToArray<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);

        public static List<KeyValuePair<TKey, TValue>> ToList<TKey, TValue>(this SortedDictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToList<SortedDictionary<TKey, TValue>, SortedDictionary<TKey, TValue>.Enumerator, KeyValuePair<TKey, TValue>>(source);
    }
}
