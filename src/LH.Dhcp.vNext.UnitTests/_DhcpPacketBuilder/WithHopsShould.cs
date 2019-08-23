using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithHopsShould
    {
        [Fact]
        public void SetHops()
        {
            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithHops(5)
                .Build();

            Assert.Equal(5, packet.Hops);
        }
    }
}