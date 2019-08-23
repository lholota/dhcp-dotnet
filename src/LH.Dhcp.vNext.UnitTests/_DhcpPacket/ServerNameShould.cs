using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    public class ServerNameShould
    {
        [Fact]
        public void ReturnBootpFieldValue_WhenNotOverloaded()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithServerName.Bytes);

            Assert.Equal(DhcpTestPackets.OfferWithServerName.ServerName, packet.ServerName);
        }

        [Fact]
        public void ReturnBootpFieldValue_WhenFileNameOverloaded()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithOverloadedFileName.Bytes);

            Assert.Equal(DhcpTestPackets.OfferWithOverloadedFileName.ServerName, packet.ServerName);
        }

        [Fact]
        public void ReturnOptionValue_WhenServerNameOverloaded()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithOverloadedServerName.Bytes);

            Assert.Equal(DhcpTestPackets.OfferWithOverloadedServerName.ServerName, packet.ServerName);
        }

        [Fact]
        public void ReturnOptionValue_WhenBothFieldsOverloaded()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithBothFieldsOverloaded.Bytes);

            Assert.Equal(DhcpTestPackets.OfferWithBothFieldsOverloaded.ServerName, packet.ServerName);
        }

        [Fact]
        public void ReturnNull_WhenBothFieldsOverloaded_AndNoOptionPresent()
        {
            var packet = new DhcpPacket(DhcpTestPackets.OfferWithBothFieldsOverloadedWithoutOptions.Bytes);

            Assert.Null(packet.ServerName);
        }
    }
}