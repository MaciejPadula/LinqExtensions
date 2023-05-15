using FluentAssertions;
using LinqExtensions.Extensions;

namespace LinqExtensions.Tests.Extensions;

public class ToListExtensionsTest
{
    [Test]
    public void ToList_WhenWhereActionProvided_ShouldFilterEnumerable()
    {
        //Arrange
        var enumerable = Enumerable.Range(0, 10);
        var expectedResult = new List<int>
        {
            0, 1, 2, 3, 4, 5
        };

        //Act
        var list = enumerable
            .ToList(x => x <= 5);

        //Assert
        list.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void ToList_WhenWhereActionProvided_ShouldFilterList()
    {
        //Arrange
        var enumerable = Enumerable.Range(0, 10).ToList();
        var expectedResult = new List<int>
        {
            0, 1, 2, 3, 4, 5
        };

        //Act
        var list = enumerable.ToList(x => x <= 5);

        //Assert
        list.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void ToList_WhenWhereActionIsNull_ShouldNotThrowException()
    {
        //Arrange
        var enumerable = Enumerable.Range(0, 10)
            .ToList();
        var expectedResult = new List<int>
        {
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9
        };
        var action = () => enumerable.ToList(null);

        //Act && Assert
        var result = action.Should().NotThrow("This method cant throw any exception when action is null").Subject;
        result.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void ToListIf_WhenConditionIsTrue_EnumerableShouldBeOfListType()
    {
        //Arrange
        var enumerable = Enumerable.Range(0, 10);

        //Act
        var list = enumerable.ToListIf(true);

        //Assert
        list.Should().BeOfType<List<int>>();
    }

    [Test]
    public void ToListIf_WhenConditionIsFalse_EnumerableShouldBeOfListEnumerable()
    {
        //Arrange
        var enumerable = Enumerable.Range(0, 10);

        //Act
        var list = enumerable.ToListIf(false);

        //Assert
        list.Should().NotBeOfType<List<int>>();
    }
}
