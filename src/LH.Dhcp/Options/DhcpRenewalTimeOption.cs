using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.RenewalTime)]
    public class DhcpRenewalTimeOption : IDhcpOption
    { 
        public DhcpRenewalTimeOption(TimeSpan renewalTime)
        {
            if (renewalTime.Ticks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(renewalTime), "The renewal time must be greater or equal to zero.");
            }

            RenewalTime = renewalTime;
        }

        [CreateOptionConstructor]
        internal DhcpRenewalTimeOption(uint renewalTime)
        {
            RenewalTime = TimeSpan.FromSeconds(renewalTime);
        }

        public TimeSpan RenewalTime { get; }
    }
}