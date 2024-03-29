﻿using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MTUInterface)]
    public class DhcpMtuInterfaceOption : IDhcpOption
    {
        public DhcpMtuInterfaceOption(ushort mtu)
        {
            Mtu = mtu;
        }

        public ushort Mtu { get; }
    }
}
