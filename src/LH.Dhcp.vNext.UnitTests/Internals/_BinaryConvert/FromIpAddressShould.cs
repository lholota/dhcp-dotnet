using System;
using System.Net;
using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    public class FromIpAddressShould
    {
        [Fact]
        public void WriteIpAddressBytes()
        {
            var bytes = new byte[4];
            BinaryConvert.FromIpAddress(bytes, 0, IPAddress.Parse("192.168.1.2"));

            var expectedBytes = new byte[] { 0xc0, 0xa8, 0x01, 0x02 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void WriteFromGivenStartIndex()
        {
            var bytes = new byte[6];
            BinaryConvert.FromIpAddress(bytes, 2, IPAddress.Parse("192.168.1.2"));

            var expectedBytes = new byte[] { 0x00, 0x00, 0xc0, 0xa8, 0x01, 0x02 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentException>(
                () => BinaryConvert.FromIpAddress(bytes, 9, IPAddress.Parse("192.168.1.2")));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromIpAddress(bytes, 50, IPAddress.Parse("192.168.1.2")));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromIpAddress(bytes, -1, IPAddress.Parse("192.168.1.2")));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.FromIpAddress(null, 0, IPAddress.Parse("192.168.1.2")));
        }
    }
}