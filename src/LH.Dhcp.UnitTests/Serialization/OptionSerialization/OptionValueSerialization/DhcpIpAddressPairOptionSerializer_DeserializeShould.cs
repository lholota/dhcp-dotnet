using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpIpAddressPairOptionSerializer_DeserializeShould
    {
        private readonly DhcpIpAddressPairOptionSerializer _serializer;

        public DhcpIpAddressPairOptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpIpAddressPairOptionSerializer();
        }

        [Fact]
        public void DeserializeIpAddressPairs()
        {
            var reader = new DhcpBinaryReader(new byte[] { 192, 168, 1, 1, 255, 255, 255, 0, 192, 168, 100, 100, 255, 255, 192, 0 });

            var pairs = (IEnumerable<Tuple<IPAddress, IPAddress>>)_serializer.Deserialize(reader, 16);

            Assert.Equal(IPAddress.Parse("192.168.1.1"), pairs.First().Item1);
            Assert.Equal(IPAddress.Parse("255.255.255.0"), pairs.First().Item2);
            Assert.Equal(IPAddress.Parse("192.168.100.100"), pairs.Last().Item1);
            Assert.Equal(IPAddress.Parse("255.255.192.0"), pairs.Last().Item2);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(12)]
        [InlineData(25)]
        public void ThrowDhcpSerializationException_GivenInvalidLength(byte length)
        {
            var reader = new DhcpBinaryReader(new byte[0]);

            Assert.Throws<DhcpSerializationException>(
                () => _serializer.Deserialize(reader, length));
        }
    }
}
