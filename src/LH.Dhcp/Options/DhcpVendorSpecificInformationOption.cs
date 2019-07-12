using System.Collections.Generic;

namespace LH.Dhcp.Options
{
    public class DhcpVendorSpecificInformationOption : IDhcpOption
    {
        public DhcpVendorSpecificInformationOption(VendorSpecificInformationValue singleValue)
        {
            IsSingleValue = true;
            SingleValue = singleValue;
        }

        public DhcpVendorSpecificInformationOption(IReadOnlyDictionary<int, VendorSpecificInformationValue> multiValue)
        {
            IsSingleValue = false;
            MultiValue = multiValue;
        }

        internal DhcpVendorSpecificInformationOption(
            VendorSpecificInformationValue singleValue,
            IReadOnlyDictionary<int, VendorSpecificInformationValue> multiValue) // TODO: Wrap with an internal class
        {
            
        }

        public bool IsSingleValue { get; }

        public VendorSpecificInformationValue SingleValue { get; }

        public IReadOnlyDictionary<int, VendorSpecificInformationValue> MultiValue { get; }
    }

    public class VendorSpecificInformationValue
    {

    }
}