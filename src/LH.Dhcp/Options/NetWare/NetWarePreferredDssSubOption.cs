using System;
using System.Collections.Generic;
using System.Net;

namespace LH.Dhcp.Options.NetWare
{
    public class NetWarePreferredDssSubOption : INetWareSubOption
    {
        public IReadOnlyList<IPAddress> DssServerAddresses { get; }

        public NetWarePreferredDssSubOption(IReadOnlyList<IPAddress> dssServerAddresses)
        {
            if (dssServerAddresses.Count > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(dssServerAddresses), "The list of DSS Server addresses can have 5 items at maximum.");
            }

            DssServerAddresses = dssServerAddresses;
        }
    }
}