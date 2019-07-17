using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.DomainName)]
    public class DhcpDomainNameOption : IDhcpOption
    {
        public DhcpDomainNameOption(string domainName)
        {
            DomainName = domainName;
        }

        public string DomainName { get; }
    }
}
