using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace NetFabric.Hyperlinq
{
    public static partial class ArrayExtensions
    {
        public static bool Contains<TList, TSource>(this in ArraySegment<TSource> source, [AllowNull] TSource value)
            where TSource : struct
        {
            var array = source.Array;
            if (source.IsWhole())
            {
                foreach (var item in array)
                {
                    if (EqualityComparer<TSource>.Default.Equals(item, value!))
                        return true;
                }
            }
            else
            {
                var end = source.Count + source.Offset;
                for (var index = source.Offset; index < end; index++)
                {
                    if (EqualityComparer<TSource>.Default.Equals(array[index], value!))
                        return true;
                }
            }
            return false;
        }

        public static bool Contains<TSource>(this in ArraySegment<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource>? comparer = null)
        {
            if (source.Count == 0)
                return false;

            if (Utils.UseDefault(comparer))
                return DefaultContains(source, value!);

            comparer ??= EqualityComparer<TSource>.Default;
            return ComparerContains(source, value, comparer);

            static bool DefaultContains(in ArraySegment<TSource> source, [AllowNull] TSource value)
            {
                var array = source.Array;
                if (source.IsWhole())
                {
                    foreach (var item in array)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(item, value!))
                            return true;
                    }
                }
                else
                {
                    var end = source.Count + source.Offset;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (EqualityComparer<TSource>.Default.Equals(array[index], value!))
                            return true;
                    }
                }
                return false;
            }

            static bool ComparerContains(in ArraySegment<TSource> source, [AllowNull] TSource value, IEqualityComparer<TSource> comparer)
            {
                var array = source.Array;
                if (source.IsWhole())
                {
                    foreach (var item in array)
                    {
                        if (comparer.Equals(item, value!))
                            return true;
                    }
                }
                else
                {
                    var end = source.Count + source.Offset;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (comparer.Equals(array[index], value!))
                            return true;
                    }
                }
                return false;
            }
        }


        static bool Contains<TSource, TResult>(this in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
        {
            return source.Count switch
            {
                0 => false,
                _ => Utils.IsValueType<TResult>()
                    ? ValueContains(source, value, selector)
                    : ReferenceContains(source, value, selector)
            };

            static bool ValueContains(in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
            {
                var array = source.Array;
                if (source.IsWhole())
                {
                    foreach (var item in array)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(item)!, value!))
                            return true;
                    }
                }
                else
                {
                    var end = source.Count + source.Offset;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(array[index])!, value!))
                            return true;
                    }
                }
                return false;
            }

            static bool ReferenceContains(in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelector<TSource, TResult> selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                var array = source.Array;
                if (source.IsWhole())
                {
                    foreach (var item in array)
                    {
                        if (defaultComparer.Equals(selector(item)!, value!))
                            return true;
                    }
                }
                else
                {
                    var end = source.Count + source.Offset;
                    for (var index = source.Offset; index < end; index++)
                    {
                        if (defaultComparer.Equals(selector(array[index])!, value!))
                            return true;
                    }
                }
                return false;
            }
        }


        static bool Contains<TSource, TResult>(this in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
        {
            return source.Count switch
            {
                0 => false,
                _ => Utils.IsValueType<TResult>()
                    ? ValueContains(source, value, selector)
                    : ReferenceContains(source, value, selector),
            };

            static bool ValueContains(in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
            {
                var array = source.Array;
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in array)
                    {
                        if (EqualityComparer<TResult>.Default.Equals(selector(item, index)!, value!))
                            return true;

                        index++;
                    }
                }
                else
                {
                    if (source.Offset == 0)
                    {
                        var end = source.Count;
                        for (var index = 0; index < end; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(array[index], index)!, value!))
                                return true;
                        }
                    }
                    else
                    {
                        var offset = source.Offset;
                        var end = source.Count;
                        for (var index = 0; index < end; index++)
                        {
                            if (EqualityComparer<TResult>.Default.Equals(selector(array[index + offset], index)!, value!))
                                return true;
                        }
                    }
                }
                return false;
            }

            static bool ReferenceContains(in ArraySegment<TSource> source, [AllowNull] TResult value, NullableSelectorAt<TSource, TResult> selector)
            {
                var defaultComparer = EqualityComparer<TResult>.Default;

                var array = source.Array;
                if (source.IsWhole())
                {
                    var index = 0;
                    foreach (var item in array)
                    {
                        if (defaultComparer.Equals(selector(item, index)!, value!))
                            return true;

                        index++;
                    }
                }
                else
                {
                    if (source.Offset == 0)
                    {
                        var end = source.Count;
                        for (var index = 0; index < end; index++)
                        {
                            if (defaultComparer.Equals(selector(array[index], index)!, value!))
                                return true;
                        }
                    }
                    else
                    {
                        var offset = source.Offset;
                        var end = source.Count;
                        for (var index = 0; index < end; index++)
                        {
                            if (defaultComparer.Equals(selector(array[index + offset], index)!, value!))
                                return true;
                        }
                    }
                }
                return false;
            }
        }
    }
}

