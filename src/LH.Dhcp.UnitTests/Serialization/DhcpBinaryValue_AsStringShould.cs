using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValue_AsStringShould
    {
        [Fact]
        public void ReturnAsciiRepresentationOfBytes()
        {
            var bytes = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f };
            var valueReader = new DhcpBinaryValue(bytes, 0, bytes.Length);

            Assert.Equal("Hello", valueReader.AsString());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var bytes = new byte[] { 0x00, 0x00, 0x00, 0x48, 0x65, 0x6c, 0x6c, 0x6f };
            var valueReader = new DhcpBinaryValue(bytes, 3, 5);

            Assert.Equal("Hello", valueReader.AsString());
        }

        [Fact]
        public void TrimZeroTerminationCharacters()
        {
            var bytes = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x00, 0x00, 0x00 };
            var valueReader = new DhcpBinaryValue(bytes, 0, bytes.Length);

            Assert.Equal("Hello", valueReader.AsString());
        }
    }
}