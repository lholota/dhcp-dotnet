using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpInt32OptionSerializer_DeserializeShould
    {
        private readonly DhcpInt32OptionSerializer _serializer;

        public DhcpInt32OptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpInt32OptionSerializer();
        }

        [Fact]
        public void DeserializeInt32()
        {
            var reader = new DhcpBinaryReader(new byte[] { 0xff, 0xff, 0xfd, 0xa8 });

            var actual = (int)_serializer.Deserialize(reader, 4);

            Assert.Equal(-600, actual);
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