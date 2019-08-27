using System;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._ClientHardwareAddress
{
    public class CtorShould
    {
        [Fact]
        public void ThrowArgumentNullException_GivenNullBytes()
        {
            Assert.Throws<ArgumentNullException>(
                () => new ClientHardwareAddress(ClientHardwareAddressType.ARPSec, null));
        }

        [Fact]
        public void ThrowArgumentException_GivenBytesLongerThan16Bytes()
        {
            Assert.Throws<ArgumentException>(
                () => new ClientHardwareAddress(ClientHardwareAddressType.ARPSec, new byte[17]));
        }

        [Fact]
        public void ThrowArgumentException_GivenEmptyBytes()
        {
            Assert.Throws<ArgumentException>(
                () => new ClientHardwareAddress(ClientHardwareAddressType.ARPSec, new byte[0]));
        }

        [Theory]
        [InlineData(5)]
        [InlineData(7)]
        [InlineData(9)]
        public void ThrowArgumentException_GivenEthernetTypeAndBytesOfInvalidLength(int length)
        {
            var ex = Assert.Throws<ArgumentException>(
                () => new ClientHardwareAddress(ClientHardwareAddressType.Ethernet, new byte[length]));

            Assert.Contains("Ethernet", ex.Message);
        }
    }
}
