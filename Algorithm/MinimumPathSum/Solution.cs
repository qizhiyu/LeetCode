using System;

using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public int MinPathSum(int[][] grid)
    {
        if (grid.Length == 0 || grid[0].Length == 0) return 0;
        var cache = new Dictionary<string, int>();
        return Dp(grid, 0, 0, grid.Length - 1, grid[0].Length - 1, cache);
    }

    int Dp(int[][] grid, int top, int left, int bottom, int right, Dictionary<string, int> cache)
    {
        if (top >= grid.Length || bottom >= grid.Length ||
          left >= grid[0].Length || right >= grid[0].Length)
            return Int32.MaxValue;

        var key = $"{top}-{left}-{bottom}-{right}";
        if (cache.ContainsKey(key)) return cache[key];

        int sum = 0;
        if (top == bottom)
        {
            for (var i = left; i <= right; i++)
            {
                sum += grid[top][i];
            }
            cache[key] = sum;
            return sum;
        }

        if (left == right)
        {
            for (var i = top; i <= bottom; i++)
            {
                sum += grid[i][left];
            }
            cache[key] = sum;

            return sum;
        }
        sum = grid[top][left] + Math.Min(Dp(grid, top + 1, left, bottom, right, cache), Dp(grid, top, left + 1, bottom, right, cache));
        cache[key] = sum;

        return sum;
    }
}