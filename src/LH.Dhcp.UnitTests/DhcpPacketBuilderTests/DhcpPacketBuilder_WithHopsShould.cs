using Xunit;

namespace LH.Dhcp.UnitTests.DhcpPacketBuilderTests
{
    // ReSharper disable once InconsistentNaming
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