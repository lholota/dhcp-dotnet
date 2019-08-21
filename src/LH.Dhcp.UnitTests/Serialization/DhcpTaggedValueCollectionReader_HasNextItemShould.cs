using LH.Dhcp.Serialization;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    
    public class DhcpTaggedValueCollectionReader_HasNextItemShould
    {
        [Fact]
        public void ReturnTrue_WhenHasMoreItems()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x00, 0x00, 0x02, 0x02, 0x01, 0x01 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            collectionReader.NextItem();

            Assert.True(collectionReader.HasNextItem());
        }

        [Fact]
        public void ReturnFalse_WhenAtEndOfBytes()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x00, 0x00 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            collectionReader.NextItem();

            Assert.False(collectionReader.HasNextItem());
        }

        [Fact]
        public void ReturnFalse_WhenNextItemIsEndByte()
        {
            var bytes = new byte[] { 0x01, 0x02, 0x00, 0x00, 0xff, 0x01, 0x02, 0x00, 0x00 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            collectionReader.NextItem();

            Assert.False(collectionReader.HasNextItem());
        }

        [Fact]
        public void ReturnFalse_GivenBytesWithOnlyPaddingByte()
        {
            var bytes = new byte[] { 0x00 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            Assert.False(collectionReader.HasNextItem());
        }

        [Fact]
        public void ReturnTrue_GivenBytesWithPadOptionAndOtherOptions()
        {
            var bytes = new byte[] { 0x00, 0x01, 0x02, 0x00, 0x00 };

            var reader = new DhcpBinaryReader(bytes);
            var collectionReader = new DhcpTaggedValueCollectionReader(reader);

            collectionReader.NextItem();

            Assert.False(collectionReader.HasNextItem());
        }
    }
}