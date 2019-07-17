using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValue_IsValidUnsignedInt16ListShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(13)]
        public void ReturnFalse_GivenInvalidLength(byte length)
        {
            var bytes = new byte[20];

            var valueReader = new DhcpBinaryValue(bytes, 0, length);

            Assert.False(valueReader.IsValidUnsignedInt16List());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(12)]
        public void ReturnTrue_GivenValidLength(byte length)
        {
            var bytes = new byte[20];

            var valueReader = new DhcpBinaryValue(bytes, 0, length);

            Assert.True(valueReader.IsValidUnsignedInt16List());
        }
    }
}