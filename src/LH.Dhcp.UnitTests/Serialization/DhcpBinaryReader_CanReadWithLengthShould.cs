using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_CanReadWithLengthShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReturnFalse_WhenAtEnd()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            reader.ReadValueToEnd();

            Assert.False(reader.CanRead(1));
        }

        [Fact]
        public void ReturnFalse_GivenLengthBeyondLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            reader.ReadValue(10);

            Assert.False(reader.CanRead(20));
        }

        [Fact]
        public void ReturnFalse_WhenAtLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 4);

            reader.ReadValue(4);

            Assert.False(reader.CanRead(1));
        }

        [Fact]
        public void ReturnTrue_WhenInMiddle_GivenOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.ReadValue(4);

            Assert.True(reader.CanRead(2));
        }

        [Fact]
        public void ReturnTrue_WhenOnStart_GivenNoOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            Assert.True(reader.CanRead(2));
        }

        [Fact]
        public void ReturnTrue_WhenOnStart_GivenOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            Assert.True(reader.CanRead(2));
        }
    }
}