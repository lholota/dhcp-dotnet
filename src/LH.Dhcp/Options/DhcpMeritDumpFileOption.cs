using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MeritDumpFile, typeof(DhcpStringOptionSerializer))]
    public class DhcpMeritDumpFileOption : IDhcpOption
    {
        public string DumpFilePath { get; }

        public DhcpMeritDumpFileOption(string dumpFilePath)
        {
            DumpFilePath = dumpFilePath;
        }
    }
}
