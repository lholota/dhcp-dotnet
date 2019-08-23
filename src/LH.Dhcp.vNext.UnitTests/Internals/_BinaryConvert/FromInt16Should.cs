using System;
using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    public class FromInt16Should
    {
        [Fact]
        public void ReturnInt16Representation()
        {
            var bytes = new byte[2];
            BinaryConvert.FromInt16(bytes, 0, -24559);

            var expectedBytes = new byte[] { 0xa0, 0x11 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void WriteFromGivenStartIndex()
        {
            var bytes = new byte[4];
            BinaryConvert.FromInt16(bytes, 2, -24559);

            var expectedBytes = new byte[] { 0x00, 0x00, 0xa0, 0x11 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentException>(
                () => BinaryConvert.FromInt16(bytes, 9, 1));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromInt16(bytes, 50, 1));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromInt16(bytes, -1, 1));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.FromInt16(null, 0, 1));
        }
    }
}