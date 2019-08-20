using System;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class DhcpPacket_HasOptionByByteCodeShould
    {
        private static readonly byte[] PacketBytesWithOverloadedFields = "02010600b7a44d790000800000000000c0a801670000000000000000deadc0decafe00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000f0b6578616d706c652e6f72674318736f6d652d66696c652d6e616d652d696e2d6f7074696f6eff00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000638253633501023604c0a8010233040000012c0104ffffff000408c0a80167c0a801680708c0a80167c0a801680804c0a8016c0cf864756d6d792d686f73746e616d65616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616162626262626262626262626262626262626262626262626262626262626262636363636363636363636363636363636363636363636363636363636363636363636363636364646464646464646464646464646464646464646464646464646464646464646464646565656565656565656565656565656565656565656565656565656565656565656565656565656565656565340101ff".AsHexBytes();

        [Fact]
        public void ReturnTrue_WhenOptionPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.True(packet.HasOption(53));
        }

        [Fact]
        public void ReturnTrue_WhenOptionPresentInOverloadedFields()
        {
            var packet = new DhcpPacket(PacketBytesWithOverloadedFields);

            Assert.True(packet.HasOption(15));
        }

        [Fact]
        public void ReturnFalse_WhenOptionNotPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.False(packet.HasOption(140));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(255)]
        public void ThrowArgumentException_GivenReservedOptionCode(byte optionCode)
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.Throws<ArgumentException>(
                () => packet.HasOption(optionCode));
        }
    }
}