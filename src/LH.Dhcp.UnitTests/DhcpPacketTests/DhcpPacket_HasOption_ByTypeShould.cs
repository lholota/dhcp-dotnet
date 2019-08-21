using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.DhcpPacketTests
{
    
    public class DhcpPacket_HasOption_ByTypeShould
    {
        [Fact]
        public void ReturnTrue_GivenPacketWhichContainsTheOption()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithOption(new DhcpTimeOffsetOption(0))
                .Build();

            Assert.True(packet.HasOption<DhcpTimeOffsetOption>());
        }

        [Fact]
        public void ReturnFalse_GivenPacketWhichDoesNotContainTheOption()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithOption(new DhcpTimeOffsetOption(0))
                .Build();

            Assert.False(packet.HasOption<DhcpSubnetMaskOption>());
        }
    }
}
