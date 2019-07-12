using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_CanReadWithLenthShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReturnFalse_WhenAtEnd()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            reader.ReadBytes(TestBytes.Length);

            Assert.False(reader.CanRead(2));
        }

        [Fact]
        public void ReturnFalse_WhenAtLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 4);

            reader.ReadBytes(4);

            Assert.False(reader.CanRead(2));
        }

        [Fact]
        public void ReturnFalse_GivenLengthBeyondLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            reader.ReadBytes(2);

            Assert.False(reader.CanRead(30));
        }

        [Fact]
        public void ReturnFalse_GivenOffset_GivenLengthBeyondLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 4);

            reader.ReadBytes(2);

            Assert.False(reader.CanRead(3));
        }

        [Fact]
        public void ReturnTrue_WhenInMiddle_GivenOffset_GivenLengthWithinLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.ReadBytes(4);

            Assert.True(reader.CanRead(2));
        }

        [Fact]
        public void ReturnTrue_WhenInMiddle_GivenNoOffset_GivenLengthWithinLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            reader.ReadBytes(4);

            Assert.True(reader.CanRead(8));
        }
    }
}