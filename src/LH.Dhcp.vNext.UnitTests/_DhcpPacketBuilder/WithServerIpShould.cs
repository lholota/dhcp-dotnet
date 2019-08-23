using System;
using System.Net;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithServerIpShould
    {
        [Fact]
        public void SetServerIp()
        {
            var serverIp = IPAddress.Parse("192.168.1.3");

            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithServerIp(serverIp)
                .Build();

            Assert.Equal(serverIp, packet.ServerIp);
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNull()
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentNullException>(
                () => builder.WithServerIp(null));
        }
    }
}