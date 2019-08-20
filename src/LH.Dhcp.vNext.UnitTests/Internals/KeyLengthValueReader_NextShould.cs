using System;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals
{
    // ReSharper disable once InconsistentNaming
    public class KeyLengthValueReader_NextShould
    {
        private readonly byte[] _bytes = "0102aabb0202ccdd0302ee99".AsHexBytes();

        [Fact]
        public void ReturnTrue_WhenAtBeginning()
        {
            var reader = new KeyLengthValueReader(_bytes, 0, _bytes.Length);

            Assert.True(reader.Next());
        }

        [Fact]
        public void ReturnTrue_WhenHasRemainingBytes()
        {
            var reader = new KeyLengthValueReader(_bytes, 0, _bytes.Length);

            reader.Next();
            reader.Next();

            Assert.True(reader.Next());
        }

        [Fact]
        public void ReturnFalse_WhenAtEndOfArray()
        {
            var reader = new KeyLengthValueReader(_bytes, 0, _bytes.Length);

            reader.Next();
            reader.Next();
            reader.Next();

            Assert.False(reader.Next());
        }

        [Fact]
        public void ReturnFalse_WhenAtLengthLimit()
        {
            var reader = new KeyLengthValueReader(_bytes, 0, 4);

            reader.Next();

            Assert.False(reader.Next());
        }

        [Fact]
        public void ReturnFalse_WhenNextItemIsEndByte()
        {
            var bytes = "0102aabbff".AsHexBytes();

            var reader = new KeyLengthValueReader(bytes, 0, bytes.Length);

            reader.Next();

            Assert.False(reader.Next());
        }

        [Fact]
        public void ThrowFormatException_WhenNextItemDoesNotHaveLength()
        {
            var bytes = "0102aabb02".AsHexBytes();

            var reader = new KeyLengthValueReader(bytes, 0, bytes.Length);

            reader.Next();

            Assert.Throws<FormatException>(
                () => reader.Next());
        }

        [Fact]
        public void ThrowFormatException_WhenNextItemDoesNotHaveValue()
        {
            var bytes = "0102aabb0208".AsHexBytes();

            var reader = new KeyLengthValueReader(bytes, 0, bytes.Length);

            reader.Next();

            Assert.Throws<FormatException>(
                () => reader.Next());
        }

        [Fact]
        public void ThrowFormatException_WhenNextItemHasInvalidLength()
        {
            var bytes = "0102aabb0208ddee".AsHexBytes();

            var reader = new KeyLengthValueReader(bytes, 0, bytes.Length);

            reader.Next();

            Assert.Throws<FormatException>(
                () => reader.Next());
        }
    }
}
