using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    
    public class BootFileNameShould
    {
        [Fact]
        public void ReturnBootpFieldValue_WhenNotOverloaded()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Offer.Bytes);

            Assert.Equal(DhcpTestPackets.Offer.BootFileName, packet.BootFileName);
        }

        [Fact]
        public void ReturnOptionValue_WhenFileNameFieldOverloaded()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithOverloadedFileName.Bytes);

            Assert.Equal(DhcpTestPackets.OfferWithOverloadedFileName.BootFileName, packet.BootFileName);
        }

        [Fact]
        public void ReturnBootpFieldValue_WhenServerNameFieldOverloaded()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithOverloadedServerName.Bytes);

            Assert.Equal(DhcpTestPackets.OfferWithOverloadedServerName.BootFileName, packet.BootFileName);
        }

        [Fact]
        public void ReturnOptionValue_WhenBothFieldsOverloaded()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithBothFieldsOverloaded.Bytes);

            Assert.Equal(DhcpTestPackets.OfferWithBothFieldsOverloaded.BootFileName, packet.BootFileName);
        }

        [Fact]
        public void ReturnNull_WhenBothFieldsOverloaded_AndNoOptionPresent()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithBothFieldsOverloadedWithoutOptions.Bytes);

            Assert.Null(packet.BootFileName);
        }
    }
}