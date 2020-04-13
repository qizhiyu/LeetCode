using System;
using System.Collections.Generic;
using System.Linq;

///<Summary>
///Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.
///</Summary>
public class Solution
{
    /// see 523. Continuous Subarray Sum
    public int FindMaxLength2(int[] numbers)
    {
        var memo = new Dictionary<int, int>(numbers.Length + 1);
        memo[0] = -1;

        var result = 0;
        var sum = 0;
        for (var i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i] == 0 ? -1 : 1;
            if (memo.ContainsKey(sum))
            {
                result = Math.Max(result, i - memo[sum]);
            }
            else
            {
                memo[sum] = i;
            }
        }

        return result;
    }
    public int FindMaxLength(int[] numbers)
    {
        var memo = new int?[numbers.Length + 1];

        if (numbers.Length < 2) return 0;
        var zero = numbers.Count(x => x == 0);
        var one = numbers.Length - zero;
        var max = Math.Min(zero, one);
        Console.WriteLine($"0,1,max:{zero},{one},{max}");

        var result = 0;

        for (var i = 0; i < numbers.Length; i++)
        {
            if (memo[i].HasValue) continue;
            //result is best possible
            if (i + result >= numbers.Length) break;

            var c = new int[2];
            var found = new List<int>();
            var length = 0;
            for (var j = i; j < numbers.Length; j++)
            {
                c[numbers[j]]++;

                if (c[0] == c[1])
                {
                    length = (j - i) + 1;
                    c[0] = c[1] = 0;
                    found.Add(j + 1);
                    continue;
                }

                //couldn't find more
                if (c[0] > max || c[1] > max)
                {
                    break;
                }

            }

            //Console.WriteLine($"{i}:{length}");

            for (var x = 0; x < found.Count; x++)
            {
                memo[found[x]] = length - found[x] + i;
            }

            result = Math.Max(result, length);
            if (length >= 2 * max) break;
        }

        return result;
    }
}