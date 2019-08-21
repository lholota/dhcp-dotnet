﻿using System.Net;
using Xunit;

namespace LH.Dhcp.UnitTests
{
    
    public class DhcpPacketBuilder_WithClientIpShould
    {
        [Fact]
        public void SetClientIp()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithClientIp(IPAddress.Broadcast)
                .Build();

            Assert.Equal(IPAddress.Broadcast, packet.ClientIp);
        }
    }
}