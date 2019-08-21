using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryReader_ReadValueShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReadValueOfGivenLength()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            var valueBytes = reader.ReadValue(3).AsBytes();

            Assert.Equal(3, valueBytes.Length);
        }

        [Fact]
        public void ReadValueFromCurrentOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            reader.ReadValue(2);

            Assert.Equal(0x22, reader.ReadValue(1).AsByte());
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(0)]
        public void ThrowArgumentOutOfRangeException_GivenZeroOrNegativeLength(int length)
        {
            var reader = new DhcpBinaryReader(TestBytes);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => reader.ReadValue(length));
        }

        [Fact]
        public void ThrowInvalidOperationException_GivenLengthBeyondDataLength()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            Assert.Throws<InvalidOperationException>(
                () => reader.ReadValue(50));
        }
    }
}
