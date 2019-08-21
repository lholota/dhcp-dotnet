using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryValue_AsByteShould
    {
        private static readonly byte[] TestBytes = "112233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(bytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsByte());
        }

        [Fact]
        public void ReturnValue_GivenValidLength()
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 0, 1);

            Assert.Equal(0x11, valueReader.AsByte());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 2, 1);

            Assert.Equal(0x33, valueReader.AsByte());
        }
    }
}
