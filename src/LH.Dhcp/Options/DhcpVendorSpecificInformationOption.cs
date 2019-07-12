using LH.Dhcp.Options.VendorSpecificInformation;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.VendorSpecific, typeof(DhcpByteArrayOptionSerializer))]
    public class DhcpVendorSpecificInformationOption : IDhcpOption
    {
        private readonly DhcpBinaryReader _reader;

        public DhcpVendorSpecificInformationOption(byte[] bytes)
        {
            _reader = new DhcpBinaryReader(bytes);
        }

        internal DhcpVendorSpecificInformationOption(DhcpBinaryReader reader)
        {
            _reader = reader;
        }

        public UnknownValue CreateSingleValueReader()
        {
            return new UnknownValue(_reader.Clone());
        }

        public MultiValueReader CreateMultiValueReader()
        {
            // MultiValue reader -> move option by option, pass a delegate

            return new MultiValueReader(_reader.Clone());
        }
    }
}