using System;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    public class AsInt16Should
    {
        private static readonly byte[] TestBytes = "a011a233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var valueReader = new BinaryValue(TestBytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsInt16());
        }

        [Fact]
        public void ReturnValue_GivenValidLength()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 2);

            Assert.Equal(-24559, valueReader.AsInt16());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new BinaryValue(TestBytes, 2, 2);

            Assert.Equal(-24013, valueReader.AsInt16());
        }
    }
}