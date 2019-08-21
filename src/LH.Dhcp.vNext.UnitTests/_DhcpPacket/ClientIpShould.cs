using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    
    public class ClientIpShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnClientIp(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.ClientIp, packet.ClientIp);
        }
    }
}