using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyListExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SkipTakeEnumerable<TList, TSource> Take<TList, TSource>(this TList source, int count)
            where TList : IReadOnlyList<TSource>
            => SkipTake<TList, TSource>(source, 0, count);
    }
}