using System;
using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._KeyLengthValueReader
{
    public class CtorShould
    {
        private static readonly byte[] Bytes = new byte[] {0x01, 0x02, 0x0a};

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => new KeyLengthValueReader(null, 0, 5));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenArrayShorterThanTwoBytes()
        {
            Assert.Throws<ArgumentException>(
                () => new KeyLengthValueReader(new byte[1], 0, 1));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenOffsetLargerThanByteArray()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new KeyLengthValueReader(Bytes, 50, 5));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeOffset()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new KeyLengthValueReader(Bytes, -1, 5));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenOffsetAndLengthLargerThanByteArray()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new KeyLengthValueReader(Bytes, 2, 10));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new KeyLengthValueReader(Bytes, 0, -1));
        }
    }
}