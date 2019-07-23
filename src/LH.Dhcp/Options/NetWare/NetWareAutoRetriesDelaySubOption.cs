using System;

namespace LH.Dhcp.Options.NetWare
{
    public class NetWareAutoRetriesDelaySubOption : INetWareSubOption
    {
        public TimeSpan RetryDelay { get; }

        internal NetWareAutoRetriesDelaySubOption(byte retryDelay)
        {
            RetryDelay = TimeSpan.FromSeconds(retryDelay);
        }
    }
}