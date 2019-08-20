using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionCode.MaskSupplier)]
    public class DhcpMaskSupplierOption : IDhcpOption
    {
        public DhcpMaskSupplierOption(bool isMaskSupplier)
        {
            IsMaskSupplier = isMaskSupplier;
        }

        public bool IsMaskSupplier { get; }
    }
}