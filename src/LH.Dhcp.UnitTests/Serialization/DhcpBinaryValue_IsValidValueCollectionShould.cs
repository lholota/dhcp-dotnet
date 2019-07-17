using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValue_IsValidValueCollectionShould
    {
        public static readonly byte[] PaddingOptionInMiddleBytes = { 0x01, 0x02, 0x00, 0x00, 0x00, 0x01 };
        public static readonly byte[] ValidNoPaddingOptionBytes = { 0x01, 0x02, 0x00, 0x00 };
        public static readonly byte[] ValidWithPaddingOptionBytes = { 0x00, 0x01, 0x02, 0x00, 0x00 };
        public static readonly byte[] ValidMultipleOptionsBytes = { 0x01, 0x02, 0x00, 0x00, 0x02, 0x02, 0x00, 0x00 };
        public static readonly byte[] InvalidOptionLengthBytes = { 0x01, 0x05, 0x00 };
        public static readonly byte[] InvalidDuplicateOptionBytes = { 0x01, 0x02, 0x00, 0x00, 0x01, 0x02, 0x11, 0x22 };
        public static readonly byte[] ValidEndByteInMiddleBytes = { 0x01, 0x02, 0x00, 0x00, 0xff, 0x09, 0x05, 0x00 };

        [Fact]
        public void ReturnTrue_GivenBytesWithMultipleValues()
        {
            var valueReader = new DhcpBinaryValue(ValidMultipleOptionsBytes, 0, ValidMultipleOptionsBytes.Length);

            Assert.True(valueReader.IsValidTaggedValueCollection());
        }

        [Fact]
        public void ReturnTrue_GivenBytesWithEndByteInMiddle()
        {
            var valueReader = new DhcpBinaryValue(ValidEndByteInMiddleBytes, 0, ValidEndByteInMiddleBytes.Length);

            Assert.True(valueReader.IsValidTaggedValueCollection());
        }

        [Fact]
        public void ReturnTrue_GivenBytesWithPaddingByte()
        {
            var valueReader = new DhcpBinaryValue(ValidWithPaddingOptionBytes, 0, ValidWithPaddingOptionBytes.Length);

            Assert.True(valueReader.IsValidTaggedValueCollection());
        }

        [Fact]
        public void ReturnTrue_GivenBytesWithoutPaddingByte()
        {
            var valueReader = new DhcpBinaryValue(ValidNoPaddingOptionBytes, 0, ValidNoPaddingOptionBytes.Length);

            Assert.True(valueReader.IsValidTaggedValueCollection());
        }

        [Fact]
        public void ReturnFalse_GivenBytesWithDuplicateOption()
        {
            var valueReader = new DhcpBinaryValue(InvalidDuplicateOptionBytes, 0, InvalidDuplicateOptionBytes.Length);

            Assert.False(valueReader.IsValidTaggedValueCollection());
        }

        [Fact]
        public void ReturnFalse_GivenBytesWithInvalidLengthOfLastValue()
        {
            var valueReader = new DhcpBinaryValue(InvalidOptionLengthBytes, 0, InvalidOptionLengthBytes.Length);

            Assert.False(valueReader.IsValidTaggedValueCollection());
        }

        [Fact]
        public void ReturnFalse_GivenBytesWithPaddingOptionInMiddle()
        {
            var valueReader = new DhcpBinaryValue(PaddingOptionInMiddleBytes, 0, (byte)PaddingOptionInMiddleBytes.Length);

            Assert.False(valueReader.IsValidTaggedValueCollection());
        }
    }
}