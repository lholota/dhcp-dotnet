using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class CreateShould
    {
        [Theory]
        [InlineData(DhcpMessageType.Discover, DhcpOperation.BootRequest)]
        [InlineData(DhcpMessageType.Request, DhcpOperation.BootRequest)]
        [InlineData(DhcpMessageType.Decline, DhcpOperation.BootRequest)]
        [InlineData(DhcpMessageType.Release, DhcpOperation.BootRequest)]
        [InlineData(DhcpMessageType.Inform, DhcpOperation.BootRequest)]
        [InlineData(DhcpMessageType.Offer, DhcpOperation.BootReply)]
        [InlineData(DhcpMessageType.Ack, DhcpOperation.BootReply)]
        [InlineData(DhcpMessageType.NAck, DhcpOperation.BootReply)]
        public void DefaultOperation(DhcpMessageType msgType, DhcpOperation expectedOperation)
        {
            var packet = DhcpPacketBuilder.Create(msgType).Build();

            Assert.Equal(expectedOperation, packet.Operation);
        }

        [Fact]
        public void AddMessageTypeOption()
        {
            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack).Build();

            Assert.Equal(DhcpMessageType.Ack, packet.GetOption<DhcpMessageTypeOption>().MessageType);
        }

        [Fact]
        public void SetRandomTransactionId()
        {
            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack).Build();

            Assert.NotEqual(0U, packet.TransactionId);
        }
    }
}