using System;

namespace NaiveRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();

            if (s.IsMatch("ab", ".*") != true ||
                s.IsMatch("mississippi", "mis*is*p*.") != false)
            {
                throw new Exception("IsMatch not working");
            }
        }
    }
}
