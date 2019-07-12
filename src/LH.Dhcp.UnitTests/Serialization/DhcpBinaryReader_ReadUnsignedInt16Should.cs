using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_ReadUnsignedInt16Should
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReadUInt16()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            var read = reader.ReadUnsignedInt16();

            Assert.Equal(17, read);
        }

        [Fact]
        public void ReadUInt16FromPassedOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 8);

            var read = reader.ReadUnsignedInt16();

            Assert.Equal(8755, read);
        }

        [Fact]
        public void ThrowIndexOutOfRange_WhenLessThanTwoBytesRemain()
        {
            var reader = new DhcpBinaryReader(TestBytes, TestBytes.Length - 1, 1);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadUnsignedInt16());
        }

        [Fact]
        public void ThrowIndexOutOfRange_WhenLessThanTwoBytesRemainToLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 0, 1);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadUnsignedInt16());
        }
    }
}