using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_ReadInt32Should
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReadInt32()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            var read = reader.ReadInt32();

            Assert.Equal(1122867, read);
        }

        [Fact]
        public void ReadUInt16FromPassedOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 8);

            var read = reader.ReadInt32();

            Assert.Equal(573785173, read);
        }

        [Fact]
        public void ThrowIndexOutOfRange_WhenLessThanFourBytesRemain()
        {
            var reader = new DhcpBinaryReader(TestBytes, TestBytes.Length - 3, 3);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadInt32());
        }

        [Fact]
        public void ThrowIndexOutOfRange_WhenLessThanTwoBytesRemainToLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 0, 3);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadInt32());
        }
    }
}