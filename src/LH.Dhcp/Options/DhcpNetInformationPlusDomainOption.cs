using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NISPlusDomain)]
    public class DhcpNetInformationPlusDomainOption : IDhcpOption
    {
        public DhcpNetInformationPlusDomainOption(string nisDomain)
        {
            NisDomain = nisDomain;
        }

        public string NisDomain { get; }
    }
}