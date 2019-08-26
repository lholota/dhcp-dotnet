using System;
using System.Collections.Generic;
using System.Linq;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    // ReSharper disable once InconsistentNaming
    public class WithOption_UInt16ListValueShould
    {
        public static IEnumerable<object[]> GetOverloads()
        {
            var testCases = new List<object[]>();

            testCases.Add(new object[]
            {
                new AddOptionDelegate<IReadOnlyList<ushort>>((builder, optionCode, value) => builder.WithOption(optionCode, value))
            });

            testCases.Add(new object[]
            {
                new AddOptionDelegate<IReadOnlyList<ushort>>((builder, optionCode, value) => builder.WithOption((DhcpOptionCode)optionCode, value))
            });

            return testCases;
        }

        public static IEnumerable<object[]> GetReservedCodesTestCases(int code)
        {
            foreach (var overload in GetOverloads())
            {
                yield return new[]
                {
                    overload[0],
                    (byte)code
                };
            }
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void AddOption(AddOptionDelegate<IReadOnlyList<ushort>> addOptionDelegate)
        {
            var expectedValue = new List<ushort>
            {
                10,
                60,
                50
            };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, expectedValue);

            var packet = builder.Build();

            Assert.Equal(expectedValue, packet.GetOption(10).AsUInt16List());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void AddOption_GivenValueLongerThan255Bytes(AddOptionDelegate<IReadOnlyList<ushort>> addOptionDelegate)
        {
            var expectedValue = Enumerable.Range(1, 500)
                .Select(x => (ushort)x)
                .ToArray();

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, expectedValue);

            var packet = builder.Build();

            Assert.Equal<ushort>(expectedValue, packet.GetOption(10).AsUInt16List());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void BeAbleToWriteMultipleOptions(AddOptionDelegate<IReadOnlyList<ushort>> addOptionDelegate)
        {
            var value1 = new List<ushort> { 10, 11 };
            var value2 = new List<ushort> { 20, 21 };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            addOptionDelegate.Invoke(builder, 10, value1);
            addOptionDelegate.Invoke(builder, 20, value2);

            var packet = builder.Build();

            Assert.Equal(value1, packet.GetOption(10).AsUInt16List());
            Assert.Equal(value2, packet.GetOption(20).AsUInt16List());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void BeAbleToWriteOptionsBeyondInitialBuffer(AddOptionDelegate<IReadOnlyList<ushort>> addOptionDelegate)
        {
            var value = new List<ushort> { 10, 11 };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            for (byte i = 68; i < 250; i++)
            {
                addOptionDelegate.Invoke(builder, i, value);
            }

            var packet = builder.Build();

            for (byte i = 68; i < 250; i++)
            {
                Assert.True(packet.HasOption(i));
            }
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void ThrowArgumentNullException_GivenNullValue(AddOptionDelegate<IReadOnlyList<ushort>> addOptionDelegate)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentNullException>(
                () => addOptionDelegate.Invoke(builder, 10, null));
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void ThrowArgumentException_GivenEmptyListValue(AddOptionDelegate<IReadOnlyList<ushort>> addOptionDelegate)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentException>(
                () => addOptionDelegate.Invoke(builder, 10, new List<ushort>()));
        }

        [Theory]
        [MemberData(nameof(GetReservedCodesTestCases), 0)]
        [MemberData(nameof(GetReservedCodesTestCases), 66)]
        [MemberData(nameof(GetReservedCodesTestCases), 67)]
        [MemberData(nameof(GetReservedCodesTestCases), 255)]
        public void ThrowArgumentOutOfRangeException_GivenReservedCode(AddOptionDelegate<IReadOnlyList<ushort>> addOptionDelegate, byte optionCode)
        {
            var value = new List<ushort> { 10, 11 };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => addOptionDelegate.Invoke(builder, optionCode, value));
        }
    }
}