using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacket_SecsShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnSecs(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.Secs, packet.Secs);
        }
    }
}