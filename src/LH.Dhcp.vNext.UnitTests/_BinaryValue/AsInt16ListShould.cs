using System;
using System.Linq;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    public class AsInt16ListShould
    {
        private static readonly byte[] TestBytes = "a0112233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new BinaryValue(bytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsInt16List());
        }

        [Fact]
        public void ReturnSingleNumber_GivenBytesForOneNumber()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 2);

            Assert.Equal(-24559, valueReader.AsInt16List().Single());
        }

        [Fact]
        public void ReturnTwoNumbers_GivenBytesForTwoNumbers()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 8);

            var numberList = valueReader.AsInt16List();

            Assert.Equal(-24559, numberList[0]);
            Assert.Equal(8755, numberList[1]);
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new BinaryValue(TestBytes, 10, 2);

            Assert.Equal(-21829, valueReader.AsInt16List().Single());
        }
    }
}