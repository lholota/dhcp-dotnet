using System;
using System.Linq;
using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValue_AsUnsignedInt16ListShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new BinaryValue(bytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsUnsignedInt16List());
        }

        [Fact]
        public void ReturnSingleNumber_GivenBytesForOneNumber()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 2);

            Assert.Equal(17U, valueReader.AsUnsignedInt16List().Single());
        }

        [Fact]
        public void ReturnTwoNumbers_GivenBytesForTwoNumbers()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 8);

            var numberList = valueReader.AsUnsignedInt16List();

            Assert.Equal(17U, numberList[0]);
            Assert.Equal(8755U, numberList[1]);
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new BinaryValue(TestBytes, 2, 2);

            Assert.Equal(8755U, valueReader.AsUnsignedInt16List().Single());
        }
    }
}