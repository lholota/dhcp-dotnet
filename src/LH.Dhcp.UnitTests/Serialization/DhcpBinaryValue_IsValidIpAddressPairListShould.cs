using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValue_IsValidIpAddressPairListShould
    {
        [Fact]
        public void ReturnTrue_GivenValidLength()
        {
            var bytes = new byte[8];

            var binaryValue = new DhcpBinaryValue(bytes, 0, 8);

            Assert.True(binaryValue.IsValidIpAddressPairList());
        }

        [Theory]
        [InlineData(0)]
        [InlineData(4)]
        [InlineData(7)]
        [InlineData(9)]
        public void ReturnFalse_GivenInvalidLength(int length)
        {
            var bytes = new byte[length];

            var binaryValue = new DhcpBinaryValue(bytes, 0, length);

            Assert.False(binaryValue.IsValidIpAddressPairList());
        }
    }
}