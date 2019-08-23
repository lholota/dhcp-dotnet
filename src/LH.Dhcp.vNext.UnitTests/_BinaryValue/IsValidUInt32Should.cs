﻿using Xunit;

namespace LH.Dhcp.vNext.UnitTests._BinaryValue
{
    
    public class IsValidUInt32Should
    {
        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        public void ReturnFalse_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new BinaryValue(bytes, 0, length);

            Assert.False(valueReader.IsValidUInt32());
        }

        [Fact]
        public void ReturnTrue_GivenValidLength()
        {
            var bytes = new byte[10];

            var valueReader = new BinaryValue(bytes, 0, 4);

            Assert.True(valueReader.IsValidUInt32());
        }
    }
}