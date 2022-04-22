using SumOfDigits.Classes;
using Xunit;
using FluentAssertions;

namespace App.Tests
{
    public class UnitTest
    {
        [Fact]
        public void Given_App_Started_When_Input_Is_Not_Valid_Then_Input_Remains_0()
        {
            // Arrange
            var number = new Number();

            // Act
            number.Execute(null);

            // Assert
            number.Input.Should().BeEmpty();
        }

        [Fact]
        public void Given_App_Started_When_Input_Is_Negative_Then_Input_Remains_0()
        {
            // Arrange
            var number = new Number();
            var input = "-1000";
            // Act
            number.Execute(input);

            // Assert
            number.Input.Should().BeEmpty();
        }

        [Fact]
        public void Given_App_Started_When_Input_Is_99_Then_Result_Is_9()
        {
            // Arrange
            var number = new Number();
            var input = "99";
            var expected = 9;

            // Act
            var result = number.Execute(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Given_App_Started_When_Input_Is_9_Then_Result_The_Same()
        {
            // Arrange
            var number = new Number();
            var input = "9";
            var expected = 9;

            // Act
            var result = number.Execute(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("16", 7)]
        [InlineData("942", 6)]
        [InlineData("132189", 6)]
        [InlineData("493193", 2)]
        public void Given_App_Started_When_Input_IsValid_Then_Return_Result(string input, int expected)
        {
            // Arrange
            var number = new Number();

            // Act
            var result = number.Execute(input);

            // Assert
            result.Should().Be(expected);
        }
    }
}
