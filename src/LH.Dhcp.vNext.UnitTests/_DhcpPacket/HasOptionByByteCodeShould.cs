using System;
using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    
    public class HasOptionByByteCodeShould
    {
        [Fact]
        public void ReturnTrue_WhenOptionPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.True(packet.HasOption(53));
        }

        [Fact]
        public void ReturnTrue_WhenOptionPresentInOverloadedFields()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithOverloadedFileName.Bytes);

            Assert.True(packet.HasOption(15));
        }

        [Fact]
        public void ReturnFalse_WhenOptionNotPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.False(packet.HasOption(140));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(66)]
        [InlineData(67)]
        [InlineData(255)]
        public void ThrowArgumentException_GivenReservedOptionCode(byte optionCode)
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.Throws<ArgumentException>(
                () => packet.HasOption(optionCode));
        }
    }
}