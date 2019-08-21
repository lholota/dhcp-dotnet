using Xunit;

namespace LH.Dhcp.UnitTests
{
    
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