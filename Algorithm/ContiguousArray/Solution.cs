using System;
using System.Linq;

///<Summary>
///Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.
///</Summary>
public class Solution
{
    public int FindMaxLength(int[] numbers)
    {
        if (numbers.Length < 2) return 0;
        var zero = numbers.Count(x => x == 0);
        var one = numbers.Length - zero;
        var max = Math.Min(zero, one);

        var result = 0;

        for (var i = 0; i < numbers.Length; i++)
        {
            //result is best possible
            if (i + result >= numbers.Length) break;
            
            var c = new int[2];

            var length = 0;
            for (var j = i; j < numbers.Length; j++)
            {
                c[numbers[j]]++;

                if (c[0] == c[1])
                {
                    length = (j - i) + 1;
                    c[0] = c[1] = 0;
                    continue;
                }

                //couldn't find more
                if (c[0] > max || c[1] > max)
                {
                    break;
                }

            }
            Console.WriteLine($"{i}:{length}");
            result = Math.Max(result, length);
            if (length >= 2 * max) break;
        }

        return result;
    }
}