﻿using System;
using System.Linq;
using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValue_AsIpAddressListShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(bytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsIpAddressList());
        }

        [Fact]
        public void ReturnSingleIp_GivenBytesForOneIp()
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 0, 4);

            Assert.Equal(IPAddress.Parse("0.17.34.51"), valueReader.AsIpAddressList().Single());
        }

        [Fact]
        public void ReturnTwoIps_GivenBytesForTwoIp()
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 0, 8);

            var ipAddressList = valueReader.AsIpAddressList();

            Assert.Equal(IPAddress.Parse("0.17.34.51"), ipAddressList[0]);
            Assert.Equal(IPAddress.Parse("68.85.102.119"), ipAddressList[1]);
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new DhcpBinaryValue(TestBytes, 2, 4);

            Assert.Equal(IPAddress.Parse("34.51.68.85"), valueReader.AsIpAddressList().Single());
        }
    }
}