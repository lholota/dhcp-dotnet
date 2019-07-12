using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_CreateSubsetReaderShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void CreateReaderFromCurrentOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 10);

            reader.ReadByte();
            reader.ReadByte();

            var subsetReader = reader.CreateSubsetReader(5);

            Assert.Equal(0x44, subsetReader.ReadByte());
        }

        [Fact]
        public void ThrowIndexOutOfRange_GivenLengthBeyondLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 8);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.CreateSubsetReader(9));
        }

        [Fact]
        public void ThrowIndexOutOfRange_GivenLengthBeyondByteArrayLength()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.CreateSubsetReader(30));
        }
    }
}