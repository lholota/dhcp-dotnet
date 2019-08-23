using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithSecondsElapsedShould
    {
        [Fact]
        public void SetSecondsElapsed()
        {
            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithSecondsElapsed(10)
                .Build();

            Assert.Equal(10, packet.SecondsElapsed);
        }
    }
}