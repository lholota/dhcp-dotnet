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

            Assert.Equal(0x44, reader.ReadValue(1).AsByte());
        }

        [Fact]
        public void MoveByPassedOffsetBackwards()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.ReadValue(2);

            reader.Seek(-2);

            Assert.Equal(0x22, reader.ReadValue(1).AsByte());
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenWouldMoveBeyondLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.ReadValue(2);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => reader.Seek(-5));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenWouldMoveBeyondByteArrayStart()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.ReadValue(2);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => reader.Seek(-250));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenWouldMoveBeyondInitialOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 4);
            
            Assert.Throws<ArgumentOutOfRangeException>(
                () => reader.Seek(-1));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_WhenWouldMoveBeyondByteArrayLength()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 4);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => reader.Seek(250));
        }
    }
}