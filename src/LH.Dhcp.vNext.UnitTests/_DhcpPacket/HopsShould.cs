using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    
    public class HopsShould
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