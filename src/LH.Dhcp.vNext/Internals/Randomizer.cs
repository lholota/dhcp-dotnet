using System;
using System.Security.Cryptography;

namespace LH.Dhcp.vNext.Internals
{
    internal class Randomizer
    {
        private static readonly object Lock = new object();

        private static Randomizer _instance;

        public static Randomizer Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Randomizer();
                        }
                    }
                }

                return _instance;
            }
        }

        private readonly RNGCryptoServiceProvider _rngCryptoServiceProvider;

        private Randomizer()
        {
            _rngCryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public uint GenerateTransactionId()
        {
            var bytes = new byte[4];

            _rngCryptoServiceProvider.GetBytes(bytes);

            return BitConverter.ToUInt32(bytes, 0);
        }
    }
}