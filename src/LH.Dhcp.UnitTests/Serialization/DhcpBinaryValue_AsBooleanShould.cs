﻿using System;
using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValue_AsBooleanShould
    {
        [Theory]
        [InlineData(0)]
        [InlineData(2)]
        [InlineData(5)]
        public void ThrowInvalidOperationException_GivenInvalidLength(byte length)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValue(bytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.AsBoolean());
        }

        [Theory]
        [InlineData(0x00, false)]
        [InlineData(0x01, true)]
        public void ReturnValue_GivenValidLength(byte binaryValue, bool expectedValue)
        {
            var bytes = new[] { binaryValue };

            var valueReader = new DhcpBinaryValue(bytes, 0, 1);

            Assert.Equal(expectedValue, valueReader.AsBoolean());
        }

        [Fact]
        public void ReadValueFromGivenOffset()
        {
            var bytes = new byte[] { 0x00, 0x00, 0x01, 0x00 };
            var valueReader = new DhcpBinaryValue(bytes, 2, 1);

            Assert.True(valueReader.AsBoolean());
        }
    }
}
