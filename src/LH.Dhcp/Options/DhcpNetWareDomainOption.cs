﻿using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NetWareIPDomain)]
    public class DhcpNetWareDomainOption : IDhcpOption
    {
        public DhcpNetWareDomainOption(string domain)
        {
            Domain = domain;
        }

        public string Domain { get; }
    }
}