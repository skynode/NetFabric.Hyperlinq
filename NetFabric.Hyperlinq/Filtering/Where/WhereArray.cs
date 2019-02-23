﻿using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static WhereArray<TSource> Where<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereArray<TSource>(source, predicate);
        }

        public readonly struct WhereArray<TSource>
            : IValueEnumerable<TSource, WhereArray<TSource>.ValueEnumerator>
        {
            readonly TSource[] source;
            readonly Func<TSource, bool> predicate;

            internal WhereArray(TSource[] source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator 
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                int index;

                internal Enumerator(in WhereArray<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public ref readonly TSource Current => ref source[index];

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereArray<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public bool TryMoveNext(out TSource current)
                {
                    index++;
                    while (index < count)
                    {
                        current = source[index];
                        if (predicate(current))
                            return true;

                        index++;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public int Count()
                => ReadOnlyList.Count<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

            public Array.WhereSelectArray<TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => Array.WhereSelect<TSource, TResult>(source, predicate, selector);

            public ValueEnumerable.WhereValueEnumerable<WhereArray<TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueEnumerable.Where<WhereArray<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => ReadOnlyList.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            public TSource First(Func<TSource, bool> predicate)
                => ValueEnumerable.First<WhereArray<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereArray<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => ReadOnlyList.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            public TSource Single(Func<TSource, bool> predicate)
                => ValueEnumerable.Single<WhereArray<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereArray<TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereArray<TSource>, ValueEnumerator, TSource>(this);

            public WhereArray<TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereArray<TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereArray<TSource>, ValueEnumerator, TSource>(this);
        }
    }
}

