using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.IRCServer)]
    public class DhcpIrcServersOption : IDhcpOption
    {
        public IReadOnlyList<IPAddress> IrcServerAddresses { get; }

        public DhcpIrcServersOption(IReadOnlyList<IPAddress> ircServerAddresses)
        {
            IrcServerAddresses = ircServerAddresses;
        }
    }
}