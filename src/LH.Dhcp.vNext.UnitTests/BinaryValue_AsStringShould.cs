using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class BinaryValue_AsStringShould
    {
        [Fact]
        public void ReturnAsciiRepresentationOfBytes()
        {
            var bytes = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f };
            var valueReader = new BinaryValue(bytes, 0, bytes.Length);

            Assert.Equal("Hello", valueReader.AsString());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var bytes = new byte[] { 0x00, 0x00, 0x00, 0x48, 0x65, 0x6c, 0x6c, 0x6f };
            var valueReader = new BinaryValue(bytes, 3, 5);

            Assert.Equal("Hello", valueReader.AsString());
        }

        [Fact]
        public void TrimZeroTerminationCharacters()
        {
            var bytes = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x00, 0x00, 0x00 };
            var valueReader = new BinaryValue(bytes, 0, bytes.Length);

            Assert.Equal("Hello", valueReader.AsString());
        }
    }
}