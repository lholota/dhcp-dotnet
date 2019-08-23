using System;
using System.Net;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithClientIpShould
    {
        [Fact]
        public void SetClientIp()
        {
            var clientIp = IPAddress.Parse("192.168.1.2");

            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithClientIp(clientIp)
                .Build();

            Assert.Equal(clientIp, packet.ClientIp);
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNull()
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentNullException>(
                () => builder.WithClientIp(null));
        }
    }
}