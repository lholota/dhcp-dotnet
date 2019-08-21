using System;
using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacket_ClientHardwareAddressShould
    {
        [Theory]
        [ClassData(typeof(DhcpTestPackets))]
        public void ReturnClientHardwareAddress(DhcpTestPacket testPacket)
        {
            var packet = new DhcpPacket(testPacket.Bytes);

            Assert.Equal(testPacket.ClientHardwareAddressType, packet.ClientHardwareAddress.Type);
            Assert.Equal(testPacket.ClientHardwareAddressBytes, packet.ClientHardwareAddress.AddressBytes);
        }

        [Fact]
        public void NotCreateNewInstanceOnEveryAccess()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            var address1 = packet.ClientHardwareAddress;
            var address2 = packet.ClientHardwareAddress;

            Assert.Same(address1, address2);
        }

        [Theory]
        [InlineData(17)]
        [InlineData(50)]
        public void ThrowFormatException_GivenPacketWithInvalidAddressLength(byte length)
        {
            var bytes = new byte[250];

            bytes[2] = length;

            Assert.Throws<FormatException>(
                () => new DhcpPacket(bytes));
        }
    }
}