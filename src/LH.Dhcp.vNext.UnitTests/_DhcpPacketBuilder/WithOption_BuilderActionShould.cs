using System;
using System.Collections.Generic;
using System.Linq;
using LH.Dhcp.vNext.Options;
using Xunit;

namespace LH.Dhcp.vNext.UnitTests._DhcpPacketBuilder
{
    // ReSharper disable once InconsistentNaming
    public class WithOption_BuilderActionShould
    {
        public static IEnumerable<object[]> GetOverloads()
        {
            var testCases = new List<object[]>();

            testCases.Add(new object[]
            {
                new AddOptionDelegate<Action<IKeyValueCollectionBuilder>>((builder, optionCode, value) => builder.WithOption(optionCode, value))
            });

            testCases.Add(new object[]
            {
                new AddOptionDelegate<Action<IKeyValueCollectionBuilder>>((builder, optionCode, value) => builder.WithOption((DhcpOptionCode)optionCode, value))
            });

            return testCases;
        }

        public static IEnumerable<object[]> GetOptionCodesTestCases(int code)
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
        public void AddOption(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate)
        {
            Action<IKeyValueCollectionBuilder> setValuesAction = nestedBuilder =>
            {
                nestedBuilder.WithOption(20, 200);
                nestedBuilder.WithOption(21, 210);
            };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, setValuesAction);

            var packet = builder.Build();

            var optionValue = packet.GetOption(10).AsKeyValueCollection();

            Assert.Equal(2, optionValue.Count);
            Assert.Contains(optionValue, item => item.Key == 20 && item.Value.AsInt16() == 200);
            Assert.Contains(optionValue, item => item.Key == 21 && item.Value.AsInt16() == 210);
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void AddSingleValueLongerThan255Bytes(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate)
        {
            var expectedValue = "".PadRight(300, 'a');

            Action<IKeyValueCollectionBuilder> setValuesAction = nestedBuilder =>
            {
                nestedBuilder.WithOption(20, expectedValue);
            };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, setValuesAction);

            var packet = builder.Build();

            var optionValue = packet.GetOption(10).AsKeyValueCollection();

            Assert.Equal(20, optionValue.Single().Key);
            Assert.Equal(expectedValue, optionValue.Single().Value.AsString());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void AddValuesWithTotalLengthLongerThan255Bytes(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate)
        {
            var expectedValue = "".PadRight(300, 'a');

            Action<IKeyValueCollectionBuilder> setValuesAction = nestedBuilder =>
            {
                for (byte i = 1; i < 250; i++)
                {
                    nestedBuilder.WithOption(i, 500);
                }
            };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, setValuesAction);

            var packet = builder.Build();

            var optionValue = packet.GetOption(10).AsKeyValueCollection();

            Assert.Equal(20, optionValue.Single().Key);
            Assert.Equal(expectedValue, optionValue.Single().Value.AsString());
        }

        [Theory]
        [MemberData(nameof(GetOptionCodesTestCases), 66)]
        [MemberData(nameof(GetOptionCodesTestCases), 67)]
        public void AddOptionWithValuesCodedAsSpeciallyHandledOptionCodes(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate, byte itemCode)
        {
            // On the packet level, the option codes 66 & 67 are handled specially. In the nested collection, the user should
            // be able to use them explicitly as they don't have the special meaning in this context.

            Action<IKeyValueCollectionBuilder> setValuesAction = nestedBuilder =>
                {
                    nestedBuilder.WithOption(itemCode, 500);
                };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, setValuesAction);

            var packet = builder.Build();

            var optionValue = packet.GetOption(10).AsKeyValueCollection();

            Assert.Equal(itemCode, optionValue.Single().Key);
        }

        [Theory]
        [MemberData(nameof(GetOptionCodesTestCases), 0)]
        [MemberData(nameof(GetOptionCodesTestCases), 255)]
        public void ThrowArgumentOutOfRangeException_GivenReservedItemCode(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate, byte itemCode)
        {
            Action<IKeyValueCollectionBuilder> setValuesAction = nestedBuilder =>
            {
                nestedBuilder.WithOption(itemCode, 500);
            };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => addOptionDelegate.Invoke(builder, 10, setValuesAction));
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void BeAbleToWriteMultipleOptions(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate)
        {
            Action<IKeyValueCollectionBuilder> setValuesAction1 = nestedBuilder =>
            {
                nestedBuilder.WithOption(20, "Hello1");
            };

            Action<IKeyValueCollectionBuilder> setValuesAction2 = nestedBuilder =>
            {
                nestedBuilder.WithOption(40, "Hello2");
            };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, setValuesAction1);
            addOptionDelegate.Invoke(builder, 11, setValuesAction2);

            var packet = builder.Build();

            Assert.Equal("Hello1", packet.GetOption(20).AsKeyValueCollection().Single().Value.AsString());
            Assert.Equal("Hello2", packet.GetOption(40).AsKeyValueCollection().Single().Value.AsString());
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void BeAbleToWriteItemsBeyondInitialBuffer(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate)
        {
            Action<IKeyValueCollectionBuilder> setValuesAction = nestedBuilder =>
            {
                for (byte i = 1; i < 100; i++)
                {
                    nestedBuilder.WithOption(i, "Hello, World!");
                }
            };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);
            addOptionDelegate.Invoke(builder, 10, setValuesAction);

            var packet = builder.Build();

            Assert.Equal(99, packet.GetOption(10).AsKeyValueCollection().Count);
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void BeAbleToWriteOptionsBeyondInitialBuffer(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate)
        {
            Action<IKeyValueCollectionBuilder> setValuesAction = nestedBuilder =>
            {
                nestedBuilder.WithOption(10, "Hello, World!");
            };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            for (byte i = 68; i < 200; i++)
            {
                addOptionDelegate.Invoke(builder, i, setValuesAction);
            }

            var packet = builder.Build();

            Assert.Equal(99, packet.GetOption(10).AsKeyValueCollection().Count);
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void ThrowArgumentNullException_GivenNullValue(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentNullException>(
                () => addOptionDelegate.Invoke(builder, 10, null));
        }

        [Theory]
        [MemberData(nameof(GetOverloads))]
        public void ThrowArgumentException_WhenNoValueIsAdded(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate)
        {
            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Action<IKeyValueCollectionBuilder> setValuesAction = nestedBuilder => { };

            Assert.Throws<ArgumentException>(
                () => addOptionDelegate.Invoke(builder, 10, setValuesAction));
        }

        [Theory]
        [MemberData(nameof(GetOptionCodesTestCases), 0)]
        [MemberData(nameof(GetOptionCodesTestCases), 66)]
        [MemberData(nameof(GetOptionCodesTestCases), 67)]
        [MemberData(nameof(GetOptionCodesTestCases), 255)]
        public void ThrowArgumentOutOfRangeException_GivenReservedCode(AddOptionDelegate<Action<IKeyValueCollectionBuilder>> addOptionDelegate, byte optionCode)
        {
            Action<IKeyValueCollectionBuilder> setValuesAction = nestedBuilder =>
            {
                nestedBuilder.WithOption(40, "Hello2");
            };

            var builder = DhcpPacketBuilder.Create(DhcpMessageType.Ack);

            Assert.Throws<ArgumentOutOfRangeException>(
                () => addOptionDelegate.Invoke(builder, optionCode, setValuesAction));
        }
    }
}