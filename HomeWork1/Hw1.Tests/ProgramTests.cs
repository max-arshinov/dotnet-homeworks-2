using System;
using Hw1;
using Xunit;

namespace Hw1Tests
{
    public class ProgramTests
    {
        [Theory]
        [InlineData(new []{ "15", "+", "5" }, 20)]
        [InlineData(new []{ "15", "/", "3" }, 5)]
        [InlineData(new []{ "15,5", "-", "0,5" }, 15)]
        public void ProgramTestValidData(string[] args, double expected)
        {
            Program.Main(args);
            var result = Program.Result;

            Assert.Equal(expected, result, 2);
        }

        [Fact]
        public void ProgramTestInvalidData()
        {
            Program.Main(new[] { "20", "f", "4" });

            Assert.Equal(Double.NaN, Program.Result);
        }
    }
}