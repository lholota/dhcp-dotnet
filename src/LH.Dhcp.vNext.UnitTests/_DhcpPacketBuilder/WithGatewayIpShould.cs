using System;
using System.Net;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithGatewayIpShould
    {
        [Fact]
        public void SetGatewayIp()
        {
            var gatewayIp = IPAddress.Parse("192.168.1.3");

            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithGatewayIp(gatewayIp)
                .Build();

            Assert.Equal(gatewayIp, packet.GatewayIp);
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNull()
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentNullException>(
                () => builder.WithGatewayIp(null));
        }
    }
}