using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.BootfileName)]
    public class DhcpBootFileNameOption : IDhcpOption
    {
        public DhcpBootFileNameOption(string fileName)
        {
            FileName = fileName;
        }

        public string FileName { get; }
    }
}