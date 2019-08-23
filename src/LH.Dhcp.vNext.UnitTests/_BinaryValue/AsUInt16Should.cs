using System;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    
    public class AsUInt16Should
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var valueReader = new BinaryValue(TestBytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsUInt16());
        }

        [Fact]
        public void ReturnValue_GivenValidLength()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 2);

            Assert.Equal(17, valueReader.AsUInt16());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new BinaryValue(TestBytes, 2, 2);

            Assert.Equal(8755, valueReader.AsUInt16());
        }
    }
}