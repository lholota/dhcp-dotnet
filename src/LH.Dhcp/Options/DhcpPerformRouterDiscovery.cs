﻿using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.RouterDiscovery, typeof(DhcpBooleanOptionSerializer))]
    public class DhcpPerformRouterDiscovery : IDhcpOption
    {
        public DhcpPerformRouterDiscovery(bool performRouterDiscovery)
        {
            PerformRouterDiscovery = performRouterDiscovery;
        }

        public bool PerformRouterDiscovery { get; }
    }
}