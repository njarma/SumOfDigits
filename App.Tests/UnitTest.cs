using Xunit;
using FluentAssertions;
using SumOfDigits.Interfaces;
using Moq;
using SumOfDigits.Classes;

namespace App.Tests
{
    public class UnitTest
    {
        public readonly Mock<IValidation> _validationMock;

        public UnitTest()
        {
            _validationMock = new Mock<IValidation>();
        }

        [Fact]
        public void Given_Run_Executed_Method_When_Input_Is_Empty_Then_Input_Remains_0()
        {
            // Arrange
            var input = string.Empty;

            // Act
            _validationMock.Setup(x => x.Validate(input)).Returns(false);
            var number = new Number(_validationMock.Object);
            var result = number.Execute(input);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void Given_Run_Executed_Method_When_Input_Is_Negative_Then_Input_Remains_0()
        {
            // Arrange
            var input = "-1000";

            // Act
            _validationMock.Setup(x => x.Validate(input)).Returns(false);
            var number = new Number(_validationMock.Object);
            var result = number.Execute(input);

            // Assert
            result.Should().Be(0);
        }

        [Fact]
        public void Given_Run_Executed_Method_When_Input_Is_99_Then_Result_Is_9()
        {
            // Arrange
            var input = "99";
            var expected = 9;

            // Act
            _validationMock.Setup(x => x.Validate(input)).Returns(true);
            var number = new Number(_validationMock.Object);
            var result = number.Execute(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Given_Run_Executed_Method_When_Input_Is_9_Then_Result_The_Same()
        {
            // Arrange
            var input = "9";
            var expected = 9;

            // Act
            _validationMock.Setup(x => x.Validate(input)).Returns(true);
            var number = new Number(_validationMock.Object);
            var result = number.Execute(input);

            // Assert
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("16", 7)]
        [InlineData("942", 6)]
        [InlineData("132189", 6)]
        [InlineData("493193", 2)]
        public void Given_Run_Executed_Method_When_Input_IsValid_Then_Return_Result(string input, int expected)
        {
            // Arrange

            // Act
            _validationMock.Setup(x => x.Validate(input)).Returns(true);
            var number = new Number(_validationMock.Object);
            var result = number.Execute(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Given_Run_Validate_Method_When_Input_IsEmpty_Then_Return_False()
        {
            // Arrange
            var input = "";
            var expected = false;
            var validation = new Validation();

            // Act
            validation.Set(new NotNullOrEmptyStrategy());
            var result = validation.Validate(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Given_Run_Validate_Method_When_Input_IsNotEmpty_Then_Return_True()
        {
            // Arrange
            var input = "124";
            var expected = true;
            var validation = new Validation();

            // Act
            validation.Set(new NotNullOrEmptyStrategy());
            var result = validation.Validate(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Given_Run_Validate_Method_When_Input_Negative_Then_Return_False()
        {
            // Arrange
            var input = "-12";
            var expected = false;
            var validation = new Validation();

            // Act            
            validation.Set(new PositiveInputStrategy());
            var result = validation.Validate(input);

            // Assert
            result.Should().Be(expected);
        }

        [Fact]
        public void Given_Run_Validate_Method_When_Input_Positive_Then_Return_True()
        {
            // Arrange
            var input = "12";
            var expected = true;
            var validation = new Validation();

            // Act
            validation.Set(new PositiveInputStrategy());
            var result = validation.Validate(input);

            // Assert
            result.Should().Be(expected);
        }

    }
}
