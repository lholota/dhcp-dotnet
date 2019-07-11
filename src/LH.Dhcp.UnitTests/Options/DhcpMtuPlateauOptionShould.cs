using System;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    public class DhcpMtuPlateauOptionShould
    {
        [Fact]
        public void ThrowIfSmallestSizeIsLowerThanThreshold()
        {
            var sizes = new ushort[] {10, 80, 125};

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpMtuPlateauOption(sizes));
        }
    }
}