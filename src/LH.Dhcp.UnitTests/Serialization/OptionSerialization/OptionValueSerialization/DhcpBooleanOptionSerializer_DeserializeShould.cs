using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBooleanOptionSerializer_DeserializeShould
    {
        private readonly DhcpBooleanOptionSerializer _serializer;

        public DhcpBooleanOptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpBooleanOptionSerializer();
        }

        [Theory]
        [InlineData(0x00, false)]
        [InlineData(0x01, true)]
        public void DeserializeBoolean(byte byteValue, bool expectedValue)
        {
            var reader = new DhcpBinaryReader(new[] { byteValue });

            var actual = (bool)_serializer.Deserialize(reader, 1);

            Assert.Equal(expectedValue, actual);
        }

        [Theory]
        [InlineData(0)]
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