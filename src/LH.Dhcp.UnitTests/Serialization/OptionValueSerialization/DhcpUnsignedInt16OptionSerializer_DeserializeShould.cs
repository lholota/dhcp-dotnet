using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpUnsignedInt16OptionSerializer_DeserializeShould
    {
        private readonly DhcpUnsignedInt16OptionSerializer _serializer;

        public DhcpUnsignedInt16OptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpUnsignedInt16OptionSerializer();
        }

        [Fact]
        public void DeserializeUnsignedInt16()
        {
            var reader = new DhcpBinaryReader(new byte[] { 0x00, 0x95 });

            var actual = (ushort)_serializer.Deserialize(reader, 2);

            Assert.Equal(149U, actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(10)]
        public void ThrowDhcpSerializationException_GivenInvalidLength(byte length)
        {
            var reader = new DhcpBinaryReader(new byte[0]);

            Assert.Throws<DhcpSerializationException>(
                () => _serializer.Deserialize(reader, length));
        }
    }
}
