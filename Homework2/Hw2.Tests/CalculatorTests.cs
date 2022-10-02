using Hw2;
using Xunit;

namespace Hw2Tests
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
            var result = Calculator.Calculate(value1, operation, value2);
            
            Assert.Equal(expectedValue, result, 5);
        }
        
        [Fact]
        public void TestInvalidOperation()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                Calculator.Calculate(0, CalculatorOperation.Undefined, 10));
        }

        [Fact]
        public void TestDividingNonZeroByZero()
        {
            var actual = Calculator.Calculate(10, CalculatorOperation.Divide, 0);

            Assert.Equal(double.PositiveInfinity, actual);
        }

        [Fact]
        public void TestDividingZeroByNonZero()
        {
            var actual = Calculator.Calculate(0, CalculatorOperation.Divide, 10);

            Assert.Equal(0, actual);
        }
        
        [Fact]
        public void TestDividingZeroByZero()
        {
            var actual = Calculator.Calculate(0, CalculatorOperation.Divide, 0);

            Assert.Equal(double.NaN, actual);
        }
    }
}