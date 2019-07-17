using System.Collections.Generic;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionsSerializer
    {
        private readonly DhcpOptionTypeDescriptorsCollection _optionTypeDescriptors;

        public DhcpOptionsSerializer()
        {
            _optionTypeDescriptors = new DhcpOptionTypeDescriptorsCollection();
        }

        public IReadOnlyList<IDhcpOption> DeserializeOptions(DhcpBinaryReader binaryReader)
        {
            var options = new List<IDhcpOption>();
            var optionsTaggedCollection = binaryReader.ReadValueToEnd().AsTaggedValueCollection();

            foreach (var optionTaggedItem in optionsTaggedCollection)
            {
                var descriptor = _optionTypeDescriptors.GetDescriptor((DhcpOptionTypeCode) optionTaggedItem.Key);

                if (descriptor == null)
                {
                    // Option not supported
                    continue;
                }

                object optionValue;

                if (descriptor.OptionValueType == typeof(IBinaryValue))
                {
                    optionValue = optionTaggedItem.Value;
                }
                else
                {
                    optionValue = optionTaggedItem.Value.As(descriptor.OptionValueType);
                }

                var option = CreateOption(descriptor, optionValue);

                options.Add(option);
            }

            return options;
        }

        private IDhcpOption CreateOption(DhcpOptionTypeDescriptor descriptor, object optionValue)
        {
            return (IDhcpOption)descriptor.Constructor.Invoke(new[]{ optionValue });
        }
    }
}