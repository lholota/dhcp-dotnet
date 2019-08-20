using LH.Dhcp.vNext.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests
{
    // ReSharper disable once InconsistentNaming
    public class BinaryValue_AsBytesShould
    {
        private static readonly byte[] TestBytes = "112233445566778899aabbccddeeff".AsHexBytes();

        [Fact]
        public void ReturnValue()
        {
            var valueReader = new BinaryValue(TestBytes, 1, 4);

            var expectedBytes = new byte[]{ 0x22, 0x33, 0x44, 0x55 };

            Assert.Equal(expectedBytes, valueReader.AsBytes());
        }
    }
}