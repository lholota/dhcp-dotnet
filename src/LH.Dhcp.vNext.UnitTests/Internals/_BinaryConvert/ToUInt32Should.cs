using System;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    
    public class ToUInt32Should
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReturnUInt32Representation()
        {
            var actual = BinaryConvert.ToUInt32(TestBytes, 0);

            Assert.Equal(1122867U, actual);
        }

        [Fact]
        public void ReadFromGivenStartIndex()
        {
            var actual = BinaryConvert.ToUInt32(TestBytes, 2);

            Assert.Equal(573785173U, actual);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            Assert.Throws<ArgumentException>(
                () => BinaryConvert.ToUInt32(TestBytes, 14));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToUInt32(TestBytes, 50));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToUInt32(TestBytes, -1));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.ToUInt32(null, 0));
        }
    }
}