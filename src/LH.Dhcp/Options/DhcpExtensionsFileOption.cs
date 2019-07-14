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

        internal DhcpExtensionsFileOption(DhcpBinaryValueReader valueReader)
        {
            ExtensionsFile = valueReader.AsString();
        }

        public string ExtensionsFile { get; }
    }
}
