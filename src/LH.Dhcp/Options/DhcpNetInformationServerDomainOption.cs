using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.NISDomain)]
    public class DhcpNetInformationServerDomainOption : IDhcpOption
    {
        public DhcpNetInformationServerDomainOption(string nisServerDomain)
        {
            NisServerDomain = nisServerDomain;
        }

        public string NisServerDomain { get; }
    }
}