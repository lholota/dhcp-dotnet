using System;
using LH.Dhcp.vNext.Options;
using LH.Dhcp.vNext.UnitTests.Extensions;
using LH.Dhcp.vNext.UnitTests.TestData;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacket
{
    public class GetOptionByByteCodeShould
    {
        private static readonly byte[] PacketBytesWithOverloadedFields = "02010600b7a44d790000800000000000c0a801670000000000000000deadc0decafe00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000f0b6578616d706c652e6f72674318736f6d652d66696c652d6e616d652d696e2d6f7074696f6eff00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000638253633501023604c0a8010233040000012c0104ffffff000408c0a80167c0a801680708c0a80167c0a801680804c0a8016c0cf864756d6d792d686f73746e616d65616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616161616162626262626262626262626262626262626262626262626262626262626262636363636363636363636363636363636363636363636363636363636363636363636363636364646464646464646464646464646464646464646464646464646464646464646464646565656565656565656565656565656565656565656565656565656565656565656565656565656565656565340101ff".AsHexBytes();

        // Domain name value is [test_]*123456798
        private static readonly byte[] PacketBytesWithFileNameOptionSplitIntoMultipleParts = "02010600133001730000800000000000c0a801670000000000000000deadc0decafe00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000f13746573745f746573745f313233343536373839ff00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000638253633501023604c0a8010233040000012c0104ffffff000408c0a80167c0a801680708c0a80167c0a801680804c0a8016c0c0e3139322e3136382e312e313033000ff0746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f746573745f340101".AsHexBytes();

        [Fact]
        public void ReturnValue_WhenOptionPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.Equal((byte)DhcpMessageType.Discover, packet.GetOption(53).AsByte());
        }

        [Fact]
        public void ReturnValue_WhenOptionPresentInOverloadedFields()
        {
            var packet = new DhcpPacket(PacketBytesWithOverloadedFields);

            Assert.Equal("example.org", packet.GetOption(15).AsString());
        }

        [Fact]
        public void ReturnWholeValue_WhenOptionValueIsSplitIntoMultipleItems()
        {
            var packet = new DhcpPacket(PacketBytesWithFileNameOptionSplitIntoMultipleParts);

            var optionValue = packet.GetOption(15).AsString();

            Assert.StartsWith("test_", optionValue);
            Assert.EndsWith("123456789", optionValue);
            Assert.Equal(259, optionValue.Length);
        }

        [Fact]
        public void ReturnNull_WhenOptionNotPresentInPacket()
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.Null(packet.GetOption(140));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(66)]
        [InlineData(67)]
        [InlineData(255)]
        public void ThrowArgumentException_GivenReservedOptionCode(byte optionCode)
        {
            var packet = new DhcpPacket(DhcpTestPackets.Discover.Bytes);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => packet.GetOption(optionCode));
        }
    }
}