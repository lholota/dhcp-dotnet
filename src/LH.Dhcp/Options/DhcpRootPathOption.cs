using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.RootPath, typeof(DhcpStringOptionSerializer))]
    public class DhcpRootPathOption : IDhcpOption
    {
        public string RootPath { get; }

        public DhcpRootPathOption(string rootPath)
        {
            RootPath = rootPath;
        }
    }
}