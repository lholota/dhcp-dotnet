using System;
using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacket_HasOptionByEnumCodeShould
    {
        [Fact]
        public void ReturnTrue_WhenOptionPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.True(packet.HasOption(DhcpOptionCode.DHCPMessageType));
        }

        [Fact]
        public void ReturnTrue_WhenOptionPresentInOverloadedFields()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithOverloadedFileName.Bytes);

            Assert.True(packet.HasOption(DhcpOptionCode.DomainName));
        }

        [Fact]
        public void ReturnFalse_WhenOptionNotPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.False(packet.HasOption(DhcpOptionCode.StreetTalkServer));
        }

        [Theory]
        [InlineData((DhcpOptionCode)0)]
        [InlineData((DhcpOptionCode)255)]
        public void ThrowArgumentException_GivenReservedOptionCode(DhcpOptionCode optionCode)
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.Throws<ArgumentException>(
                () => packet.HasOption(optionCode));
        }
    }
}