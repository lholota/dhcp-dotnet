using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class BinaryValue_LengthShould
    {
        private static readonly byte[] Bytes = { 0x01, 0x02, 0x03, 0x04, 0x05 };

        [Fact]
        public void ReturnLengthOfValue()
        {
            var binaryValue = new BinaryValue(Bytes, 0, Bytes.Length);

            Assert.Equal(5, binaryValue.Length);
        }

        [Fact]
        public void ReturnLengthOfValueBetweenOffsetAndLength()
        {
            var binaryValue = new BinaryValue(Bytes, 2, 3);

            Assert.Equal(3, binaryValue.Length);
        }
    }
}