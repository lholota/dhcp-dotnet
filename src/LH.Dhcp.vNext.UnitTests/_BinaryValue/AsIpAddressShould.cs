using System;
using System.Net;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    
    public class AsIpAddressShould
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
                () => valueReader.AsIpAddress());
        }

        [Fact]
        public void ReturnValue_GivenValidLength()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 4);

            Assert.Equal(IPAddress.Parse("0.17.34.51"), valueReader.AsIpAddress());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new BinaryValue(TestBytes, 2, 4);

            Assert.Equal(IPAddress.Parse("34.51.68.85"), valueReader.AsIpAddress());
        }
    }
}