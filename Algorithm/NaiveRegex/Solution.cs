using System;

public class Solution
{
    const char WildChar = '.';
    const char AnyCount = '*';

    public bool IsMatch(string text, string pattern)
    {
        if (pattern.Length == 0) return text.Length == 0;

        var memo = new bool?[pattern.Length + 1, text.Length + 1];

        var firstMatch = text.Length > 0 && (pattern[0] == text[0] || pattern[0] == WildChar);

        if (pattern.Length >= 2 && pattern[1] == AnyCount)
        {
            return IsMatch(text, pattern.Substring(2)) || (firstMatch && IsMatch(text.Substring(1), pattern));
        }

        return firstMatch && IsMatch(text.Substring(1), pattern.Substring(1));
    }

    bool dp(string text, string pattern, bool?[,] memo, int i, int j)
    {
        if (memo[i, j].HasValue) return memo[i, j].Value;

        return false;
    }
}