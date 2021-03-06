﻿using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {

        static LargeArrayBuilder<TSource> ToArrayBuilder<TList, TSource>(in TList source, Predicate<TSource> predicate, int offset, int count, ArrayPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TSource>(pool);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                if (predicate(source[index]))
                    builder.Add(source[index]);
            }
            return builder;
        }

        static LargeArrayBuilder<TSource> ToArrayBuilder<TList, TSource>(in TList source, PredicateAt<TSource> predicate, int offset, int count, ArrayPool<TSource> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TSource>(pool);
            if (offset == 0)
            {
                for (var index = 0; index < count; index++)
                {
                    if (predicate(source[index], index))
                        builder.Add(source[index]);
                }
            }
            else
            {
                for (var index = 0; index < count; index++)
                {
                    if (predicate(source[index + offset], index))
                        builder.Add(source[index + offset]);
                }
            }
            return builder;
        }

        static LargeArrayBuilder<TResult> ToArrayBuilder<TList, TSource, TResult>(in TList source, Predicate<TSource> predicate, NullableSelector<TSource, TResult> selector, int offset, int count, ArrayPool<TResult> pool)
            where TList : IReadOnlyList<TSource>
        {
            Debug.Assert(pool is object);

            var builder = new LargeArrayBuilder<TResult>(pool);
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                if (predicate(source[index]))
                    builder.Add(selector(source[index]));
            }
            return builder;
        }
    }
}
