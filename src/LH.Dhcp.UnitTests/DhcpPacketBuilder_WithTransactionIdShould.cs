﻿using Xunit;

namespace LH.Dhcp.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacketBuilder_WithTransactionIdShould
    {
        [Fact]
        public void SetTransactionIdFromUint()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithTransactionId(123456U)
                .Build();

            Assert.Equal(123456U, packet.TransactionId);
        }
    }
}