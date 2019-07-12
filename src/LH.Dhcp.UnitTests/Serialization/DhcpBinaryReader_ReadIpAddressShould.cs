using System;
using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_ReadIpAddressShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReadIpAddress()
        {
            var reader = new DhcpBinaryReader(TestBytes);

            var readIpAddress = reader.ReadIpAddress();

            Assert.Equal(IPAddress.Parse("0.17.34.51"), readIpAddress);
        }

        [Fact]
        public void ReadIpAddressFromPassedOffset()
        {
            var reader = new DhcpBinaryReader(TestBytes, 2, 8);

            var readIpAddress = reader.ReadIpAddress();

            Assert.Equal(IPAddress.Parse("34.51.68.85"), readIpAddress);
        }

        [Fact]
        public void ThrowIndexOutOfRange_WhenLessThanFourBytesRemain()
        {
            var reader = new DhcpBinaryReader(TestBytes, TestBytes.Length - 3, 3);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadIpAddress());
        }

        [Fact]
        public void ThrowIndexOutOfRange_WhenLessThanFourBytesRemainToLimit()
        {
            var reader = new DhcpBinaryReader(TestBytes, 0, 3);

            Assert.Throws<IndexOutOfRangeException>(
                () => reader.ReadIpAddress());
        }
    }
}