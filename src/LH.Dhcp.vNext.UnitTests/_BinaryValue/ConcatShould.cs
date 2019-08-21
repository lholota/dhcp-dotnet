using System;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    
    public class ConcatShould
    {
        [Fact]
        public void ReturnCombinedValue()
        {
            var bytes1 = new byte[] { 0x01, 0x02 };
            var bytes2 = new byte[] { 0x03, 0x04 };

            var value1 = new BinaryValue(bytes1, 0, 2);
            var value2 = new BinaryValue(bytes2, 0, 2);

            var combined = BinaryValue.Concat(new[] { value1, value2 });

            var expected = new byte[] { 0x01, 0x02, 0x03, 0x04 };

            Assert.Equal(expected, combined.AsBytes());
        }

        [Fact]
        public void ReturnExistingInstance_GivenArrayWithOnlyOneValue()
        {
            var bytes = new byte[10];
            var value = new BinaryValue(bytes, 0, 1);

            var combined = BinaryValue.Concat(new[] { value });

            Assert.Same(value, combined);
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullValues()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryValue.Concat(null));
        }

        [Fact]
        public void ThrowArgumentException_GivenEmptyValues()
        {
            Assert.Throws<ArgumentException>(
                () => BinaryValue.Concat(new BinaryValue[0]));
        }
    }
}