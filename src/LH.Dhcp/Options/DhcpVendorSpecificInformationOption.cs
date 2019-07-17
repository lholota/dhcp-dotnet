using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.VendorSpecific)]
    public class DhcpVendorSpecificInformationOption : IDhcpOption
    {
        // TODO: Add builder to create the option

        [CreateOptionConstructor]
        internal DhcpVendorSpecificInformationOption(IBinaryValue value)
        {
            Value = value;
        }

        public IBinaryValue Value { get; }
    }
}