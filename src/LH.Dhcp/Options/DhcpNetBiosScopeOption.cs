using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.NETBIOSScope)]
    public class DhcpNetBiosScopeOption : IDhcpOption
    {
        public DhcpNetBiosScopeOption(string scope)
        {
            Scope = scope;
        }

        public string Scope { get; }
    }
}