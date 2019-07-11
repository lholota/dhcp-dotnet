using System.Linq;
using System.Net;
using LH.Dhcp.Options;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.DhcpOptionSerializerTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpOptionSerializer_DeserializeOptionsShould
    {
        private readonly DhcpOptionsSerializer _optionsSerializer;

        public DhcpOptionSerializer_DeserializeOptionsShould()
        {
            _optionsSerializer = new DhcpOptionsSerializer();
        }

        [Fact]
        public void SkipUnsupportedOptions()
        {
            var packetBytes = new byte[]
            {
                (byte)DhcpOptionTypeCode.Etherboot,
                2, // length
                1, // If the serializer does not skip this byte, it would try to parse it as a SubnetMask
                0,
                0,
                (byte)DhcpOptionTypeCode.End
            };

            var reader = new DhcpBinaryReader(packetBytes);

            _optionsSerializer.DeserializeOptions(reader);

            Assert.False(reader.CanRead());
        }

        [Fact]
        public void SkipPadOption()
        {
            var packetBytes = new byte[]
            {
                (byte)DhcpOptionTypeCode.Pad,
                (byte)DhcpOptionTypeCode.SubnetMask,
                4, // length
                255, // If the serializer does not skip this byte, it would try to parse it as a SubnetMask
                255,
                255,
                0,
                (byte)DhcpOptionTypeCode.End
            };

            var reader = new DhcpBinaryReader(packetBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            Assert.IsType<DhcpSubnetMaskOption>(options.Single());
        }

        [Fact]
        public void DeserializeSubnetMaskOption()
        {
            var packetBytes = new byte[]
            {
                (byte)DhcpOptionTypeCode.SubnetMask,
                4, // length
                255,
                255,
                255,
                192,
                (byte)DhcpOptionTypeCode.End
            };

            var reader = new DhcpBinaryReader(packetBytes);

            var options = _optionsSerializer.DeserializeOptions(reader);

            var subnetMaskOption = options.OfType<DhcpSubnetMaskOption>().Single();

            Assert.Equal(IPAddress.Parse("255.255.255.192"), subnetMaskOption.SubnetMask);
        }
    }
}