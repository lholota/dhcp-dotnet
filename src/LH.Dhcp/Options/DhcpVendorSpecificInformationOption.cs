using System;
using System.Collections.Generic;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.VendorSpecific)]
    public class DhcpVendorSpecificInformationOption : IDhcpOption
    {
        public DhcpVendorSpecificInformationOption(object singleValue)
        {
            SingleValue = null;
            CanBeInterpretedAsMultiValue = true;

            throw new NotImplementedException();
        }

        public DhcpVendorSpecificInformationOption(IDictionary<int, object> multiValue)
        {
            SingleValue = null;
            CanBeInterpretedAsMultiValue = true;

            throw new NotImplementedException();
        }

        [CreateOptionConstructor]
        internal DhcpVendorSpecificInformationOption(DhcpBinaryValueReader valueReader)
        {
            SingleValue = valueReader;

            if (valueReader.IsValidValueCollection())
            {
                CanBeInterpretedAsMultiValue = true;
                MultiValue = valueReader.AsNestedValueCollection();
            }
            else
            {
                CanBeInterpretedAsMultiValue = false;
            }
        }

        // TODO: Expose as interface
        public IValueReader SingleValue { get; }

        public bool CanBeInterpretedAsMultiValue { get; }

        // TODO: Throw if cannot be interpreted
        public IReadOnlyDictionary<int, IValueReader> MultiValue { get; }
    }
}