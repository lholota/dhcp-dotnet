using System.Collections.Generic;
using System.Linq;
using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpIpAddressListOptionSerializer_DeserializeShould
    {
        private readonly DhcpIpAddressListOptionSerializer _serializer;

        public DhcpIpAddressListOptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpIpAddressListOptionSerializer();
        }

        [Fact]
        public void DeserializeIpAddress()
        {
            var reader = new DhcpBinaryReader(new byte[] { 192, 168, 1, 1, 255, 255, 255, 12 });

            var actualIpList = (IEnumerable<IPAddress>)_serializer.Deserialize(reader, 8);

            Assert.Equal(IPAddress.Parse("192.168.1.1"), actualIpList.First());
            Assert.Equal(IPAddress.Parse("255.255.255.12"), actualIpList.Last());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(11)]
        [InlineData(13)]
        public void ThrowDhcpParseException_GivenInvalidLength(byte length)
        {
            var reader = new DhcpBinaryReader(new byte[0]);

            Assert.Throws<DhcpSerializationException>(
                () => _serializer.Deserialize(reader, length));
        }
    }
}
