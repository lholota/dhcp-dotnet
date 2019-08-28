using System;
using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._PacketStream
{
    public class CtorShould
    {
        [Theory]
        [InlineData(-10)]
        [InlineData(50)]
        public void ThrowArgumentException_GivenLengthLowerThan240(int length)
        {
            Assert.Throws<ArgumentException>(
                () => new PacketStream(length));
        }
    }
}