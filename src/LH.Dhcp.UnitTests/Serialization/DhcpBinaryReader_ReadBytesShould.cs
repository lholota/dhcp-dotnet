using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_ReadBytesShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReadBytes()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            var readBytes = reader.ReadBytes(TestBytes.Length);

            Assert.Equal(TestBytes, readBytes);
        }

        [Fact]
        public void ReadBytesFromPassedOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 8);

            var readBytes = reader.ReadBytes(5);

            Assert.Equal("2233445566".AsHexBytes(), readBytes);
        }

        [Fact]
        public void ThrowIndexOutOfRange_GivenLengthBeyondLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 8);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadBytes(9));
        }

        [Fact]
        public void ThrowIndexOutOfRange_GivenLengthBeyondByteArrayLength()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadBytes(30));
        }
    }
}