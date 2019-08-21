using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryValue_IsValidByteShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(5)]
        public void ReturnFalse_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(bytes, 0, length);

            Assert.False(valueReader.IsValidByte());
        }

        [Fact]
        public void ReturnTrue_GivenValidLength()
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(bytes, 0, 1);

            Assert.True(valueReader.IsValidByte());
        }
    }
}
