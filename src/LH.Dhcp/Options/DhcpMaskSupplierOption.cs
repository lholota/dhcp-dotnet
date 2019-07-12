using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.MaskSupplier, typeof(DhcpBooleanOptionSerializer))]
    public class DhcpMaskSupplierOption : IDhcpOption
    {
        public DhcpMaskSupplierOption(bool isMaskSupplier)
        {
            IsMaskSupplier = isMaskSupplier;
        }

        public bool IsMaskSupplier { get; }
    }
}