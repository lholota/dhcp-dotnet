using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._PacketStream
{
    public class ToArrayShould
    {
        [Fact]
        public void ReturnOnlyUsedBytes()
        {
            var stream = new PacketStream();

            stream.Allocate(50);

            var result = stream.ToArray();

            Assert.Equal(240 + 50, result.Length);
        }
    }
}