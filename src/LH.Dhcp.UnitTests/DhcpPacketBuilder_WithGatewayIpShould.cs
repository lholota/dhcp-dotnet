using System.Net;
using Xunit;

namespace LH.Dhcp.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacketBuilder_WithGatewayIpShould
    {
        [Fact]
        public void SetServerIp()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithGatewayIp(IPAddress.Parse("192.168.1.3"))
                .Build();

            Assert.Equal(IPAddress.Parse("192.168.1.3"), packet.GatewayIp);
        }
    }
}