using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpUnsignedInt32OptionSerializer_DeserializeShould
    {
        private readonly DhcpUnsignedInt32OptionSerializer _serializer;

        public DhcpUnsignedInt32OptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpUnsignedInt32OptionSerializer();
        }

        [Fact]
        public void DeserializeUnsignedInt32()
        {
            var reader = new DhcpBinaryReader(new byte[] { 0x00, 0x00, 0x00, 0x95 });

            var actual = (uint)_serializer.Deserialize(reader, 4);

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
