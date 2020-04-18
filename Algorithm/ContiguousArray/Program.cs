using System;
using System.Diagnostics;

namespace ContiguousArray
{
    class Program
    {
        static void Main(string[] args)
        {
            var data1 = new[] { 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1 };

            var s = new Solution();
            if (
                 // s.FindMaxLength(new[] { 0, 1, 0, 1, 1, 0, 1 }) != 6
                 // || s.FindMaxLength(new[] { 0, 1, 0, 1, 1, 0, 1, 1, 0, 1, 0 }) != 6
                 // ||
                 s.FindMaxLength(data1) != 30)
            {
                throw new ApplicationException("Incorrect");
            }
            int[] v = CreateArray(50000);

            var watch = Stopwatch.StartNew();
            var result2 = s.FindMaxLength2(v);
            Console.WriteLine($"FindMaxLength2 in {watch.ElapsedMilliseconds}ms! {result2}");
            watch.Restart();
            var result = s.FindMaxLength(v);
            watch.Stop();

            Console.WriteLine($"Done in {watch.ElapsedMilliseconds}ms! {result}");
        }

        static int[] CreateArray(int length)
        {
            var random = new Random();
            var v = new int[length];
            var seed = random.Next();
            for (var i = 0; i < length; i++)
            {
                v[i] = seed & 1;
                seed = seed >> 1;
                if ((i + 1) % 32 == 0)
                {
                    seed = random.Next();
                }
            }
            return v;
        }
    }
}
