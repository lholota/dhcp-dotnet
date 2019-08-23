using System;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    
    public class ToInt32Should
    {
        private static readonly byte[] TestBytes = "a0112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReturnInt32Representation()
        {
            var actual = BinaryConvert.ToInt32(TestBytes, 0);

            Assert.Equal(-1609489869, actual);
        }

        [Fact]
        public void ReadFromGivenStartIndex()
        {
            var actual = BinaryConvert.ToInt32(TestBytes, 10);

            Assert.Equal(-1430532899, actual);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            Assert.Throws<ArgumentException>(
                () => BinaryConvert.ToInt32(TestBytes, 14));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToInt32(TestBytes, 50));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToInt32(TestBytes, -1));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.ToInt32(null, 0));
        }
    }
}