namespace LH.Dhcp.Options.NetWare
{
    public class NetWareNsqBroadcastSubOption : INetWareSubOption
    {
        public bool ShouldPerformNearestQuery { get; }

        public NetWareNsqBroadcastSubOption(bool shouldPerformNearestQuery)
        {
            ShouldPerformNearestQuery = shouldPerformNearestQuery;
        }
    }
}