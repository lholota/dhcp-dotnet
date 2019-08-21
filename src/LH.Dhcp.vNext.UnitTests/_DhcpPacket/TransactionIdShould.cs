using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    
    public class TransactionIdShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnTransactionId(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.TransactionId, packet.TransactionId);
        }
    }
}