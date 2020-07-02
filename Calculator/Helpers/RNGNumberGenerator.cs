using System;
using System.Security.Cryptography;

namespace Calculator.Helpers
{
    public class RNGNumberGenerator : INumberGenerator
    {
        protected static readonly RNGCryptoServiceProvider _rng = new RNGCryptoServiceProvider();

        /// <summary>
        /// Returns a non-negative random integer.
        /// Method uses RNGCryptoServiceProvider class.
        /// </summary>
        public int GetInt32()
        {
            byte[] bytes = new byte[sizeof(int)];
            _rng.GetBytes(bytes);

            return BitConverter.ToInt32(bytes, 0);
        }

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// Method uses RNGCryptoServiceProvider class.
        /// </summary>
        public int GetInt32(int maxVal)
        {
            return GetInt32(0, maxVal);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// Method uses RNGCryptoServiceProvider class.
        /// </summary>
        public int GetInt32(int minVal, int maxVal)
        {
            if (minVal > maxVal)
            {
                throw new ArgumentOutOfRangeException($"'{nameof(minVal)}' is greater than '{nameof(maxVal)}'");
            }

            if (minVal == maxVal) { return minVal; }

            byte[] bytes = new byte[sizeof(int)];
            _rng.GetBytes(bytes);
            int generatedValue = Math.Abs(BitConverter.ToInt32(bytes, 0));
            int diff = maxVal - minVal;
            int mod = generatedValue % diff;

            return minVal + mod;
        }

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// Method uses RNGCryptoServiceProvider class.
        /// </summary>
        public void FillBytes(byte[] bytes)
        {
            _rng.GetBytes(bytes);
        }
    }
}
