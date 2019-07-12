using System;
using System.Linq;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_ReadByteShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ThrowIndexOutOfRangeException_WhenTryingToReadBeyondLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 2);

            reader.ReadByte();
            reader.ReadByte();

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadByte());
        }

        [Fact]
        public void StartReadingAtPassedOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 1, 10);

            var readByte = reader.ReadByte();

            Assert.Equal(0x11, readByte);
        }

        [Fact]
        public void StartReadingFromBeginning_WhenOffsetNotSpecified()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            var readByte = reader.ReadByte();

            Assert.Equal(0x00, readByte);
        }

        [Fact]
        public void ReadingToEndOfByteArray_WhenLimitNotSpecified()
        {
            var reader = new DhcpBinaryReader(TestBytes);
            var readBytes = new byte[TestBytes.Length];

            for (int i = 0; i < TestBytes.Length; i++)
            {
                readBytes[i] = reader.ReadByte();
            }

            Assert.Equal(TestBytes, readBytes);
        }
    }
}