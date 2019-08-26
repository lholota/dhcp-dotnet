using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    
    public class IsValidInt16ListShould
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(13)]
        public void ReturnFalse_GivenInvalidLength(byte length)
        {
            var bytes = new byte[20];

            var valueReader = new BinaryValue(bytes, 0, length);

            Assert.False(valueReader.IsValidInt16List());
        }

        [Theory]
        [InlineData(2)]
        [InlineData(4)]
        [InlineData(12)]
        public void ReturnTrue_GivenValidLength(byte length)
        {
            var bytes = new byte[20];

            var valueReader = new BinaryValue(bytes, 0, length);

            Assert.True(valueReader.IsValidInt16List());
        }
    }
}