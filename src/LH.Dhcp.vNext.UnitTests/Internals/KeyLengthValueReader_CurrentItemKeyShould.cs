using System;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals
{
    // ReSharper disable once InconsistentNaming
    public class KeyLengthValueReader_CurrentItemKeyShould
    {
        private readonly byte[] _bytes = "0102aabb0202ccdd0302ee99".AsHexBytes();

        [Fact]
        public void ReturnCurrentItemKey()
        {
            var reader = new KeyLengthValueReader(_bytes, 0, _bytes.Length);

            reader.Next();

            Assert.Equal(0x01, reader.CurrentItemKey);
        }

        [Fact]
        public void ThrowInvalidOperationException_WhenNextHasNotBeenCalled()
        {
            var reader = new KeyLengthValueReader(_bytes, 0, _bytes.Length);

            Assert.Throws<InvalidOperationException>(
                () => reader.CurrentItemKey);
        }
    }
}