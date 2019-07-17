using System;
using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_PeekByte
    {
        [Fact]
        public void ReturnNextByte()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x03 };
            var reader = new DhcpBinaryReader(bytes);

            Assert.Equal(0x01, reader.PeekByte());
        }

        [Fact]
        public void ThrowInvalidOperationException_WhenAtEndOfBytes()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x03 };
            var reader = new DhcpBinaryReader(bytes);

            reader.ReadValueToEnd();

            Assert.Throws<InvalidOperationException>(
                () => reader.PeekByte());
        }
    }
}
