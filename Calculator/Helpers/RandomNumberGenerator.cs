namespace Calculator.Helpers
{
    using System;

    public class RandomNumberGenerator : INumberGenerator
    {
        protected static readonly Random _rnd = new();

        /// <summary>
        /// Returns a non-negative random integer. Method uses Random class.
        /// </summary>
        public int GetInt32() => _rnd.Next();

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// Method uses Random class.
        /// </summary>
        public int GetInt32(int maxVal) => _rnd.Next(maxVal);

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// Method uses Random class.
        /// </summary>
        public int GetInt32(int minVal, int maxVal) => _rnd.Next(minVal, maxVal);

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// Method uses Random class.
        /// </summary>
        public void FillBytes(byte[] bytes) => _rnd.NextBytes(bytes);
    }
}
