﻿using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.SwapServer)]
    public class DhcpSwapServerOption : IDhcpOption
    {
        public DhcpSwapServerOption(IPAddress swapServerAddress)
        {
            SwapServerAddress = swapServerAddress;
        }

        public IPAddress SwapServerAddress { get; }
    }
}