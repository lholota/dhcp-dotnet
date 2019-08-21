using Xunit;

namespace LH.Dhcp.UnitTests
{
    
    public class DhcpPacketBuilder_WithClientHardwareAddressShould
    {
        [Fact]
        public void SetClientHardwareAddress()
        { 
            var packet = DhcpPacketBuilder.Create()
                .WithClientHardwareAddress(ClientHardwareAddressType.Ethernet, new byte[] { 0xAA, 0x88 })
                .Build();

            Assert.Equal(ClientHardwareAddressType.Ethernet, packet.ClientHardwareAddress.Type);
            Assert.Equal(new byte[] { 0xAA, 0x88 }, packet.ClientHardwareAddress.AddressBytes);
        }
    }
}