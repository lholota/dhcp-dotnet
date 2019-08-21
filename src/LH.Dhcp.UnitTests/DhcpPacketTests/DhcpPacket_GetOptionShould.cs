using System;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.DhcpPacketTests
{
    
    public class DhcpPacket_GetOptionShould
    {
        [Fact]
        public void ReturnOption()
        { 
            var option = new DhcpTimeOffsetOption(0);

            var packet = DhcpPacketBuilder.Create()
                .WithOption(option)
                .Build();

            Assert.Equal(option, packet.GetOption<DhcpTimeOffsetOption>());
        }

        [Fact]
        public void ThrowInvalidOperationException_GivenOptionTypePacketDoesNotContain()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithOption(new DhcpTimeOffsetOption(0))
                .Build();

            Assert.Throws<InvalidOperationException>(
                () => packet.GetOption<DhcpSubnetMaskOption>());
        }
    }
}