using Xunit;

namespace LH.Dhcp.UnitTests.DhcpPacketBuilderTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacketBuilder_WithServerNameShould
    {
        [Fact]
        public void SetServerName()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithServerName("ServerName")
                .Build();

            Assert.Equal("ServerName", packet.ServerName);
        }
    }
}