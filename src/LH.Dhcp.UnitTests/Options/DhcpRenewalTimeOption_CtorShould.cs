using System;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    // ReSharper disable once InconsistentNaming
    public class DhcpRenewalTimeOption_CtorShould
    {
        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeRenewalTime()
        {
            var invalidValue = TimeSpan.FromSeconds(-10);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpRenewalTimeOption(invalidValue));
        }

        [Fact]
        public void CreateInstance_GivenZeroRenewalTime()
        {
            var instance = new DhcpRenewalTimeOption(TimeSpan.Zero);

            Assert.NotNull(instance);
        }
    }
}