using LH.Dhcp.Serialization;

namespace LH.Dhcp.Options.VendorSpecificInformation
{
    public class MultiValueItem : UnknownValue
    {
        internal MultiValueItem(byte itemCode, DhcpBinaryReader reader) 
            : base(reader)
        {
            ItemCode = itemCode;
        }

        public byte ItemCode { get; }
    }
}