using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValueReader_AsStringShould
    {
        [Fact]
        public void ReturnAsciiRepresentationOfBytes()
        {
            var bytes = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f };
            var valueReader = new DhcpBinaryValueReader(bytes, 0, bytes.Length);

            Assert.Equal("Hello", valueReader.AsString());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var bytes = new byte[] { 0x00, 0x00, 0x00, 0x48, 0x65, 0x6c, 0x6c, 0x6f };
            var valueReader = new DhcpBinaryValueReader(bytes, 2, bytes.Length);

            Assert.Equal("Hello", valueReader.AsString());
        }
    }
}