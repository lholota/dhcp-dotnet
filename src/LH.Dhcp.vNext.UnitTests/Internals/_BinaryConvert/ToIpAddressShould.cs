using System;
using System.Net;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    public class ToIpAddressShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReturnIpAddressRepresentation()
        {
            var actual = BinaryConvert.ToIpAddress(TestBytes, 0);

            Assert.Equal(IPAddress.Parse("0.17.34.51"), actual);
        }

        [Fact]
        public void ReadFromGivenStartIndex()
        {
            var actual = BinaryConvert.ToIpAddress(TestBytes, 2);

            Assert.Equal(IPAddress.Parse("34.51.68.85"), actual);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            Assert.Throws<ArgumentException>(
                () => BinaryConvert.ToIpAddress(TestBytes, 13));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToIpAddress(TestBytes, 50));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.ToIpAddress(TestBytes, -1));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.ToIpAddress(null, 0));
        }
    }
}