using System;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class BinaryValue_CtorShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenOffsetLowerThanZero()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new BinaryValue(TestBytes, -1, 10));

            Assert.Equal("offset", ex.ParamName);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-10)]
        public void ThrowArgumentOutOfRangeException_GivenLengthLowerOrEqualToZero(int length)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new BinaryValue(TestBytes, 0, length));

            Assert.Equal("length", ex.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenLengthBeyondBytesLength()
        {
            var ex =Assert.Throws<ArgumentOutOfRangeException>(
                () => new BinaryValue(TestBytes, 10, 255));

            Assert.Equal("length", ex.ParamName);
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullBytes()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new BinaryValue(null, 10, 2));

            Assert.Equal("bytes", ex.ParamName);
        }
    }
}