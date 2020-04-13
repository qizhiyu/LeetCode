using System;

namespace NaiveRegex
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();

            if (s.IsMatch("ab", ".*") != true ||
                s.IsMatch("", "x*") != true ||
                s.IsMatch("ababccdddab", "s*.*b*ab") != true ||
                s.IsMatch("abbab", "abs*.*b*ab") != true ||
                s.IsMatch("mississippi", "mis*is*p*.") != false)
            {
                throw new Exception("IsMatch not working");
            }

            Console.Write("Done");
        }
    }
}
