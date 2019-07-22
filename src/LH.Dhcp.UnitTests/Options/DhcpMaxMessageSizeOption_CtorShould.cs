using System;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    // ReSharper disable once InconsistentNaming
    public class DhcpMaxMessageSizeOption_CtorShould
    {
        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        [InlineData(575)]
        public void ThrowArgumentOutOfRangeException_GivenSizeLowerThanThreshold(ushort size)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpMaxMessageSizeOption(size));
        }
    }
}