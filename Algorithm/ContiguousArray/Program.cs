using System;

namespace ContiguousArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            if (s.FindMaxLength(new[] { 0, 1, 0, 1, 1, 0, 1 }) != 6
                || s.FindMaxLength(new[] { 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0 }) != 6)
            {
                throw new ApplicationException("Incorrect");
            }

            Console.WriteLine("Done!");
        }
    }
}
