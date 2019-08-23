using System;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    
    public class ToInt16Should
    {
        private static readonly byte[] TestBytes = "a011a233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReturnUInt16Representation()
        {
            var actual = BinaryConvert.ToInt16(TestBytes, 0);

            Assert.Equal(-24559, actual);
        }

        [Fact]
        public void ReadFromGivenStartIndex()
        {
            var actual = BinaryConvert.ToInt16(TestBytes, 2);

            Assert.Equal(-24013, actual);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            Assert.Throws<ArgumentException>(
                () => BinaryConvert.ToInt16(TestBytes, 15));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToInt16(TestBytes, 50));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToInt16(TestBytes, -1));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.ToInt16(null, 0));
        }
    }
}