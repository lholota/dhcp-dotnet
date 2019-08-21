using System;
using LH.Dhcp.Options;
using Xunit;

namespace LH.Dhcp.UnitTests.Options
{
    
    public class DhcpRequestedAddressTimeOption_CtorShould
    {
        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeTimeSpan()
        {
            var invalidValue = TimeSpan.FromSeconds(-10);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpRequestedAddressTimeOption(invalidValue));
        }

        [Fact]
        public void CreateInstance_GivenZeroTimeSpan()
        {
            var instance = new DhcpRequestedAddressTimeOption(TimeSpan.Zero);

            Assert.NotNull(instance);
        }
    }
}