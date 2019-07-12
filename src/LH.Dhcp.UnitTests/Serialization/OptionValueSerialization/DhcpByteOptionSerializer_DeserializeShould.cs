using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpByteOptionSerializer_DeserializeShould
    {
        private readonly DhcpByteOptionSerializer _serializer;

        public DhcpByteOptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpByteOptionSerializer();
        }

        [Fact]
        public void DeserializeByte()
        {
            var reader = new DhcpBinaryReader(new byte[] { 0x0e });

            var actual = (byte)_serializer.Deserialize(reader, 1);

            Assert.Equal(0x0e, actual);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(10)]
        public void ThrowDhcpParseException_GivenInvalidLength(byte length)
        {
            var reader = new DhcpBinaryReader(new byte[0]);

            Assert.Throws<DhcpSerializationException>(
                () => _serializer.Deserialize(reader, length));
        }
    }
}