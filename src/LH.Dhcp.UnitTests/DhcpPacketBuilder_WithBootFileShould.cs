using Xunit;

namespace LH.Dhcp.UnitTests
{
    
    public class DhcpPacketBuilder_WithBootFileShould
    {
        [Fact]
        public void SetBootFile()
        {
            var packet = DhcpPacketBuilder.Create()
                .WithBootFile("BootFile")
                .Build();

            Assert.Equal("BootFile", packet.BootFile);
        }
    }
}