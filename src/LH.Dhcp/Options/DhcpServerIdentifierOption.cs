using System.Net;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.DHCPServerId)]
    public class DhcpServerIdentifierOption : IDhcpOption
    {
        public DhcpServerIdentifierOption(IPAddress serverAddress)
        {
            ServerAddress = serverAddress;
        }

        public IPAddress ServerAddress { get; }
    }
}