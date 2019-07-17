using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValue_AsUnsignedInt16Should
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(TestBytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsUnsignedInt16());
        }

        [Fact]
        public void ReturnValue_GivenValidLength()
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 0, 2);

            Assert.Equal(17, valueReader.AsUnsignedInt16());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 2, 2);

            Assert.Equal(8755, valueReader.AsUnsignedInt16());
        }
    }
}