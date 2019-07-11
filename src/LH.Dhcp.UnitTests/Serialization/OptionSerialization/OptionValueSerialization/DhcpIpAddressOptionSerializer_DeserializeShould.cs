using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpIpAddressOptionSerializer_DeserializeShould
    {
        private readonly DhcpIpAddressOptionSerializer _serializer;

        public DhcpIpAddressOptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpIpAddressOptionSerializer();
        }

        [Fact]
        public void DeserializeIpAddress()
        {
            var reader = new DhcpBinaryReader(new byte[] { 192, 168, 1, 1 });

            var actualIp = (IPAddress)_serializer.Deserialize(reader, 4);

            Assert.Equal(IPAddress.Parse("192.168.1.1"), actualIp);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(10)]
        public void ThrowDhcpParseException_GivenInvalidLength(byte length)
        {
            var reader = new DhcpBinaryReader(new byte[0]);

            Assert.Throws<DhcpSerializationException>(
                () => _serializer.Deserialize(reader, length));
        }
    }
}
