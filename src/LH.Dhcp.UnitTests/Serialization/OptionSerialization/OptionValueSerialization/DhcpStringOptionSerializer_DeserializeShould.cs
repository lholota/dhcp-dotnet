using System.Net;
using System.Text;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization.OptionValueSerialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization.OptionSerialization.OptionValueSerialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpStringOptionSerializer_DeserializeShould
    {
        private readonly DhcpStringOptionSerializer _serializer;

        public DhcpStringOptionSerializer_DeserializeShould()
        {
            _serializer = new DhcpStringOptionSerializer();
        }

        [Fact]
        public void ReturnStringOfGivenLength()
        {
            var reader = new DhcpBinaryReader(Encoding.ASCII.GetBytes("Hello"));

            var actual = (string)_serializer.Deserialize(reader, 5);

            Assert.Equal("Hello", actual);
        }

        [Fact]
        public void TrimZeroTerminationCharacters()
        {
            var reader = new DhcpBinaryReader(Encoding.ASCII.GetBytes("Hello\0\0"));

            var actual = (string)_serializer.Deserialize(reader, 7);

            Assert.Equal("Hello", actual);
        }
    }
}