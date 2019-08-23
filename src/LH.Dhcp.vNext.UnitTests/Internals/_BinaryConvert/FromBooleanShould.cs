using System;
using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    public class FromBooleanShould
    {
        [Fact]
        public void ReturnBoolRepresentation()
        {
            var bytes = new byte[2];
            BinaryConvert.FromBoolean(bytes, 0, true);

            var expectedBytes = new byte[] { 0x01, 0x00 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void WriteFromGivenStartIndex()
        {
            var bytes = new byte[4];
            BinaryConvert.FromBoolean(bytes, 2, true);

            var expectedBytes = new byte[] { 0x00, 0x00, 0x01, 0x00 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromBoolean(bytes, 50, true));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromBoolean(bytes, -1, true));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.FromBoolean(null, 0, true));
        }
    }
}