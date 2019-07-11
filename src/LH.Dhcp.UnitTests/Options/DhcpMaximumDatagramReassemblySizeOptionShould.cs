using System;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    public class DhcpMaximumDatagramReassemblySizeOptionShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(575)]
        public void ThrowArgumentOutOfException_GivenSizeLowerThanMinumumThreshold(ushort length)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpMaximumDatagramReassemblySizeOption(length));
        }
    }
}