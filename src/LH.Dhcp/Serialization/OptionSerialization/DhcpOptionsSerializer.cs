using System.Collections.Generic;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionsSerializer
    {
        private readonly DhcpOptionTypeCatalog _optionTypeDescriptors;

        public DhcpOptionsSerializer()
        {
            _optionTypeDescriptors = new DhcpOptionTypeCatalog();
        }

        public IReadOnlyList<IDhcpOption> DeserializeOptions(DhcpBinaryReader binaryReader)
        {
            var options = new List<IDhcpOption>();
            var optionsTaggedCollection = binaryReader.ReadValueToEnd().AsTaggedValueCollection();

            foreach (var optionTaggedItem in optionsTaggedCollection)
            {
                var optionType = _optionTypeDescriptors.GetOptionType((DhcpOptionTypeCode) optionTaggedItem.Key);

                if (optionType == null)
                {
                    // Option not supported
                    continue;
                }

                var option = optionType.CreateOption(optionTaggedItem.Value);

                options.Add(option);
            }

            return options;
        }
    }
}