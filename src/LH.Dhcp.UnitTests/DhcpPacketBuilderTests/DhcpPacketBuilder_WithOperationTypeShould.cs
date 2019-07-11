using Xunit;

namespace LH.Dhcp.UnitTests.DhcpPacketBuilderTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacketBuilder_WithOperationTypeShould
    {
        [Fact]
        public void SetOperationType()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithOperation(DhcpOperation.BootReply)
                .Build();

            Assert.Equal(DhcpOperation.BootReply, packet.Operation);
        }
    }
}