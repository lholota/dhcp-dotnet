using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MaskDiscovery)]
    public class DhcpPerformMaskDiscoveryOption : IDhcpOption
    {
        public DhcpPerformMaskDiscoveryOption(bool performMaskDiscovery)
        {
            PerformMaskDiscovery = performMaskDiscovery;
        }

        public bool PerformMaskDiscovery { get; }
    }
}