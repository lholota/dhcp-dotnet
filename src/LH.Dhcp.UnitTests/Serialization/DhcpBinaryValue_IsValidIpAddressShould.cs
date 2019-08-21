using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpBinaryValue_IsValidIpAddressShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        public void ReturnFalse_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(bytes, 0, length);

            Assert.False(valueReader.IsValidIpAddress());
        }

        [Fact]
        public void ReturnTrue_GivenValidLength()
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(bytes, 0, 4);

            Assert.True(valueReader.IsValidIpAddress());
        }
    }
}