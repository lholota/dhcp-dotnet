using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ClassId)]
    public class DhcpClassIdOption : IDhcpOption
    {
        public DhcpClassIdOption(IBinaryValue classId)
        {
            ClassId = classId;
        }

        public IBinaryValue ClassId { get; }
    }
}