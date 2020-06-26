using System;
using System.Security.Cryptography;

namespace Calculator.Helpers
{
    public static class RandomNumberGenerator
    {
        static readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();

        public static int GetRandomInt32()
        {
            byte[] bytes = new byte[sizeof(int)];
            _rng.GetBytes(bytes);

            return BitConverter.ToInt32(bytes, 0);
        }

        public static int GetRandomInt32(int maxVal)
        {
            return GetRandomInt32(0, maxVal);
        }

        public static int GetRandomInt32(int minVal, int maxVal)
        {
            if (minVal > maxVal)
            {
                throw new ArgumentOutOfRangeException(nameof(minVal));
            }

            if (minVal == maxVal) { return minVal; }

            byte[] bytes = new byte[sizeof(int)];
            _rng.GetBytes(bytes);
            int generatedValue = Math.Abs(BitConverter.ToInt32(bytes, 0));
            int diff = maxVal - minVal;
            int mod = generatedValue % diff;

            return minVal + mod;
        }

        public static void GetBytes(byte[] bytes)
        {
            _rng.GetBytes(bytes);
        }
    }
}
