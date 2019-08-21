using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    
    public class IsBroadcastShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnWhetherPacketHasBroadcastFlagSet(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.IsBroadcast, packet.IsBroadcast);
        }
    }
}