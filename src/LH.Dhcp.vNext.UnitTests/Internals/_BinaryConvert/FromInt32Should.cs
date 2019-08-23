using System;
using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    public class FromInt32Should
    {
        [Fact]
        public void ReturnInt32Representation()
        {
            var bytes = new byte[4];
            BinaryConvert.FromInt32(bytes, 0, -1609489869);

            var expectedBytes = new byte[] { 0xa0, 0x11, 0x22, 0x33 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void WriteFromGivenStartIndex()
        {
            var bytes = new byte[6];
            BinaryConvert.FromInt32(bytes, 2, -1609489869);

            var expectedBytes = new byte[] { 0x00, 0x00, 0xa0, 0x11, 0x22, 0x33 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentException>(
                () => BinaryConvert.FromInt32(bytes, 8, 1));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromInt32(bytes, 50, 1));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromInt32(bytes, -1, 1));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.FromInt32(null, 0, 1));
        }
    }
}