using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NETBIOSScope)]
    public class DhcpNetBiosScopeOption : IDhcpOption
    {
        public DhcpNetBiosScopeOption(string scope)
        {
            Scope = scope;
        }

        public string Scope { get; }
    }
}