using System;
using System.Linq;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    
    public class AsKeyValueCollectionShould
    {
        public static readonly byte[] PaddingOptionInMiddleBytes = { 0x01, 0x02, 0x00, 0x00, 0x00, 0x01 };
        public static readonly byte[] ValidNoPaddingOptionBytes = { 0x09, 0x02, 0x00, 0x00 };
        public static readonly byte[] ValidWithPaddingOptionBytes = { 0x00, 0x09, 0x02, 0x00, 0x00 };
        public static readonly byte[] ValidMultipleOptionsBytes = { 0x01, 0x02, 0x00, 0x00, 0x02, 0x02, 0x00, 0x00 };
        public static readonly byte[] InvalidOptionLengthBytes = { 0x01, 0x05, 0x00 };
        public static readonly byte[] InvalidDuplicateOptionBytes = { 0x01, 0x02, 0x00, 0x00, 0x01, 0x02, 0x11, 0x22 };
        public static readonly byte[] ValidEndByteInMiddleBytes = { 0x09, 0x02, 0x00, 0x00, 0xff, 0x02, 0x01, 0x00 };

        [Fact]
        public void ReturnResultWithMultipleValues_GivenBytesWithMultipleValues()
        {
            var valueReader = new BinaryValue(ValidMultipleOptionsBytes, 0, (byte)ValidMultipleOptionsBytes.Length);

            var values = valueReader.AsKeyValueCollection();

            Assert.Equal(2, values.Count);
            Assert.Equal(1, values.First().Key);
            Assert.Equal(2, values.Last().Key);
        }

        [Fact]
        public void ReturnResultWithoutItemsAfterEndByte_GivenBytesWithEndByteInMiddle()
        {
            var valueReader = new BinaryValue(ValidEndByteInMiddleBytes, 0, (byte)ValidEndByteInMiddleBytes.Length);

            var values = valueReader.AsKeyValueCollection();

            Assert.Equal(1, values.Count);
            Assert.Equal(9, values.Single().Key);
        }

        [Fact]
        public void ReturnResultWithoutPaddingOption_GivenBytesWithPaddingByte()
        {
            var valueReader = new BinaryValue(ValidWithPaddingOptionBytes, 0, (byte)ValidWithPaddingOptionBytes.Length);

            var values = valueReader.AsKeyValueCollection();

            Assert.Equal(1, values.Count);
            Assert.Equal(9, values.Single().Key);
        }

        [Fact]
        public void ReturnResult_GivenBytesWithoutPaddingByte()
        {
            var valueReader = new BinaryValue(ValidNoPaddingOptionBytes, 0, (byte)ValidNoPaddingOptionBytes.Length);

            var values = valueReader.AsKeyValueCollection();

            Assert.Equal(1, values.Count);
            Assert.Equal(9, values.Single().Key);
        }

        [Fact]
        public void ThrowInvalidOperationException_GivenBytesWithDuplicateOption()
        {
            var valueReader = new BinaryValue(InvalidDuplicateOptionBytes, 0, (byte)InvalidDuplicateOptionBytes.Length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsKeyValueCollection());
        }

        [Fact]
        public void ThrowInvalidOperationException_GivenBytesWithInvalidLengthOfLastValue()
        {
            var valueReader = new BinaryValue(InvalidOptionLengthBytes, 0, (byte)InvalidOptionLengthBytes.Length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsKeyValueCollection());
        }

        [Fact]
        public void ThrowInvalidOperationException_GivenBytesWithPaddingOptionInMiddle()
        {
            var valueReader = new BinaryValue(PaddingOptionInMiddleBytes, 0, (byte)PaddingOptionInMiddleBytes.Length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsKeyValueCollection());
        }
    }
}