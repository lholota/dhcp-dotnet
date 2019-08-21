using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    
    public class YourIpShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnYourIp(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.YourIp, packet.YourIp);
        }
    }
}