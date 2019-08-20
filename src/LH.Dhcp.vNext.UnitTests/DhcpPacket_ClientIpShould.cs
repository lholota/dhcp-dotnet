using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacket_ClientIpShould
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