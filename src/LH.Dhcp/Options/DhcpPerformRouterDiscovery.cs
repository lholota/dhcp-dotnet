﻿using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.RouterDiscovery)]
    public class DhcpPerformRouterDiscovery : IDhcpOption
    {
        public DhcpPerformRouterDiscovery(bool performRouterDiscovery)
        {
            PerformRouterDiscovery = performRouterDiscovery;
        }

        public bool PerformRouterDiscovery { get; }
    }
}