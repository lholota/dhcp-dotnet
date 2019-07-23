using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ClientId)]
    public class DhcpClientIdOption : IDhcpOption
    {
        public DhcpClientIdOption(IBinaryValue clientId)
        {
            ClientId = clientId;
        }

        public IBinaryValue ClientId { get; }
    }
}