using System;

public class Solution
{
    const char WildChar = '.';
    const char AnyCount = '*';

    public bool IsMatch(string text, string pattern)
    {
        var memo = new bool?[text.Length + 1, pattern.Length + 1];

        return dp(text, pattern, memo, 0, 0);
    }

    bool dp(string text, string pattern, bool?[,] memo, int i, int j)
    {
        Console.WriteLine($"line {i},{j}");
        if (memo[i, j].HasValue)
        {
            Console.WriteLine($"cached memo {i},{j}:{memo[i, j]}");
            return memo[i, j].Value;
        }

        bool result;

        if (pattern.Length == j)
        {
            result = text.Length == i;
            memo[i, j] = result;
            return result;
        }

        var firstMatch = text.Length > i && (pattern[j] == text[i] || pattern[j] == WildChar);

        if (pattern.Length >= j + 2 && pattern[j + 1] == AnyCount)
        {
            result = dp(text, pattern, memo, i, j + 2)
                || (firstMatch && dp(text, pattern, memo, i + 1, j));
        }
        else
        {
            result = firstMatch && dp(text, pattern, memo, i + 1, j + 1);
        }

        memo[i, j] = result;
        return result;
    }
}