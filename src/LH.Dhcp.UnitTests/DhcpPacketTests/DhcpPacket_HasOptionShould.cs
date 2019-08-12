using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.DhcpPacketTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacket_HasOptionShould
    {
        [Fact]
        public void ReturnTrue_GivenPacketWhichContainsTheOption()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithRawOption(new DhcpTimeOffsetOption(0))
                .Build();

            Assert.True(packet.HasOption<DhcpTimeOffsetOption>());
        }

        [Fact]
        public void ReturnFalse_GivenPacketWhichDoesNotContainTheOption()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithRawOption(new DhcpTimeOffsetOption(0))
                .Build();

            Assert.False(packet.HasOption<DhcpSubnetMaskOption>());
        }
    }
}
