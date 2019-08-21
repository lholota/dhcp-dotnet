using System;
using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryValue_CreateSubsetValueShould
    {
        private static readonly byte[] Bytes = { 0x01, 0x02, 0x03, 0x04, 0x05 };

        [Fact]
        public void ReturnSubSetValue()
        {
            var binaryValue = new DhcpBinaryValue(Bytes, 0, Bytes.Length);

            var subsetValue = binaryValue.CreateSubsetValue(2, 2);
            var expectedValue = new byte[] { 0x03, 0x04 };

            Assert.Equal(expectedValue, subsetValue.AsBytes());
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-5)]
        public void ThrowArgumentOutOfRange_GivenNegativeOffset(int offset)
        {
            var binaryValue = new DhcpBinaryValue(Bytes, 0, Bytes.Length);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => binaryValue.CreateSubsetValue(offset, 2));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void ThrowArgumentOutOfRange_GivenOffsetExceedingLength(int offset)
        {
            var binaryValue = new DhcpBinaryValue(Bytes, 0, Bytes.Length);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => binaryValue.CreateSubsetValue(offset, 2));
        }

        [Theory]
        [InlineData(10)]
        [InlineData(50)]
        public void ThrowArgumentOutOfRange_GivenLengthExceedingDataLength(int length)
        {
            var binaryValue = new DhcpBinaryValue(Bytes, 0, Bytes.Length);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => binaryValue.CreateSubsetValue(0, length));
        }

        [Fact]
        public void ThrowArgumentOutOfRange_GivenOffsetAndLengthExceedingLimit()
        {
            var binaryValue = new DhcpBinaryValue(Bytes, 0, 3);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => binaryValue.CreateSubsetValue(2, 2));
        }
    }
}