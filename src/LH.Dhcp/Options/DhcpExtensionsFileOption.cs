using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ExtensionFile, typeof(DhcpStringOptionSerializer))]
    public class DhcpExtensionsFileOption : IDhcpOption
    {
        public string ExtensionsFile { get; }

        public DhcpExtensionsFileOption(string extensionsFile)
        {
            ExtensionsFile = extensionsFile;
        }
    }
}
