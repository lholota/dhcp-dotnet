using System.Net;
using Xunit;

namespace LH.Dhcp.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacketBuilder_WithYourIpShould
    {
        [Fact]
        public void SetYourIp()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithYourIp(IPAddress.Parse("192.168.1.1"))
                .Build();

            Assert.Equal(IPAddress.Parse("192.168.1.1"), packet.YourIp);
        }
    }
}