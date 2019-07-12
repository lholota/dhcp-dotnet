using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NISDomain, typeof(DhcpStringOptionSerializer))]
    public class DhcpNetInformationServerDomainOption : IDhcpOption
    {
        public DhcpNetInformationServerDomainOption(string nisServerDomain)
        {
            NisServerDomain = nisServerDomain;
        }

        public string NisServerDomain { get; }
    }
}