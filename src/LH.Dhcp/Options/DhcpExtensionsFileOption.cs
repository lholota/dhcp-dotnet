using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ExtensionFile)]
    public class DhcpExtensionsFileOption : IDhcpOption
    {
        public DhcpExtensionsFileOption(string extensionsFile)
        {
            ExtensionsFile = extensionsFile;
        }

        public string ExtensionsFile { get; }
    }
}
