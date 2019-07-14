using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.PolicyFilter)]
    public class DhcpPolicyFilterOption : IDhcpOption
    {
        public IEnumerable<DhcpPolicyFilter> Filters { get; }

        internal DhcpPolicyFilterOption(IEnumerable<Tuple<IPAddress, IPAddress>> ipAddressPairs)
        {
            Filters = ipAddressPairs
                .Select(x => new DhcpPolicyFilter(x.Item1, x.Item2))
                .ToArray();
        }

        public DhcpPolicyFilterOption(IEnumerable<DhcpPolicyFilter> filters)
        {
            Filters = filters;
        }
    }

    public class DhcpPolicyFilter
    {
        public IPAddress Destination { get; }

        public IPAddress SubnetMask { get; }

        public DhcpPolicyFilter(IPAddress destination, IPAddress subnetMask)
        {
            Destination = destination;
            SubnetMask = subnetMask;

            // TODO: Add CIDR prefix
        }
    }
}