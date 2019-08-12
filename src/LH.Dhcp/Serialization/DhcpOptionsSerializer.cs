using System.Collections.Generic;
using LH.Dhcp.Options;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Serialization
{
    internal class DhcpOptionsSerializer
    {
        private readonly DhcpOptionTypeDescriptorsCollection _optionTypeDescriptors;

        public DhcpOptionsSerializer()
        {
            _optionTypeDescriptors = new DhcpOptionTypeDescriptorsCollection();
        }

        public IDictionary<byte, BinaryValue> DeserializeOptions(DhcpBinaryReader binaryReader, BinaryValue overloadedFieldsValue)
        {
            var options = binaryReader.ReadValueToEnd().AsTaggedValueCollection();

            if (options.TryGetValue((byte) DhcpOptionTypeCode.Overload, out var overloadMode))
            {
                switch (overloadMode.AsByte())
                {
                    case 1:
                        break;

                    case 2:
                        break;

                    case 3:
                        break;
                }

                var optionsInOverloadedFields = ov
            }

            return options;

            //foreach (var optionTaggedItem in optionsTaggedCollection)
            //{
            //    var descriptor = _optionTypeDescriptors.GetDescriptor((DhcpOptionTypeCode) optionTaggedItem.Key);

            //    if (descriptor == null)
            //    {
            //        // Option not supported
            //        continue;
            //    }

            //    object optionValue;

            //    if (descriptor.OptionValueType.IsAssignableFrom(typeof(BinaryValue)))
            //    {
            //        optionValue = optionTaggedItem.Value;
            //    }
            //    else
            //    {
            //        optionValue = optionTaggedItem.Value.As(descriptor.OptionValueType);
            //    }

            //    // TODO: To RAW Options
            //    // TODO: Merge long options
            //    // TODO: Check for overload

            //    var option = CreateOption(descriptor, optionValue);

            //    options.Add(option);
            //}

            //return options;
        }

        private IDhcpOption CreateOption(DhcpOptionTypeDescriptor descriptor, object optionValue)
        {
            return (IDhcpOption)descriptor.Constructor.Invoke(new[]{ optionValue });
        }
    }
}