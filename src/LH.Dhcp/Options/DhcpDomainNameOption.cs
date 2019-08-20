using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.DomainName)]
    public class DhcpDomainNameOption : IDhcpOption
    {
        public DhcpDomainNameOption(string domainName)
        {
            DomainName = domainName;
        }

        public string DomainName { get; }
    }
}
