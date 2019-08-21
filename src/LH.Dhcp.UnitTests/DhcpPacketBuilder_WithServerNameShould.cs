using Xunit;

namespace LH.Dhcp.UnitTests
{
    
    public class DhcpPacketBuilder_WithServerNameShould
    {
        [Fact]
        public void SetServerName()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithServerName("ServerName")
                .Build();

            Assert.Equal("ServerName", packet.ServerName);
        }
    }
}