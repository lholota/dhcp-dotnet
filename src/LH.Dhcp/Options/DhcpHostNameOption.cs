using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.Hostname)]
    public class DhcpHostNameOption : IDhcpOption
    {
        public DhcpHostNameOption(string hostName)
        {
            HostName = hostName;
        }

        public string HostName { get; }
    }
}
