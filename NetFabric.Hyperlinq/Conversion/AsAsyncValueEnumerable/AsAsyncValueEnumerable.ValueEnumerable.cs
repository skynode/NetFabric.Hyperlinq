﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerableExtensions
    {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource> AsAsyncValueEnumerable<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
            => new AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>(source);

        public readonly partial struct AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>
            : IAsyncValueEnumerable<TSource, AsyncValueEnumerableWrapper<TEnumerable, TEnumerator, TSource>.AsyncEnumerator>
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IEnumerator<TSource>
        {
            readonly TEnumerable source;

            internal AsyncValueEnumerableWrapper(TEnumerable source) 
                => this.source = source;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public readonly AsyncEnumerator GetAsyncEnumerator(CancellationToken cancellationToken = default) 
            {
                cancellationToken.ThrowIfCancellationRequested();
                return new AsyncEnumerator(source, cancellationToken);
            }
            readonly IAsyncEnumerator<TSource> IAsyncEnumerable<TSource>.GetAsyncEnumerator(CancellationToken cancellationToken)
                => GetAsyncEnumerator(cancellationToken);

            public readonly partial struct AsyncEnumerator
                : IAsyncEnumerator<TSource>
            {
                readonly TEnumerator enumerator;
                readonly CancellationToken cancellationToken;

                internal AsyncEnumerator(TEnumerable enumerable, CancellationToken cancellationToken)
                {
                    enumerator = enumerable.GetEnumerator();
                    this.cancellationToken = cancellationToken;
                }

                [MaybeNull]
                public readonly TSource Current 
                    => enumerator.Current;
                readonly TSource IAsyncEnumerator<TSource>.Current
                    => enumerator.Current;

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask<bool> MoveNextAsync() 
                {
                    cancellationToken.ThrowIfCancellationRequested();
                    return new ValueTask<bool>(enumerator.MoveNext());
                }

                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                public ValueTask DisposeAsync() 
                {
                    enumerator.Dispose();
                    return default;
                }
            }

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Task<TSource[]> ToArrayAsync(CancellationToken cancellationToken = default)
                => Task<TSource[]>.Factory.StartNew(
                    source => ValueEnumerableExtensions.ToArray<TEnumerable, TEnumerator, TSource>((TEnumerable)source),
                    source,
                    cancellationToken);

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            public Task<List<TSource>> ToListAsync(CancellationToken cancellationToken = default)
                => Task<List<TSource>>.Factory.StartNew(
                    source => ValueEnumerableExtensions.ToList<TEnumerable, TEnumerator, TSource>((TEnumerable)source),
                    source,
                    cancellationToken);
        }
    }
}