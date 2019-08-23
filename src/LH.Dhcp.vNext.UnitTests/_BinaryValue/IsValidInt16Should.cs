using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    public class IsValidInt16Should
    {
        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void ReturnFalse_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new BinaryValue(bytes, 0, length);

            Assert.False(valueReader.IsValidInt16());
        }

        [Fact]
        public void ReturnTrue_GivenValidLength()
        {
            var bytes = new byte[10];

            var valueReader = new BinaryValue(bytes, 0, 2);

            Assert.True(valueReader.IsValidInt16());
        }
    }
}