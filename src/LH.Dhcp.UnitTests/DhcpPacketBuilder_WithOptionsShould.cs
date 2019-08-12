using System.Net;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacketBuilder_WithOptionsShould
    {
        [Fact]
        public void AddOption()
        {
            var options = new IDhcpOption[]
            {
                new DhcpTimeOffsetOption(0), 
                new DhcpSubnetMaskOption(IPAddress.Broadcast),
            };

            var packet = DhcpPacketBuilder.Create()
                .WithRawOptions(options)
                .Build();

            Assert.Equal(options[0], packet.GetOption<DhcpTimeOffsetOption>());
            Assert.Equal(options[1], packet.GetOption<DhcpSubnetMaskOption>());
        }

        [Fact]
        public void ReplaceExistingOption()
        {
            var updatedOptions = new IDhcpOption[]
            {
                new DhcpTimeOffsetOption(0),
                new DhcpSubnetMaskOption(IPAddress.Broadcast)
            };
            
            var packet = DhcpPacketBuilder.Create()
                .WithRawOption(new DhcpTimeOffsetOption(0))
                .WithRawOptions(updatedOptions)
                .Build();

            Assert.Equal(updatedOptions[0], packet.GetOption<DhcpTimeOffsetOption>());
        }
    }
}