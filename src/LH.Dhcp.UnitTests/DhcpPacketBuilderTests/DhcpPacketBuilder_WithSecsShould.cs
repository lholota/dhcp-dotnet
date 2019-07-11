using Xunit;

namespace LH.Dhcp.UnitTests.DhcpPacketBuilderTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacketBuilder_WithSecsShould
    {
        [Fact]
        public void SetSecs()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithSecs(50)
                .Build();

            Assert.Equal(50, packet.Secs);
        }
    }
}