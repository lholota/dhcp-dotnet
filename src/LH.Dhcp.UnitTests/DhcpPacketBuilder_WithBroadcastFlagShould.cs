using Xunit;

namespace LH.Dhcp.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacketBuilder_WithBroadcastFlagShould
    {
        [Fact]
        public void SetIsBroadcast()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithBroadcastFlag(true)
                .Build();

            Assert.True(packet.IsBroadcast);
        }
    }
}