using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MaskDiscovery, typeof(DhcpBooleanOptionSerializer))]
    public class DhcpPerformMaskDiscoveryOption : IDhcpOption
    {
        public DhcpPerformMaskDiscoveryOption(bool performMaskDiscovery)
        {
            PerformMaskDiscovery = performMaskDiscovery;
        }

        public bool PerformMaskDiscovery { get; }
    }
}