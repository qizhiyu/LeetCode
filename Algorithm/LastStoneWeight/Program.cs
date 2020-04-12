using System;

namespace LastStoneWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
	        var result = s.LastStoneWeight(new []{3,7,8});
	
            Console.WriteLine($"{result}");
        }
    }
}
