using System;

namespace MinimumPathSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = new Solution();
            var result = s.MinPathSum(new int[][]{
                new int[]{1,3,1},
                new int[]{1,5,1},
                new int[]{4,2,1},
            });
            
            if (result != 7) throw new Exception("wrong result");
        }
    }
}
