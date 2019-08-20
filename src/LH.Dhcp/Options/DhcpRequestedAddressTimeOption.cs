using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.AddressTime)]
    public class DhcpRequestedAddressTimeOption : IDhcpOption
    {
        public DhcpRequestedAddressTimeOption(TimeSpan leaseTime)
        {
            if (leaseTime.Ticks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(leaseTime), "The leaseTime must be greater or equal to zero.");
            }

            LeaseTime = leaseTime;
        }

        [CreateOptionConstructor]
        internal DhcpRequestedAddressTimeOption(uint leaseTimeSeconds)
        {
            LeaseTime = TimeSpan.FromSeconds(leaseTimeSeconds);
        }

        public TimeSpan LeaseTime { get; }
    }
}