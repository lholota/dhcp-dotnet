using System;
using System.Linq;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    
    public class AsUInt16ListShould
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
                () => valueReader.AsUInt16List());
        }

        [Fact]
        public void ReturnSingleNumber_GivenBytesForOneNumber()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 2);

            Assert.Equal(17U, valueReader.AsUInt16List().Single());
        }

        [Fact]
        public void ReturnTwoNumbers_GivenBytesForTwoNumbers()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 8);

            var numberList = valueReader.AsUInt16List();

            Assert.Equal(17U, numberList[0]);
            Assert.Equal(8755U, numberList[1]);
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new BinaryValue(TestBytes, 2, 2);

            Assert.Equal(8755U, valueReader.AsUInt16List().Single());
        }
    }
}