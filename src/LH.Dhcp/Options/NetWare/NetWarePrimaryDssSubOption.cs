using System.Net;

namespace LH.Dhcp.Options.NetWare
{
    public class NetWarePrimaryDssSubOption : INetWareSubOption
    {
        public NetWarePrimaryDssSubOption(IPAddress primaryDssServerAddress)
        {
            PrimaryDssServerAddress = primaryDssServerAddress;
        }

        public IPAddress PrimaryDssServerAddress { get; }
    }
}