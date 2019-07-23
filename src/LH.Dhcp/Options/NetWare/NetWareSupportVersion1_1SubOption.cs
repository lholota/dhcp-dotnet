namespace LH.Dhcp.Options.NetWare
{
    public class NetWareSupportVersion11SubOption : INetWareSubOption
    {
        public NetWareSupportVersion11SubOption(bool shouldSupport11)
        {
            ShouldSupport11 = shouldSupport11;
        }

        public bool ShouldSupport11 { get; }
    }
}