using System;
using System.Linq;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.Options;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithClientHardwareAddressShould
    {
        [Fact]
        public void SetClientHardwareAddress()
        {
            var address = new ClientHardwareAddress(
                ClientHardwareAddressType.ARCNET,
                new byte[] { 0x0a, 0x0b });
            
            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithClientHardwareAddress(address)
                .Build();

            Assert.Equal(address.Type, packet.ClientHardwareAddress.Type);
            Assert.Equal(address.AddressBytes, packet.ClientHardwareAddress.AddressBytes);
        }

        [Fact]
        public void UpdateExistingValue()
        {
            var address1 = new ClientHardwareAddress(
                ClientHardwareAddressType.ARCNET,
                new byte[16].SetTo(0xaa));

            var address2 = new ClientHardwareAddress(
                ClientHardwareAddressType.ARPSec,
                new byte[2].SetTo(0xbb));

            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithClientHardwareAddress(address1)
                .WithClientHardwareAddress(address2)
                .Build();

            Assert.Equal(address2.Type, packet.ClientHardwareAddress.Type);
            Assert.Equal(address2.AddressBytes, packet.ClientHardwareAddress.AddressBytes);
        }

        [Fact]
        public void ResetRemainingBytes()
        {
            var address1 = new ClientHardwareAddress(
                ClientHardwareAddressType.ARCNET,
                new byte[16].SetTo(0xaa));

            var address2 = new ClientHardwareAddress(
                ClientHardwareAddressType.ARPSec,
                new byte[2].SetTo(0xbb));

            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithClientHardwareAddress(address1)
                .WithClientHardwareAddress(address2)
                .Build();

            var actualAddressBytes = new byte[16];

            Array.Copy(
                packet.RawBytes.ToArray(), 
                DhcpConstants.ClientHardwareAddressBytesOffset, 
                actualAddressBytes, 
                0, 
                16);

            Assert.All(actualAddressBytes.Skip(2), b => Assert.Equal(0x00, b));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullAddress()
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentNullException>(
                () => builder.WithClientHardwareAddress(null));
        }
    }
}