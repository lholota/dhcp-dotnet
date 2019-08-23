using System;
using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    public class FromUInt32Should
    {
        [Fact]
        public void ReturnUInt32Representation()
        {
            var bytes = new byte[4];
            BinaryConvert.FromUInt32(bytes, 0, 1122867U);

            var expectedBytes = new byte[] { 0x00, 0x11, 0x22, 0x33 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void WriteFromGivenStartIndex()
        {
            var bytes = new byte[6];
            BinaryConvert.FromUInt32(bytes, 2, 573785173U);

            var expectedBytes = new byte[] { 0x00, 0x00, 0x22, 0x33, 0x44, 0x55 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentException>(
                () => BinaryConvert.FromUInt32(bytes, 8, 1U));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromUInt32(bytes, 50, 1U));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromUInt32(bytes, -1, 1U));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.FromUInt32(null, 0, 1U));
        }
    }
}