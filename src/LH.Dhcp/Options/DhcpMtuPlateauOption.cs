using System;
using System.Collections.Generic;
using System.Linq;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MTUPlateau)]
    public class DhcpMtuPlateauOption : IDhcpOption
    {
        public DhcpMtuPlateauOption(IReadOnlyList<ushort> sizes)
        {
            if (sizes.Min() < 68)
            {
                throw new ArgumentOutOfRangeException(nameof(sizes), "The smallest size must be at least 68.");
            }

            Sizes = sizes;
        }

        public IReadOnlyList<ushort> Sizes { get; }
    }
}