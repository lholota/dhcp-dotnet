using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_SeekShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void MoveByPassedOffsetForward()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.Seek(2);

            Assert.Equal(0x44, reader.ReadByte());
        }

        [Fact]
        public void MoveByPassedOffsetBackwards()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.ReadByte();
            reader.ReadByte();

            reader.Seek(-2);

            Assert.Equal(0x22, reader.ReadByte());
        }

        [Fact]
        public void ThrowIndexOutOfRangeException_WhenWouldMoveBeyondLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.ReadByte();
            reader.ReadByte();

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.Seek(-5));
        }

        [Fact]
        public void ThrowIndexOutOfRangeException_WhenWouldMoveBeyondByteArrayStart()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.ReadByte();
            reader.ReadByte();

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.Seek(-250));
        }

        [Fact]
        public void ThrowIndexOutOfRangeException_WhenWouldMoveBeyondInitialOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 4);
            
            Assert.Throws<IndexOutOfRangeException>(
                () => reader.Seek(-1));
        }

        [Fact]
        public void ThrowIndexOutOfRangeException_WhenWouldMoveBeyondByteArrayLength()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 4);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.Seek(250));
        }
    }
}