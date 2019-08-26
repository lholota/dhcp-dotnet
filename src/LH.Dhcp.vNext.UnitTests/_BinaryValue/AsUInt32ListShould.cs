using System;
using System.Linq;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    public class AsUInt32ListShould
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
                () => valueReader.AsUInt32List());
        }

        [Fact]
        public void ReturnSingleNumber_GivenBytesForOneNumber()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 4);

            Assert.Equal(2685477427, valueReader.AsUInt32List().Single());
        }

        [Fact]
        public void ReturnTwoNumbers_GivenBytesForTwoNumbers()
        {
            var valueReader = new BinaryValue(TestBytes, 0, 8);

            var numberList = valueReader.AsUInt32List();

            Assert.Equal(2, numberList.Count);
            Assert.Equal(2685477427U, numberList[0]);
            Assert.Equal(1146447479U, numberList[1]);
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var valueReader = new BinaryValue(TestBytes, 8, 4);

            Assert.Equal(2291772091U, valueReader.AsUInt32List().Single());
        }
    }
}