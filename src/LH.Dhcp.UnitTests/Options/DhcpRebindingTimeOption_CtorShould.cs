using System;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    
    public class DhcpRebindingTimeOption_CtorShould
    {
        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeRenewalTime()
        {
            var invalidValue = TimeSpan.FromSeconds(-10);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpRebindingTimeOption(invalidValue));
        }

        [Fact]
        public void CreateInstance_GivenZeroRenewalTime()
        {
            var instance = new DhcpRebindingTimeOption(TimeSpan.Zero);

            Assert.NotNull(instance);
        }
    }
}