using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    
    public class ServerIpShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnServerIp(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.ServerIp, packet.ServerIp);
        }
    }
}