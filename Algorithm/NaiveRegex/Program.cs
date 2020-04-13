using System;

namespace NaiveRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();

            if (s.IsMatch("ab", ".*") != true ||
                s.IsMatch("ab", "s*.*b*b") != true ||
                s.IsMatch("abab", "s*.*b*ab") != true ||
                s.IsMatch("abbab", "abs*.*b*ab") != true ||
                s.IsMatch("mississippi", "mis*is*p*.") != false)
            {
                throw new Exception("IsMatch not working");
            }

            Console.Write("Done");
        }
    }
}
