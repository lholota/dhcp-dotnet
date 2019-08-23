using System;
using LH.Dhcp.vNext.Internals;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals._BinaryConvert
{
    public class FromStringShould
    {
        [Fact]
        public void WriteStringBytes()
        {
            const string value = "Hello, world";

            var bytes = new byte[12];
            BinaryConvert.FromString(bytes, 0, value);

            var expectedBytes = new byte[] { 0x48, 0x65, 0x6c, 0x6c, 0x6f, 0x2c, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void WriteFromGivenStartIndex()
        {
            const string value = "Hello";

            var bytes = new byte[7];
            BinaryConvert.FromString(bytes, 2, value);

            var expectedBytes = new byte[] { 0x00, 0x00, 0x48, 0x65, 0x6c, 0x6c, 0x6f };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void WriteOnlyGivenSubstring()
        {
            const string value = "Hello, World";

            var bytes = new byte[6];
            BinaryConvert.FromString(bytes, 2, value, 2, 2);

            var expectedBytes = new byte[] { 0x00, 0x00, 0x6c, 0x6c, 0x00, 0x00 };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void TreatNullAsEmptyString()
        {
            var bytes = new byte[2] { 0xff, 0xff };

            BinaryConvert.FromString(bytes, 0, null);

            var expectedBytes = new byte[] { 0xff, 0xff };

            Assert.Equal(expectedBytes, bytes);
        }

        [Fact]
        public void ThrowArgumentException_GivenStartIndexTooCloseToEnd()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentException>(
                () => BinaryConvert.FromString(bytes, 6, "Hello"));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenStartIndexBeyondLengthOfArray()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromString(bytes, 50, "Hello"));
        }

        [Fact]
        public void ThrowArgumentOutOfRangeException_GivenNegativeStartIndex()
        {
            var bytes = new byte[10];

            Assert.Throws<ArgumentOutOfRangeException>(
                () => BinaryConvert.FromString(bytes, -1, "Hello"));
        }

        [Fact]
        public void ThrowArgumentNullException_GivenNullByteArray()
        {
            Assert.Throws<ArgumentNullException>(
                () => BinaryConvert.FromString(null, 0, "Hello"));
        }
    }
}