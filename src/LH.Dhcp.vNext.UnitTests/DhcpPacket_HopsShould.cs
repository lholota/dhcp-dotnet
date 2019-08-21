using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacket_HopsShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnHops(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.Hops, packet.Hops);
        }
    }
}