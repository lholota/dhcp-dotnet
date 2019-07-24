using System;
using System.Linq;
using System.Reflection;
using LH.Dhcp.Options;

namespace LH.Dhcp.Serialization.OptionSerialization
{
    internal class DhcpOptionType
    {
        private readonly bool _isFlag;
        private readonly ConstructorInfo _optionTypeCtor;

        public DhcpOptionType(Type optionType)
        {
            _optionTypeCtor = GetOptionConstructor(optionType);

            _isFlag = _optionTypeCtor.GetParameters().Length == 0;
        }

        public IDhcpOption CreateOption(IBinaryValue binaryValue)
        {
            if (_isFlag)
            {
                return (IDhcpOption)_optionTypeCtor.Invoke(null);
            }

            var ctorParameter = _optionTypeCtor.GetParameters()[0];

            if (typeof(IBinaryValue).IsAssignableFrom(ctorParameter.ParameterType))
            {
                return (IDhcpOption)_optionTypeCtor.Invoke(new[] { binaryValue });
            }

            var convertedValue = binaryValue.As(ctorParameter.ParameterType);

            return (IDhcpOption)_optionTypeCtor.Invoke(new[] { convertedValue });
        }

        private ConstructorInfo GetOptionConstructor(Type optionType)
        {
            var matchingCtors = optionType
                .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(x => x.GetParameters().Length <= 1)
                .ToArray();

            if (matchingCtors.Length == 1)
            {
                return matchingCtors[0];
            }

            var ctorsWithAttribute = matchingCtors
                .Where(x => x.GetCustomAttribute<CreateOptionConstructorAttribute>() != null)
                .ToArray();

            if (ctorsWithAttribute.Length != 1)
            {
                // Note: this exception should be never thrown out to user code. It should be only thrown in tests.
                throw new Exception($"The option type {optionType} does not have a constructor to create option during deserialization.");
            }

            return ctorsWithAttribute[0];
        }
    }
}
