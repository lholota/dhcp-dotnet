using System;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithTransactionIdShould
    {
        [Fact]
        public void SetTransactionId()
        {
            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithTransactionId(11111U)
                .Build();

            Assert.Equal(11111U, packet.TransactionId);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenZero()
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => builder.WithTransactionId(0));
        }
    }
}