using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._PacketStream
{
    public class AllocateShould
    {
        [Fact]
        public void AllocateMoreSpaceWhenRequired()
        {
            var stream = new PacketStream(300);

            stream.Allocate(200);

            Assert.True(stream.Buffer.Length > 240 + 200);
        }

        [Fact]
        public void NotAllocateSpace_WhenFreeSpaceIsAvailable()
        {
            var stream = new PacketStream(300);

            stream.Allocate(50);

            Assert.Equal(300, stream.Buffer.Length);
        }
    }
}