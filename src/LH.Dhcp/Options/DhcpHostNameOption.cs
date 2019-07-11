using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.Hostname, typeof(DhcpStringOptionSerializer))]
    public class DhcpHostNameOption : IDhcpOption
    {
        public string HostName { get; }

        public DhcpHostNameOption(string hostName)
        {
            HostName = hostName;
        }
    }
}
