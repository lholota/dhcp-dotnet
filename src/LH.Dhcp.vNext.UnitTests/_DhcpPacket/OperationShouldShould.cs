using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    
    public class OperationShouldShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnOperation(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.Operation, packet.Operation);
        }
    }
}