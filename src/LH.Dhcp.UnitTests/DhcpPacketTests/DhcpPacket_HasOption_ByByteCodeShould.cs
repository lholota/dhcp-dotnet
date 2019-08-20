using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.DhcpPacketTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacket_HasOption_ByByteCodeShould
    {
        [Fact]
        public void ReturnTrue_GivenPacketWhichContainsTheOption()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithOption(new DhcpTimeOffsetOption(0))
                .Build();

            Assert.True(packet.HasOption(2));
        }

        [Fact]
        public void ReturnFalse_GivenPacketWhichDoesNotContainTheOption()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithOption(new DhcpTimeOffsetOption(0))
                .Build();

            Assert.False(packet.HasOption(1));
        }
    }
}