using System;
using System.Collections;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class SortedSetBindings
    {
        public static int Count<TSource>(this SortedSet<TSource> source)
            => source.Count;
        public static int Count<TSource>(this SortedSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static int Count<TSource>(this SortedSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Count<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Skip<TSource>(this SortedSet<TSource> source, int count)
            => ValueReadOnlyCollection.Skip<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static ValueReadOnlyCollection.SkipTakeEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Take<TSource>(this SortedSet<TSource> source, int count)
            => ValueReadOnlyCollection.Take<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), count);

        public static bool All<TSource>(this SortedSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.All<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Any<TSource>(this SortedSet<TSource> source)
            => source.Count != 0;

        public static bool Any<TSource>(this SortedSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.Any<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static bool Contains<TSource>(this SortedSet<TSource> source, TSource value)
            => source.Contains(value);

        public static bool Contains<TSource>(this SortedSet<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
            => ValueReadOnlyCollection.Contains<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), value, comparer);

        public static ValueReadOnlyCollection.SelectEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this SortedSet<TSource> source,
            Func<TSource, TResult> selector) 
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);
        public static ValueReadOnlyCollection.SelectIndexEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult> Select<TSource, TResult>(
            this SortedSet<TSource> source,
            Func<TSource, int, TResult> selector)
            => ValueReadOnlyCollection.Select<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ValueEnumerable.SelectManyEnumerable<ValueWrapper<TSource>,  SortedSet<TSource>.Enumerator,  TSource, TSubEnumerable, TSubEnumerator, TResult> SelectMany<TSource, TSubEnumerable, TSubEnumerator, TResult>(
            this SortedSet<TSource> source,
            Func<TSource, TSubEnumerable> selector) 
            where TSubEnumerable : IValueEnumerable<TResult, TSubEnumerator>
            where TSubEnumerator : struct, IEnumerator<TResult>
            => ValueEnumerable.SelectMany<ValueWrapper<TSource>,  SortedSet<TSource>.Enumerator, TSource, TSubEnumerable, TSubEnumerator, TResult>(new ValueWrapper<TSource>(source), selector);

        public static ValueEnumerable.WhereEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Where<TSource>(
            this SortedSet<TSource> source,
            Func<TSource, bool> predicate) 
            => ValueEnumerable.Where<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static ValueEnumerable.WhereIndexEnumerable<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource> Where<TSource>(
            this SortedSet<TSource> source,
            Func<TSource, int, bool> predicate)
            => ValueEnumerable.Where<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource First<TSource>(this SortedSet<TSource> source) 
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource First<TSource>(this SortedSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.First<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource FirstOrDefault<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource FirstOrDefault<TSource>(this SortedSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.FirstOrDefault<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TryFirst<TSource>(this SortedSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TryFirst<TSource>(this SortedSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TryFirst<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static TSource Single<TSource>(this SortedSet<TSource> source) 
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource Single<TSource>(this SortedSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.Single<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static TSource SingleOrDefault<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static TSource SingleOrDefault<TSource>(this SortedSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.SingleOrDefault<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
        public static (ElementResult Success, TSource Value) TrySingle<TSource>(this SortedSet<TSource> source, Func<TSource, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);
        public static (int Index, TSource Value) TrySingle<TSource>(this SortedSet<TSource> source, Func<TSource, int, bool> predicate)
            => ValueReadOnlyCollection.TrySingle<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source), predicate);

        public static ValueWrapper<TSource> AsEnumerable<TSource>(this SortedSet<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static ValueWrapper<TSource> AsValueEnumerable<TSource>(this SortedSet<TSource> source)
            => new ValueWrapper<TSource>(source);

        public static TSource[] ToArray<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollection.ToArray<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));

        public static List<TSource> ToList<TSource>(this SortedSet<TSource> source)
            => ValueReadOnlyCollection.ToList<ValueWrapper<TSource>, SortedSet<TSource>.Enumerator, TSource>(new ValueWrapper<TSource>(source));
            
        public readonly struct ValueWrapper<TSource> 
            : IValueReadOnlyCollection<TSource, SortedSet<TSource>.Enumerator>
        {
            readonly SortedSet<TSource> source;

            public ValueWrapper(SortedSet<TSource> source)
            {
                this.source = source;
            }

            public int Count => source.Count;

            public SortedSet<TSource>.Enumerator GetEnumerator() => source.GetEnumerator();
            IEnumerator<TSource> IEnumerable<TSource>.GetEnumerator() => source.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => source.GetEnumerator();
        }      
    }
}