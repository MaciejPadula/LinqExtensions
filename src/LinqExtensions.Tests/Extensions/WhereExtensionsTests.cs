using FluentAssertions;
using LinqExtensions.Extensions;

namespace LinqExtensions.Tests.Extensions;

public class WhereExtensionsTests
{
    [Test]
    public void WhereIf_WhenConditionIsTrue_ShouldReturnFilteredEnumerable()
    {
        //Arrange
        var enumerable = Enumerable.Range(0, 10);
        var expectedResult = new List<int>
        {
            0, 1, 2, 3, 4, 5
        };

        //Act
        var filtered = enumerable.WhereIf(x => x <= 5, true);

        //Assert
        filtered.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void WhereIf_WhenConditionIsFalse_ShouldReturnFilteredEnumerable()
    {
        //Arrange
        var enumerable = Enumerable.Range(0, 10);
        var expectedResult = new List<int>
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        };

        //Act
        var filtered = enumerable.WhereIf(x => x <= 5, false);

        //Assert
        filtered.Should().BeEquivalentTo(expectedResult);
    }
}
