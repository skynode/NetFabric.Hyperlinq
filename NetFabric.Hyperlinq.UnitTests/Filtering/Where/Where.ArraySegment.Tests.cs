using NetFabric.Assertive;
using System;
using System.Linq;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests.Filtering.Where
{
    public class ArraySegmentTests
    {
        [Fact]
        public void Where_With_Null_Must_Throw()
        {
            // Arrange
            var source = new int[0];
            var wrapped = new ArraySegment<int>(source);
            var predicate = (Predicate<int>)null;

            // Act
            Action action = () => _ = ArrayExtensions
                .Where(wrapped, predicate);

            // Assert
            _ = action.Must()
                .Throw<ArgumentNullException>()
                .EvaluateTrue(exception => exception.ParamName == "predicate");
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicateMultiple), MemberType = typeof(TestData))]
        public void Where_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);
            var expected = Enumerable
                .Where(wrapped, predicate.AsFunc());

            // Act
            var result = ArrayExtensions
                .Where(wrapped, predicate);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }

        [Theory]
        [MemberData(nameof(TestData.SkipTakePredicatePredicateEmpty), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicatePredicateSingle), MemberType = typeof(TestData))]
        [MemberData(nameof(TestData.SkipTakePredicatePredicateMultiple), MemberType = typeof(TestData))]
        public void Where_Where_With_ValidData_Must_Succeed(int[] source, int skipCount, int takeCount, Predicate<int> predicate0, Predicate<int> predicate1)
        {
            // Arrange
            var (skip, take) = Utils.SkipTake(source.Length, skipCount, takeCount);
            var wrapped = new ArraySegment<int>(source, skip, take);
            var expected = Enumerable
                .Where(wrapped, predicate0.AsFunc())
                .Where(predicate1.AsFunc());

            // Act
            var result = ArrayExtensions
                .Where(wrapped, predicate0)
                .Where(predicate1);

            // Assert
            _ = result.Must()
                .BeEnumerableOf<int>()
                .BeEqualTo(expected, testRefStructs: false);
            _ = result.SequenceEqual(expected).Must().BeTrue();
        }
    }
}