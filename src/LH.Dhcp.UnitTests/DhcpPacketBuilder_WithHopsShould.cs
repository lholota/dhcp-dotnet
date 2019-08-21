using Xunit;

namespace LH.Dhcp.UnitTests
{
    
    public class DhcpPacketBuilder_WithHopsShould
    {
        [Fact]
        public void SetHops()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithHops(50)
                .Build();

            Assert.Equal(50U, packet.Hops);
        }
    }
}