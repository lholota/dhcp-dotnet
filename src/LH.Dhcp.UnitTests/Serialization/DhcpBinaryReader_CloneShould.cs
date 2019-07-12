using System;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryReader_CloneShould
    {
        private static readonly byte[] TestBytes = "00112233445566778899".AsHexBytes();

        [Fact]
        public void ReturnReaderWithSameOffset()
        {
            var originalReader = new DhcpBinaryReader(TestBytes, 1, 4);
            originalReader.ReadByte();

            var clonedReader = originalReader.Clone();

            Assert.Equal(0x22, clonedReader.ReadByte());
        }

        [Fact]
        public void ReturnReaderWithSameLimit()
        {
            var originalReader = new DhcpBinaryReader(TestBytes, 1, 4);
            var clonedReader = originalReader.Clone();

            clonedReader.ReadByte();
            clonedReader.ReadByte();
            clonedReader.ReadByte();
            clonedReader.ReadByte();

            Assert.Throws<IndexOutOfRangeException>(
                () => clonedReader.ReadByte());
        }
    }
}