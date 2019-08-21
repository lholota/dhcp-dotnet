using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryValue_AsInt32Should
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsInt32());
        }

        [Fact]
        public void ReturnValue_GivenValidLength()
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 0, 4);

            Assert.Equal(1122867, valueReader.AsInt32());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 2, 4);

            Assert.Equal(573785173, valueReader.AsInt32());
        }
    }
}