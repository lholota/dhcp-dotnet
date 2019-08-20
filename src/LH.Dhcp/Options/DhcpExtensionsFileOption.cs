using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.ExtensionFile)]
    public class DhcpExtensionsFileOption : IDhcpOption
    {
        public DhcpExtensionsFileOption(string extensionsFile)
        {
            ExtensionsFile = extensionsFile;
        }

        public string ExtensionsFile { get; }
    }
}
