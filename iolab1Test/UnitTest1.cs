using System;
using Xunit;

namespace iolab1Test
{
    public class StringCalculatorTest
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int res = iolab1.StringCalculator.CalculateString("");
            Assert.Equal(0, res);
        }
        [Theory]
        [InlineData("25",25)]
        [InlineData("0",0)]
        [InlineData("5",5)]
        public void SingleNumberReturnsTheValue(string s,int expected)
        {
            int res = iolab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
        [Theory]
        [InlineData("1,1", 2)]
        [InlineData("27,3", 30)]
        public void TwoNumbersReturnsSumComma(string s, int expected)
        {
            int res = iolab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
        [Theory]
        [InlineData("1\n1",2)]
        [InlineData("27\n3",30)]
        public void TwoNumbersReturnsSumNewLine(string s, int expected)
        {
            int res = iolab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
        [Theory]
        [InlineData("1,1,1", 3)]
        [InlineData("26,3,1", 30)]
        public void ThreeNumbersReturnsSumComma(string s, int expected)
        {
            int res = iolab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
        [Theory]
        [InlineData("-1,1,1")]
        [InlineData("27\n-1")]
        public void NegativeNumberThrowE(string s)
        {
            Assert.Throws<ArgumentException>(
                () => iolab1.StringCalculator.CalculateString(s)
                );
        }
        [Theory]
        [InlineData("2000", 0)]
        [InlineData("1001,1,1", 2)]
        public void Over1000(string s, int expected)
        {
            int res = iolab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
        [Theory]
        [InlineData("//$\n1$1,1", 3)]
        [InlineData("//&\n3\n3&3", 9)]
        public void NewSeparator(string s, int expected)
        {
            int res = iolab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
        [Theory]
        [InlineData("//[$:]\n1$:1,1", 3)]
        [InlineData("//[&$]\n3\n3&$3", 9)]
        public void NewSeparatorLong(string s, int expected)
        {
            int res = iolab1.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
    }
}
