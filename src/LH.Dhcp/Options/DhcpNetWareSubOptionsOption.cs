using System;
using System.Collections.Generic;
using LH.Dhcp.Options.NetWare;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.NetWareIPOption)]
    public class DhcpNetWareSubOptionsOption : IDhcpOption
    {
        internal DhcpNetWareSubOptionsOption(DhcpBinaryValue binaryValue)
        {
            var firstByteBinaryValue = binaryValue.CreateSubsetValue(0, 1);

            State = ParseState(firstByteBinaryValue);

            var remainingValueLength = binaryValue.Length - 1;

            if (remainingValueLength > 0)
            {
                if (!StateAllowsSubOptions())
                {
                    throw new FormatException(
                        $"The NetWare sub options first byte is {State} which does not allow further sub options, but other sub options have been found.");
                }

                var subOptionsBinaryValue = binaryValue.CreateSubsetValue(1, binaryValue.Length - 1);

                SubOptions = ParseSubOptions(subOptionsBinaryValue);
            }
            else
            {
                SubOptions = new INetWareSubOption[0];
            }
        }

        public NetWareIpState State { get; }

        public IReadOnlyList<INetWareSubOption> SubOptions { get; }

        private IReadOnlyList<INetWareSubOption> ParseSubOptions(IBinaryValue binaryValue)
        {
            var valueCollection = binaryValue.AsTaggedValueCollection();
            var subOptions = new List<INetWareSubOption>();

            foreach (var keyValuePair in valueCollection)
            {
                if (Enum.IsDefined(typeof(NetWareIpState), keyValuePair.Key))
                {
                    // State should be only in first byte, others are ignored
                    continue;
                }

                switch (keyValuePair.Key)
                {
                    case 0x05:
                        {
                            var value = keyValuePair.Value.AsBoolean();
                            var subOption = new NetWareNsqBroadcastSubOption(value);

                            subOptions.Add(subOption);
                        }
                        break;

                    case 0x06:
                        {
                            var value = keyValuePair.Value.AsIpAddressList();
                            var subOption = new NetWarePreferredDssSubOption(value);

                            subOptions.Add(subOption);
                        }
                        break;

                    case 0x07:
                        {
                            var value = keyValuePair.Value.AsIpAddressList();
                            var subOption = new NetWareNearestNwipServerSubOption(value);

                            subOptions.Add(subOption);
                        }
                        break;

                    case 0x08:
                        {
                            var value = keyValuePair.Value.AsByte();
                            var subOption = new NetWareAutoRetriesSubOption(value);

                            subOptions.Add(subOption);
                        }
                        break;

                    case 0x09:
                        {
                            var value = keyValuePair.Value.AsByte();
                            var subOption = new NetWareAutoRetriesDelaySubOption(value);

                            subOptions.Add(subOption);
                        }
                        break;

                    case 0x0a:
                        {
                            var value = keyValuePair.Value.AsBoolean();
                            var subOption = new NetWareSupportVersion11SubOption(value);

                            subOptions.Add(subOption);
                        }
                        break;

                    case 0x0b:
                        {
                            var value = keyValuePair.Value.AsIpAddress();
                            var subOption = new NetWarePrimaryDssSubOption(value);

                            subOptions.Add(subOption);
                        }
                        break;
                }
            }

            return subOptions;
        }

        private NetWareIpState ParseState(IBinaryValue binaryValue)
        {
            var stateByte = binaryValue.AsByte();

            if (!Enum.IsDefined(typeof(NetWareIpState), stateByte))
            {
                throw new FormatException(
                    "The first byte of the NetWare SubOptions Option (DHCP Option code 63) must be between 0x01 and 0x04.");
            }

            return (NetWareIpState)stateByte;
        }

        private bool StateAllowsSubOptions()
        {
            return State == NetWareIpState.NwipExistInOptionsArea
                   || State == NetWareIpState.NwipExistInSnameFile;
        }
    }
}