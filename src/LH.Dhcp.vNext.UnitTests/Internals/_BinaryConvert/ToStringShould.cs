using System;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    
    public class ToStringShould
    {
        private static readonly byte[] TestBytes = "48656c6c6f2c20776f726c6421".AsHexBytes();

        [Fact]
        public void TrimTrailingZeroBytes()
        {
            var bytes = "48650000".AsHexBytes();
            var actual = BinaryConvert.ToString(bytes, 0, bytes.Length);

            Assert.Equal("He", actual);
        }

        [Fact]
        public void ReturnStringRepresentation()
        {
            var actual = BinaryConvert.ToString(TestBytes, 0, TestBytes.Length);

            Assert.Equal("Hello, world!", actual);
        }

        [Fact]
        public void ReturnStringRepresentationOfGivenLength()
        {
            var actual = BinaryConvert.ToString(TestBytes, 0, 3);

            Assert.Equal("Hel", actual);
        }

        [Fact]
        public void ReadFromGivenStartIndex()
        {
            var actual = BinaryConvert.ToString(TestBytes, 2, 2);

            Assert.Equal("ll", actual);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            Assert.Throws<ArgumentException>(
                () => BinaryConvert.ToString(TestBytes, 0, 270));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToString(TestBytes, 500, 1));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToString(TestBytes, -1, 1));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void ThrowArgumentOutOfRangeException_GivenInvalidLength(int length)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToString(TestBytes, 1, length));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.ToString(null, 0, 1));
        }
    }
}