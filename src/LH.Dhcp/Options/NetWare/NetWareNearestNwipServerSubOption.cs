using System;
using System.Collections.Generic;
using System.Net;

namespace LH.Dhcp.Options.NetWare
{
    public class NetWareNearestNwipServerSubOption : INetWareSubOption
    {
        public IReadOnlyList<IPAddress> NearestNwipServerAddresses { get; }

        public NetWareNearestNwipServerSubOption(IReadOnlyList<IPAddress> nearestNwipServerAddresses)
        {
            if (nearestNwipServerAddresses.Count > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(nearestNwipServerAddresses), "The list of Nearest NWIP Servers addresses can have 5 items at maximum.");
            }

            NearestNwipServerAddresses = nearestNwipServerAddresses;
        }
    }
}