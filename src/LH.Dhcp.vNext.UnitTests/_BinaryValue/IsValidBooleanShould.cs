using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    
    public class IsValidBooleanShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(5)]
        public void ReturnFalse_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new BinaryValue(bytes, 0, length);

            Assert.False(valueReader.IsValidBoolean());
        }

        [Fact]
        public void ReturnTrue_GivenValidLength()
        {
            var bytes = new byte[10];

            var valueReader = new BinaryValue(bytes, 0, 1);

            Assert.True(valueReader.IsValidBoolean());
        }
    }
}
