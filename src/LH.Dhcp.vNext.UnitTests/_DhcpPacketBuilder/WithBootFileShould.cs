using System;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    public class WithBootFileShould
    {
        [Fact]
        public void SetBootFile()
        {
            const string bootFile = "some-boot-file";

            var packet = DhcpPacketBuilder.Create(DhcpMessageType.Ack)
                .WithBootFile(bootFile)
                .Build();

            Assert.Equal(bootFile, packet.BootFileName);
        }

        [Fact]
        public void ThrowArgumentException_GivenValueLongerThan128Chars()
        {
            // 128 bytes is the max length of the BOOTP field

            var bootFile = string.Empty.PadRight(129, 'a');

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentException>(
                () => builder.WithBootFile(bootFile));
        }
    }
}