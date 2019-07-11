using System;
using System.Collections.Generic;
using System.Linq;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MTUPlateau, typeof(DhcpUnsignedInt16ListOptionSerializer))]
    public class DhcpMtuPlateauOption : IDhcpOption
    {
        public IReadOnlyList<ushort> Sizes { get; }

        public DhcpMtuPlateauOption(IReadOnlyList<ushort> sizes)
        {
            if (sizes.Min() < 68)
            {
                throw new ArgumentOutOfRangeException(nameof(sizes), "The smallest size must be at least 68.");
            }

            Sizes = sizes;
        }
    }
}