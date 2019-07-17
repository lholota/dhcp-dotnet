using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_CtorShould
    {
        private static readonly byte[] TestBytes = "0123456789abcd".AsHexBytes();

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenOffsetLowerThanZero()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpBinaryReader(TestBytes, -5, 5));

            Assert.Equal("offset", ex.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenOffsetLargerThanByteArrayLength()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpBinaryReader(TestBytes, TestBytes.Length + 10, 5));

            Assert.Equal("offset", ex.ParamName);
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenLimitLargerThanByteArrayLength()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(
                () => new DhcpBinaryReader(TestBytes, 5, 6));

            Assert.Equal("length", ex.ParamName);
        }
    }
}