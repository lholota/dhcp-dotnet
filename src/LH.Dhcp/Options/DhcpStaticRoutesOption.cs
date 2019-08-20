using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.StaticRoute)]
    public class DhcpStaticRoutesOption : IDhcpOption
    {
        [CreateOptionConstructorAttribute]
        internal DhcpStaticRoutesOption(IReadOnlyList<Tuple<IPAddress, IPAddress>> staticRoutes)
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