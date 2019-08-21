using System;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    
    public class AsUInt32Should
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new BinaryValue(bytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsUInt32());
        }

        [Fact]
        public void ReturnValue_GivenValidLength()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 4);

            Assert.Equal(1122867U, valueReader.AsUInt32());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new BinaryValue(TestBytes, 2, 4);

            Assert.Equal(573785173U, valueReader.AsUInt32());
        }
    }
}