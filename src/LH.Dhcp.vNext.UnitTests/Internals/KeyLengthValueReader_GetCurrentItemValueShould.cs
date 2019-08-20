using System;
using LH.Dhcp.vNext.Internals;
using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests.Internals
{
    // ReSharper disable once InconsistentNaming
    public class KeyLengthValueReader_GetCurrentItemValueShould
    {
        private readonly byte[] _bytes = "0102aabb0202ccdd0302ee99".AsHexBytes();

        [Fact]
        public void ReturnCurrentItemValue()
        {
            var reader = new KeyLengthValueReader(_bytes, 0, _bytes.Length);

            reader.Next();

            Assert.Equal(new byte[] { 0xaa, 0xbb }, reader.GetCurrentItemValue().AsBytes());
        }

        [Fact]
        public void ThrowInvalidOperationException_WhenNextHasNotBeenCalled()
        {
            var reader = new KeyLengthValueReader(_bytes, 0, _bytes.Length);

            Assert.Throws<InvalidOperationException>(
                () => reader.GetCurrentItemValue());
        }
    }
}