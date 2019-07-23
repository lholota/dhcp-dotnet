using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.TftpServerName)]
    public class DhcpTftpServerNameOption : IDhcpOption
    {
        public DhcpTftpServerNameOption(string serverName)
        {
            ServerName = serverName;
        }

        public string ServerName { get; }
    }
}