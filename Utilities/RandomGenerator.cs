using System.Text;

namespace PracticalExam3.Utilities
{
    public static class RandomGenerator
    {
        private static readonly Random _random;

        static RandomGenerator()
        {
            _random = new Random();
        }

        public static string GetString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var result = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                result.Append(chars[_random.Next(chars.Length)]);
            }
            return result.ToString();
        }

        public static int GetInt(int min, int max)
        {
            var result = _random.Next(min, max);
            return result;
        }
    }
}
