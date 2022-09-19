using Hw2;
using Xunit;

namespace Hw2Tests
{
    public class ParserTests
    {
        [Theory]
        [InlineData("+", CalculatorOperation.Plus)]
        [InlineData("-", CalculatorOperation.Minus)]
        [InlineData("*", CalculatorOperation.Multiply)]
        [InlineData("/", CalculatorOperation.Divide)]
        public void TestCorrectOperations(string operation, CalculatorOperation operationExpected)
        {
            var p = Parser.GetOperation(operation);

            Assert.Equal(operationExpected, p);
        }

        [Theory]
        [InlineData(new[] { "1", "+", "2" }, 1, CalculatorOperation.Plus, 2)]
        [InlineData(new[] { "-43", "-", "24" }, -43, CalculatorOperation.Minus, 24)]
        [InlineData(new[] { "43", "*", "24" }, 43, CalculatorOperation.Multiply, 24)]
        [InlineData(new[] { "-43", "/", "-24" }, -43, CalculatorOperation.Divide, -24)]
        [InlineData(new[] { "43", "d", "-24" }, 43, CalculatorOperation.Undefined, -24)]
        public void CheckParserCorrectness(
            string[] args,
            int val1,
            CalculatorOperation operation,
            int val2)
        {
            Parser.ParseCalcArguments(args, out var val1r, out var operationR, out var val2r);

            Assert.Equal(val1, val1r);
            Assert.Equal(operation, operationR);
            Assert.Equal(val2, val2r);
        }

        [Fact]
        public void TestParserWrongOperation()
        {
            var p = Parser.GetOperation(";';qsdas");

            Assert.Equal(CalculatorOperation.Undefined, p);
        }

        [Theory]
        [InlineData("f", "+", "3")]
        [InlineData("3", "+", "f")]
        [InlineData("a", "+", "f")]
        public void TestParserWrongValues(string val1, string operation, string val2)
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Parser.ParseCalcArguments(
                        new[] { val1, operation, val2 },
                        out _,
                        out _,
                        out _);
                });
        }

        [Fact]
        public void TestParserWrongLength()
        {
            Assert.Throws<ArgumentException>(
                () =>
                {
                    Parser.ParseCalcArguments(
                        new[] { "12", "e", "2", "3" },
                        out _,
                        out _,
                        out _);
                });
        }
    }
}