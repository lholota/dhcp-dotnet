using System;
using System.Linq;
using System.Reflection;

namespace LH.Dhcp.vNext.Internals
{
    public class SemanticOptionsFactory
    {
        private static readonly object Lock = new object();

        private static SemanticOptionsFactory _instance;

        public static SemanticOptionsFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SemanticOptionsFactory();
                        }
                    }
                }

                return _instance;
            }
        }

        private SemanticOptionsFactory()
        {
        }

        public object CreateOption(Type optionType, BinaryValue optionValue)
        {
            var ctor = GetOptionConstructor(optionType);

            return ctor.Invoke(new object[] { optionValue });
        }

        private ConstructorInfo GetOptionConstructor(Type optionType)
        {
            var matchingCtors = optionType
                .GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public)
                .Where(x => x.GetParameters().Length == 1)
                .ToArray();

            if (matchingCtors.Length == 1)
            {
                return matchingCtors[0];
            }

            var ctorsWithAttribute = matchingCtors
                .Where(x => x.GetCustomAttribute<SemanticOptionsFactoryConstructorAttribute>() != null)
                .ToArray();

            if (ctorsWithAttribute.Length != 1)
            {
                // Note: this exception should be never thrown out to user code. It should be only thrown in tests.
                throw new Exception($"The option type {optionType} does not have a constructor to use to create a semantic option.");
            }

            return ctorsWithAttribute[0];
        }
    }
}