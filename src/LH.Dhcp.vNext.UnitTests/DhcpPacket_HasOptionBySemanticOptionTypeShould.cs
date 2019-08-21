using LH.Dhcp.vNext.Options;
using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacket_HasOptionBySemanticOptionTypeShould
    {
        [Fact]
        public void ReturnTrue_WhenOptionPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.True(packet.HasOption<DhcpMessageTypeOption>());
        }

        [Fact]
        public void ReturnTrue_WhenOptionPresentInOverloadedFields()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithOverloadedFileName.Bytes);

            Assert.True(packet.HasOption<DhcpDomainNameOption>());
        }

        [Fact]
        public void ReturnFalse_WhenOptionNotPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.False(packet.HasOption<DhcpSubnetMaskOption>());
        }
    }
}