public class Solution
{
    public string Encrypt(string S)
    {
        string result=string.Empty;
        int b;
        foreach(char a in S)
        {
            if (a >= 32 && a <= 126)
            {
                b = ((int)a + 10);
                if (b > 126)
                    b = b + 32 - 126 - 1;
            }
            else
                b = a;

            result = result+ (char) b;
        }
        return result;
    }

    public string MinWindow(string S, string T)
    {
        int[] stats = new int[T.Length];
        int[][] pos = new int[T.Length][];
        for (int i = 0; i < T.Length; i++)
        {
            pos[i] = new int[S.Length];
            char c = T[i];

            int j = S.IndexOf(c);
            int k = 0;
            while (j >= 0)
            {
                pos[i][k++] = j;
                j = S.IndexOf(c, j + 1);
            }

            if (k == 0)
            {
                return "";
            }

            stats[i] = k;

            if (k == 1)
            {

            }
        }

        return null;
    }
}