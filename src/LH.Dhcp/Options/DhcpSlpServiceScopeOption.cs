using System;
using System.Collections.Generic;
using LH.Dhcp.Serialization;
using LH.Dhcp.Serialization.OptionSerialization;

namespace LH.Dhcp.Options
{
    [DhcpOption(DhcpOptionTypeCode.ServiceScope)]
    public class DhcpSlpServiceScopeOption : IDhcpOption
    {
        internal DhcpSlpServiceScopeOption(DhcpBinaryValue binaryValue)
        {
            OverrideStaticConfiguration = ParseOverrideFlag(binaryValue);
            Scopes = ParseScopes(binaryValue);
        }

        public bool OverrideStaticConfiguration { get; }

        public IReadOnlyList<string> Scopes { get; }

        private bool ParseOverrideFlag(DhcpBinaryValue binaryValue)
        {
            var firstByte = binaryValue.CreateSubsetValue(0, 1);

            return firstByte.AsBoolean();
        }

        private IReadOnlyList<string> ParseScopes(DhcpBinaryValue binaryValue)
        {
            var scopesBinaryValue = binaryValue.CreateSubsetValue(1, binaryValue.Length - 1);
            var scopesString = scopesBinaryValue.AsString();

            return scopesString.Split(',');
        }
    }
}