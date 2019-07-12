using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_ReadUnsignedInt32Should
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReadUInt32()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            var read = reader.ReadUnsignedInt32();

            Assert.Equal(1122867U, read);
        }

        [Fact]
        public void ReadUInt16FromPassedOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 8);

            var read = reader.ReadUnsignedInt32();

            Assert.Equal(573785173U, read);
        }

        [Fact]
        public void ThrowIndexOutOfRange_WhenLessThanFourBytesRemain()
        {
            var reader = new DhcpBinaryReader(TestBytes, TestBytes.Length - 3, 3);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadUnsignedInt32());
        }

        [Fact]
        public void ThrowIndexOutOfRange_WhenLessThanTwoBytesRemainToLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 0, 3);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadUnsignedInt32());
        }
    }
}