using System;
using System.Net;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithYourIpShould
    {
        [Fact]
        public void SetYourIp()
        {
            var yourIp = IPAddress.Parse("192.168.1.3");

            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithYourIp(yourIp)
                .Build();

            Assert.Equal(yourIp, packet.YourIp);
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNull()
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentNullException>(
                () => builder.WithYourIp(null));
        }
    }
}