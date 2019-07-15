using System;
using System.Collections.Generic;
using System.Net;
using LH.Dhcp.Serialization;
using LH.Dhcp.UnitTests.Extensions;
using Xunit;

namespace LH.Dhcp.UnitTests.Serialization
{
    // ReSharper disable once InconsistentNaming
    public class DhcpBinaryValueReader_AsShould
    {
        private static readonly byte[] TestBytes = "012233445566778899aabbccddeeff".AsHexBytes();

        [Theory]
        [InlineData(typeof(bool), 0)]
        [InlineData(typeof(bool), 2)]
        [InlineData(typeof(ushort), 0)]
        [InlineData(typeof(ushort), 1)]
        [InlineData(typeof(ushort), 3)]
        [InlineData(typeof(uint), 0)]
        [InlineData(typeof(uint), 3)]
        [InlineData(typeof(uint), 5)]
        [InlineData(typeof(int), 0)]
        [InlineData(typeof(int), 3)]
        [InlineData(typeof(int), 5)]
        [InlineData(typeof(byte), 0)]
        [InlineData(typeof(byte), 2)]
        [InlineData(typeof(IPAddress), 2)]
        [InlineData(typeof(IPAddress), 5)]
        [InlineData(typeof(IReadOnlyList<IPAddress>), 3)]
        [InlineData(typeof(IReadOnlyList<IPAddress>), 5)]
        [InlineData(typeof(IReadOnlyList<IPAddress>), 9)]
        [InlineData(typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>), 5)]
        [InlineData(typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>), 9)]
        [InlineData(typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>), 23)]
        public void ThrowInvalidOperationException_GivenInvalidTypeAndLengthCombination(Type outputType, byte length)
        {
            var valueReader = new DhcpBinaryValueReader(TestBytes, 0, length);

            Assert.Throws<InvalidOperationException>(
                () => valueReader.As(outputType));
        }

        public static IEnumerable<object[]> ValidLengthAndTypeCombinations = new List<object[]>
        {
            new object[] { typeof(bool), 1, true },
            new object[] { typeof(ushort), 2, 291U },
            new object[]{ typeof(uint), 4, 29013124U },
            new object[]{typeof(int), 4, 29013124U},
            new object[]{ typeof(byte), 1, 0x01 },
            new object[]{typeof(IPAddress), 4, IPAddress.Parse("0.17.34.51") },
            new object[]
            {
                typeof(IReadOnlyList<IPAddress>),
                8,
                new[]
                {
                    IPAddress.Parse("0.17.34.51"),
                    IPAddress.Parse("68.85.102.119")
                }
            },
            new object[]
            {
                typeof(IReadOnlyList<Tuple<IPAddress, IPAddress>>),
                8,
                new Tuple<IPAddress, IPAddress>(IPAddress.Parse("0.17.34.51"), IPAddress.Parse("68.85.102.119")), 
            }
        };

        [Theory]
        [MemberData(nameof(ValidLengthAndTypeCombinations))]
        public void ReturnValue_GivenValidTypeAndLengthCombination(Type outputType, byte length, object expectedValue)
        {
            var valueReader = new DhcpBinaryValueReader(TestBytes, 0, length);

            Assert.Equal(expectedValue, valueReader.As(outputType));
        }

        [Theory]
        [InlineData(typeof(List<IPAddress>))]
        public void ReturnFalse_GivenUnsupportedType(Type type)
        {
            var bytes = new byte[10];

            var valueReader = new DhcpBinaryValueReader(bytes, 0, 10);

            var ex = Assert.Throws<NotSupportedException>(
                () => valueReader.As(type));

            Assert.Contains(ex.Message, "types");
            Assert.Contains(ex.Message, "Int32");
            Assert.Contains(ex.Message, "Int16");
        }
    }
}
