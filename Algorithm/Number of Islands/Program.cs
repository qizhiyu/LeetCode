using System;

namespace NumberOfIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
	        var result = s.NumIslands(new []{3,7,8});
	
            Console.WriteLine($"{result}");
        }
    }
}
