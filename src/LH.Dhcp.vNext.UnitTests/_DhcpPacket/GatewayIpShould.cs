using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    public class GatewayIpShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnGatewayIp(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.GatewayIp, packet.GatewayIp);
        }
    }
}