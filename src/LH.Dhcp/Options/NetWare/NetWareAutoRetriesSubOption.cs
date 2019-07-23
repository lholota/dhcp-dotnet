namespace LH.Dhcp.Options.NetWare
{
    public class NetWareAutoRetriesSubOption : INetWareSubOption
    {
        public byte RetryCount { get; }

        public NetWareAutoRetriesSubOption(byte retryCount)
        {
            RetryCount = retryCount;
        }
    }
}