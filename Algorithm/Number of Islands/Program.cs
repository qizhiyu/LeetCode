using System;

namespace NumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var result = s.NumIslands(new char[][]{
                new[]{'1','0','1','0','0'},
                new[]{'1','1','1','0','0'},
                new[]{'0','0','0','1','1'},
                new[]{'1','1','1','0','0'},
                new[]{'1','0','1','0','0'},
                });

            Console.WriteLine($"{result}");
            if (result != 3)
            {
                throw new Exception("incorrect");
            }
        }
    }
}
