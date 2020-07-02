namespace Calculator.Helpers
{
    public interface INumberGenerator
    {
        /// <summary>
        /// Returns a non-negative random integer.
        /// </summary>
        int GetInt32();

        /// <summary>
        /// Returns a non-negative random integer that is less than the specified maximum.
        /// </summary>
        int GetInt32(int maxVal);

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        int GetInt32(int minVal, int maxVal);

        /// <summary>
        /// Fills the elements of a specified array of bytes with random numbers.
        /// </summary>
        void FillBytes(byte[] bytes);
    }
}
