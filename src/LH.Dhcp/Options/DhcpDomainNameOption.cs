using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.DomainName, typeof(DhcpStringOptionSerializer))]
    public class DhcpDomainNameOption : IDhcpOption
    {
        public string DomainName { get; }

        public DhcpDomainNameOption(string domainName)
        {
            DomainName = domainName;
        }
    }
}
