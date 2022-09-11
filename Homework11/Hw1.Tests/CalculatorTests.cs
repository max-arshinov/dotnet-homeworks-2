using System;
using Hw1;
using Xunit;

namespace Hw1Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(15, 5, CalculatorOperation.Plus, 20)]
        [InlineData(15, 5, CalculatorOperation.Minus, 10)]
        [InlineData(15, 5, CalculatorOperation.Multiply, 75)]
        [InlineData(15, 5, CalculatorOperation.Divide, 3)]
        public void TestAllOperations(int value1, int value2, CalculatorOperation operation, int expectedValue)
        {
            //act
            var actual = Calculator.Calculate(value1, operation, value2);

            //assert
            Assert.Equal(expectedValue, actual);
        }
        
        [Fact]
        public void TestInvalidOperation()
        {
            //assert
            Assert.Throws<ArgumentOutOfRangeException>(() => Calculator.Calculate(0, CalculatorOperation.Undefined, 10));
        }

        [Fact]
        public void TestDividingNonZeroByZero()
        {
            //act
            var actual = Calculator.Calculate(0, CalculatorOperation.Divide, 10);

            //assert
            Assert.Equal(0, actual);
        }

        [Fact]
        public void TestDividingZeroByNonZero()
        {
            //act
            var actual = Calculator.Calculate(10, CalculatorOperation.Divide, 0);

            //assert
            Assert.Equal(double.PositiveInfinity, actual);
        }
        
        [Fact]
        public void TestDividingZeroByZero()
        {
            //act
            var actual = Calculator.Calculate(0, CalculatorOperation.Divide, 0);

            //assert
            Assert.Equal(double.NaN, actual);
        }
    }
}