using System;
using System.Linq;
using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValueReader_AsValueCollectionShould
    {
        public static readonly byte[] PaddingOptionInMiddleBytes = { 0x01, 0x02, 0x00, 0x00, 0x00, 0x01 };
        public static readonly byte[] ValidNoPaddingOptionBytes = { 0x09, 0x02, 0x00, 0x00 };
        public static readonly byte[] ValidWithPaddingOptionBytes = { 0x00, 0x09, 0x02, 0x00, 0x00 };
        public static readonly byte[] ValidMultipleOptionsBytes = { 0x01, 0x02, 0x00, 0x00, 0x02, 0x02, 0x00, 0x00 };
        public static readonly byte[] InvalidOptionLengthBytes = { 0x01, 0x05, 0x00 };
        public static readonly byte[] InvalidDuplicateOptionBytes = { 0x01, 0x02, 0x00, 0x00, 0x01, 0x02, 0x11, 0x22 };
        public static readonly byte[] ValidEndByteInMiddleBytes = { 0x01, 0x09, 0x00, 0x00, 0xff, 0x02, 0x01, 0x00 };

        [Fact]
        public void ReturnResultWithMultipleValues_GivenBytesWithMultipleValues()
        {
            var valueReader = new DhcpBinaryValueReader(ValidMultipleOptionsBytes, 0, ValidMultipleOptionsBytes.Length);

            var values = valueReader.AsValueCollection();

            Assert.Equal(2, values.Count);
            Assert.Equal(1, values.First().Key);
            Assert.Equal(2, values.Last().Key);
        }

        [Fact]
        public void ReturnResultWithoutItemsAfterEndByte_GivenBytesWithEndByteInMiddle()
        {
            var valueReader = new DhcpBinaryValueReader(ValidEndByteInMiddleBytes, 0, ValidEndByteInMiddleBytes.Length);

            var values = valueReader.AsValueCollection();

            Assert.Equal(1, values.Count);
            Assert.Equal(9, values.Single().Key);
        }

        [Fact]
        public void ReturnResultWithoutPaddingOption_GivenBytesWithPaddingByte()
        {
            var valueReader = new DhcpBinaryValueReader(ValidWithPaddingOptionBytes, 0, ValidWithPaddingOptionBytes.Length);

            var values = valueReader.AsValueCollection();

            Assert.Equal(1, values.Count);
            Assert.Equal(9, values.Single().Key);
        }

        [Fact]
        public void ReturnResult_GivenBytesWithoutPaddingByte()
        {
            var valueReader = new DhcpBinaryValueReader(ValidNoPaddingOptionBytes, 0, ValidNoPaddingOptionBytes.Length);

            var values = valueReader.AsValueCollection();

            Assert.Equal(1, values.Count);
            Assert.Equal(9, values.Single().Key);
        }

        [Fact]
        public void ThrowInvalidOperationException_GivenBytesWithDuplicateOption()
        {
            var valueReader = new DhcpBinaryValueReader(InvalidDuplicateOptionBytes, 0, InvalidDuplicateOptionBytes.Length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsValueCollection());
        }

        [Fact]
        public void ThrowInvalidOperationException_GivenBytesWithInvalidLengthOfLastValue()
        {
            var valueReader = new DhcpBinaryValueReader(InvalidOptionLengthBytes, 0, InvalidOptionLengthBytes.Length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsValueCollection());
        }

        [Fact]
        public void ThrowInvalidOperationException_GivenBytesWithPaddingOptionInMiddle()
        {
            var valueReader = new DhcpBinaryValueReader(PaddingOptionInMiddleBytes, 0, PaddingOptionInMiddleBytes.Length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsValueCollection());
        }
    }
}