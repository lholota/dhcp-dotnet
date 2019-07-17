using System;
using System.Linq;
using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpTaggedValueCollectionReader_NextItemShould
    {
        [Fact]
        public void ReturnNextItem_WhenHasMoreItems()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x00, 0x00, 0x09, 0x02, 0x01, 0x01 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            collectionReader.NextItem();

            var item = collectionReader.NextItem();

            Assert.Equal(0x09, item.Tag);
        }

        [Fact]
        public void ReturnNextItemOfGivenLength()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x00, 0x00, 0x09, 0x03, 0x01, 0x01, 0x01 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            collectionReader.NextItem();

            var item = collectionReader.NextItem();

            Assert.Equal(3, item.Value.AsBytes().Length);
            Assert.True(item.Value.AsBytes().All(x => x == 0x01));
        }

        [Fact]
        public void SkipPaddingOption()
        {
            var bytes = new byte[] { 0x00, 0x01, 0x02, 0x00, 0x00 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            var item = collectionReader.NextItem();

            Assert.Equal(1, item.Tag);
        }

        [Fact]
        public void ThrowsInvalidOperationException_WhenAtEndOfBytes()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x00, 0x00 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            collectionReader.NextItem();

            Assert.Throws<InvalidOperationException>(
                () => collectionReader.NextItem());
        }

        [Fact]
        public void ThrowsInvalidOperationException_WhenNextItemIsEndByte()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x00, 0x00, 0xff, 0x01, 0x02, 0x00, 0x00 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            collectionReader.NextItem();

            Assert.Throws<InvalidOperationException>(
                () => collectionReader.NextItem());
        }

        [Fact]
        public void ThrowsInvalidOperationException_GivenBytesWithOnlyPaddingByte()
        {
            var bytes = new byte[] { 0x00 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            Assert.Throws<InvalidOperationException>(
                () => collectionReader.NextItem());
        }
    }
}