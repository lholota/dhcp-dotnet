using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithBroadcastShould
    {
        [Fact]
        public void SetBroadcast()
        {
            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithBroadcast(true)
                .Build();

            Assert.True(packet.IsBroadcast);
        }
    }
}
