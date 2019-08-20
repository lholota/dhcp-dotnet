using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.RootPath)]
    public class DhcpRootPathOption : IDhcpOption
    {
        public DhcpRootPathOption(string rootPath)
        {
            RootPath = rootPath;
        }

        public string RootPath { get; }
    }
}