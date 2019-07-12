using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.StaticRoute, typeof(DhcpIpAddressPairOptionSerializer))]
    public class DhcpStaticRoutesOption : IDhcpOption
    {
        internal DhcpStaticRoutesOption(IEnumerable<Tuple<IPAddress, IPAddress>> staticRoutes)
        {
            StaticRoutes = staticRoutes
                .Select(x => new DhcpStaticRoute(x.Item1, x.Item2))
                .ToArray();
        }

        public DhcpStaticRoutesOption(IReadOnlyList<DhcpStaticRoute> staticRoutes)
        {
            StaticRoutes = staticRoutes;
        }

        public IReadOnlyList<DhcpStaticRoute> StaticRoutes { get; }
    }

    public class DhcpStaticRoute
    {
        public IPAddress Destination { get; }

        public IPAddress Router { get; }

        public DhcpStaticRoute(IPAddress destination, IPAddress router)
        {
            Destination = destination;
            Router = router;
        }
    }
}