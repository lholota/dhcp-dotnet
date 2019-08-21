using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryValue_CtorShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenOffsetLowerThanZero()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpBinaryValue(TestBytes, -1, 10));

            Assert.Equal("offset", ex.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenLengthBeyondBytesLength()
        {
            var ex =Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpBinaryValue(TestBytes, 10, 255));

            Assert.Equal("length", ex.ParamName);
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullBytes()
        {
            var ex = Assert.Throws<ArgumentNullException>(
                () => new DhcpBinaryValue(null, 10, 2));

            Assert.Equal("data", ex.ParamName);
        }
    }
}