using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryValue_LengthShould
    {
        private static readonly byte[] Bytes = { 0x01, 0x02, 0x03, 0x04, 0x05 };

        [Fact]
        public void ReturnLengthOfValue()
        {
            var binaryValue = new DhcpBinaryValue(Bytes, 0, Bytes.Length);

            Assert.Equal(5, binaryValue.Length);
        }

        [Fact]
        public void ReturnLengthOfValueBetweenOffsetAndLength()
        {
            var binaryValue = new DhcpBinaryValue(Bytes, 2, 3);

            Assert.Equal(3, binaryValue.Length);
        }
    }
}