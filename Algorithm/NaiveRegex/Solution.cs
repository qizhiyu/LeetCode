using System;

public class Solution
{
    const char Wild = '.';
    const char Any = '*';

    public bool IsMatch(string s, string p)
    {
        if (p.Length == 0) return s.Length == 0;

        var memo = new bool?[p.Length + 1, s.Length + 1];
        //p.Length+1][s.Length+1]{} ;

        var firstMatch = s.Length > 0 && (p[0] == s[0] || p[0] == Wild);

        if (p.Length >= 2 && p[1] == Any)
        {
            return IsMatch(s, p.Substring(2)) || (firstMatch && IsMatch(s.Substring(1), p));
        }

        return firstMatch && IsMatch(s.Substring(1), p.Substring(1));
    }

    bool dp(string s, string p, bool?[,] memo, int i, int j)
    {
        if (memo[i, j].HasValue) return memo[i, j].Value;

        return false;
    }
}