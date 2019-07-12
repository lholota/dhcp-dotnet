using System.Collections.Generic;
using System.Linq;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpUnsignedInt16ListOptionSerializer_DeserializeShould
    {
        private readonly DhcpUnsignedInt16ListOptionSerializer _serializer;

        public DhcpUnsignedInt16ListOptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpUnsignedInt16ListOptionSerializer();
        }

        [Fact]
        public void DeserializeUnsignedInt16()
        {
            var reader = new DhcpBinaryReader(new byte[] { 0x00, 0x95, 0x00, 0x97 });

            var actual = (IEnumerable<ushort>)_serializer.Deserialize(reader, 4);

            Assert.Equal(149U, actual.First());
            Assert.Equal(151U, actual.Last());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(11)]
        public void ThrowDhcpSerializationException_GivenInvalidLength(byte length)
        {
            var reader = new DhcpBinaryReader(new byte[0]);

            Assert.Throws<DhcpSerializationException>(
                () => _serializer.Deserialize(reader, length));
        }
    }
}