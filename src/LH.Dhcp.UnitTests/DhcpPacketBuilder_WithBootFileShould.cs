using Xunit;

namespace LH.Dhcp.UnitTests
{
    // ReSharper disable once InconsistentNaming
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