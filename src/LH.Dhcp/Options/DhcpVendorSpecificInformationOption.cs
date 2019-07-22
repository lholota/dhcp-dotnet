using System;
using System.Collections.Generic;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.VendorSpecific)]
    public class DhcpVendorSpecificInformationOption : IDhcpOption
    {
        [CreateOptionConstructor]
        internal DhcpVendorSpecificInformationOption(IBinaryValue value)
        {
            Value = value;
        }

        public DhcpVendorSpecificInformationOption()
        {

        }

        public IBinaryValue Value { get; }
    }

    public class DhcpVendorSpecificInformationOptionBuilder
    {
        public static DhcpVendorSpecificInformationOptionBuilder Create()
        {
            return new DhcpVendorSpecificInformationOptionBuilder();
        }

        private readonly IDictionary<byte, object> _values;

        private DhcpVendorSpecificInformationOptionBuilder()
        {
            _values = new Dictionary<byte, object>();
        }

        public DhcpVendorSpecificInformationOption Build()
        {
            throw new NotImplementedException();
        }
    }
}