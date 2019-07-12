using System;
using System.Text;
using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_ReadStringShould
    {
        private static readonly string TestString = "0123456789abcdef";
        private static readonly byte[] TestBytes = Encoding.ASCII.GetBytes(TestString);

        [Fact]
        public void ReadString()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            var readString = reader.ReadString(TestBytes.Length);

            Assert.Equal(TestString, readString);
        }

        [Fact]
        public void ReadStringFromPassedOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 8);

            var readString = reader.ReadString(5);

            Assert.Equal("23456", readString);
        }

        [Fact]
        public void ThrowIndexOutOfRange_GivenLengthBeyondLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 8);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadString(9));
        }

        [Fact]
        public void ThrowIndexOutOfRange_GivenLengthBeyondByteArrayLength()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadString(30));
        }
    }
}