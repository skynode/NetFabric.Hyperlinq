using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        public static int Count<TList, TSource>(this TList source)
            where TList : IReadOnlyList<TSource>
            => source.Count;

        static unsafe int Count<TList, TSource>(this TList source, Predicate<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var counter = 0;
            var end = offset + count;
            for (var index = offset; index < end; index++)
            {
                var result = predicate(source[index]);
                counter += *(int*)&result;
            }
            return counter;
        }

        static unsafe int Count<TList, TSource>(this TList source, PredicateAt<TSource> predicate, int offset, int count)
            where TList : IReadOnlyList<TSource>
        {
            var counter = 0;
            if (offset == 0)
            {
                for (var index = 0; index < count; index++)
                {
                    var result = predicate(source[index], index);
                    counter += *(int*)&result;
                }
            }
            else
            {
                for (var index = 0; index < count; index++)
                {
                    var result = predicate(source[index + offset], index);
                    counter += *(int*)&result;
                }
            }
            return counter;
        }
    }
}

