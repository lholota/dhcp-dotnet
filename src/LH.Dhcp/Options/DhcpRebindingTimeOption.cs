using System;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.RebindingTime)]
    public class DhcpRebindingTimeOption : IDhcpOption
    {
        public DhcpRebindingTimeOption(TimeSpan rebindingTime)
        {
            if (rebindingTime.Ticks < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(rebindingTime), "The renewal time must be greater or equal to zero.");
            }

            RebindingTime = rebindingTime;
        }

        [CreateOptionConstructor]
        internal DhcpRebindingTimeOption(uint rebindingTime)
        {
            RebindingTime = TimeSpan.FromSeconds(rebindingTime);
        }

        public TimeSpan RebindingTime { get; }
    }
}