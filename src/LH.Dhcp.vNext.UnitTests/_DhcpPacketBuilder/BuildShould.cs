using System.Linq;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class BuildShould
    {
        [Fact]
        public void AddEndOptionAtTheEnd()
        {
            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack).Build();

            Assert.Equal(0xff, packet.RawBytes.Last());
        }
    }
}