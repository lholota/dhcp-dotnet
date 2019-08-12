using System.Net;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacketBuilder_WithOptionShould
    {
        [Fact]
        public void AddOption()
        {
            var option = new DhcpSubnetMaskOption(IPAddress.Broadcast);

            var packet = DhcpPacketBuilder.Create()
                .WithRawOption(option)
                .Build();

            Assert.True(ReferenceEquals(option, packet.GetOption<DhcpSubnetMaskOption>()));
        }

        [Fact]
        public void ReplaceExistingOption()
        {
            var option1 = new DhcpSubnetMaskOption(IPAddress.Broadcast);
            var option2 = new DhcpSubnetMaskOption(IPAddress.Broadcast);

            var packet = DhcpPacketBuilder.Create()
                .WithRawOption(option1)
                .WithRawOption(option2)
                .Build();

            Assert.True(ReferenceEquals(option2, packet.GetOption<DhcpSubnetMaskOption>()));
        }
    }
}