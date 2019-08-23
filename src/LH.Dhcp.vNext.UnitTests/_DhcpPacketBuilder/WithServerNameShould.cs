using System;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithServerNameShould
    {
        [Fact]
        public void SetServerName()
        {
            const string serverName = "some-server-name";

            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithServerName(serverName)
                .Build();

            Assert.Equal(serverName, packet.ServerName);
        }

        [Fact]
        public void ThrowArgumentException_GivenValueLongerThan64Chars()
        {
            var serverName = string.Empty.PadRight(65, 'a');

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentException>(
                () => builder.WithServerName(serverName));
        }
    }
}