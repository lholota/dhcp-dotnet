using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.Hostname)]
    public class DhcpHostNameOption : IDhcpOption
    {
        public DhcpHostNameOption(string hostName)
        {
            HostName = hostName;
        }

        internal DhcpHostNameOption(DhcpBinaryValueReader valueReader)
        {
            HostName = valueReader.AsString();
        }

        public string HostName { get; }
    }
}
