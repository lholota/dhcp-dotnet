using System;
using System.Linq;
using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValueReader_AsIpAddressPairListShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(9)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValueReader(bytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsIpAddressPairList());
        }

        [Fact]
        public void ReturnSingleIpPair_GivenBytesForOneIpPair()
        {
            var valueReader = new DhcpBinaryValueReader(TestBytes, 0, 4);

            var ipPair = valueReader.AsIpAddressPairList().Single();

            Assert.Equal(IPAddress.Parse("0.17.34.51"), ipPair.Item1);
            Assert.Equal(IPAddress.Parse("68.85.102.119"), ipPair.Item2);
        }

        [Fact]
        public void ReturnTwoIps_GivenBytesForTwoIp()
        {
            var valueReader = new DhcpBinaryValueReader(TestBytes, 0, 8);

            var ipAddressPairs = valueReader.AsIpAddressPairList();

            Assert.Equal(IPAddress.Parse("0.17.34.51"), ipAddressPairs[0].Item1);
            Assert.Equal(IPAddress.Parse("68.85.102.119"), ipAddressPairs[0].Item2);

            Assert.Equal(IPAddress.Parse("136.153.170.187"), ipAddressPairs[1].Item1);
            Assert.Equal(IPAddress.Parse("204.221.238.255"), ipAddressPairs[1].Item2);
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new DhcpBinaryValueReader(TestBytes, 2, 4);

            Assert.Equal(IPAddress.Parse("34.51.68.85"), valueReader.AsIpAddressPairList().Single().Item1);
            Assert.Equal(IPAddress.Parse("102.119.135.153"), valueReader.AsIpAddressPairList().Single().Item2);
        }
    }
}