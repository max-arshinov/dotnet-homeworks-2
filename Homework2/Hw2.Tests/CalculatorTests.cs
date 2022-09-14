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
            throw new NotImplementedException();
        }
        
        [Fact]
        public void TestInvalidOperation()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void TestDividingNonZeroByZero()
        {
            throw new NotImplementedException();
        }

        [Fact]
        public void TestDividingZeroByNonZero()
        {
            throw new NotImplementedException();
        }
        
        [Fact]
        public void TestDividingZeroByZero()
        {
            throw new NotImplementedException();
        }
    }
}