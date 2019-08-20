using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.MeritDumpFile)]
    public class DhcpMeritDumpFileOption : IDhcpOption
    {
        public DhcpMeritDumpFileOption(string dumpFilePath)
        {
            DumpFilePath = dumpFilePath;
        }

        public string DumpFilePath { get; }
    }
}
