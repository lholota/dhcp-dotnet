using System;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    public class CtorShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(10)]
        [InlineData(239)]
        public void ThrowArgumentOutOfRangeException_GivenShortBytes(int byteArrayLength)
        {
            var bytes = new byte[byteArrayLength];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpPacket(bytes));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullBytes()
        {
            Assert.Throws<ArgumentNullException>(
                () => new DhcpPacket(null));
        }

        [Fact]
        public void ThrowFormatException_GivenBytesWithoutDhcpMagicCookie()
        {
            var ex = Assert.Throws<FormatException>(
                () => new DhcpPacket(new byte[270]));

            Assert.Contains("Magic", ex.Message);
        }
    }
}