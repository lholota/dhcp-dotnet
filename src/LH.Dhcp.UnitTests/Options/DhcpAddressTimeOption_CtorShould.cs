using System;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    // ReSharper disable once InconsistentNaming
    public class DhcpAddressTimeOption_CtorShould
    {
        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeTimeSpan()
        {
            var invalidValue = TimeSpan.FromSeconds(-10);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpAddressTimeOption(invalidValue));
        }

        [Fact]
        public void CreateInstance_GivenZeroTimeSpan()
        {
            var instance = new DhcpAddressTimeOption(TimeSpan.Zero);

            Assert.NotNull(instance);
        }
    }
}