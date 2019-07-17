using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_ReadValueToEndShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReadAllRemainingData()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            reader.ReadValue(10);

            var valueBytes = reader.ReadValueToEnd().AsBytes();

            Assert.Equal(0xaa, valueBytes[0]);
            Assert.Equal(0xbb, valueBytes[1]);
            Assert.Equal(0xcc, valueBytes[2]);
            Assert.Equal(0xdd, valueBytes[3]);
            Assert.Equal(0xee, valueBytes[4]);
            Assert.Equal(0xff, valueBytes[5]);
        }

        [Fact]
        public void ReadFromCurrentOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            reader.ReadValue(2);

            Assert.Equal(14, reader.ReadValueToEnd().AsBytes().Length);
        }

        [Fact]
        public void ThrowInvalidOperationException_WhenReaderCannotRead()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            reader.ReadValue(TestBytes.Length);

            Assert.Throws<InvalidOperationException>(
                () => reader.ReadValueToEnd());
        }
    }
}