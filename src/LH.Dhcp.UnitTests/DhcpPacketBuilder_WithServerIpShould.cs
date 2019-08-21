using System.Net;
using Xunit;

namespace LH.Dhcp.UnitTests
{
    
    public class DhcpPacketBuilder_WithServerIpShould
    {
        [Fact]
        public void SetServerIp()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithServerIp(IPAddress.Parse("192.168.1.2"))
                .Build();

            Assert.Equal(IPAddress.Parse("192.168.1.2"), packet.ServerIp);
        }
    }
}