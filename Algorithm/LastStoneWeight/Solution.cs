using System.Linq;
using System.Collections.Generic;

public class Solution
{
    public int LastStoneWeight(int[] stones)
    {
        if (stones == null || stones.Length == 0) return 0;

        var sortedStones = stones.OrderBy(s => s).ToList();
        var debris = new List<int>(stones.Length);

        var l = sortedStones.Count();
        var debrisCount = 0;
        while ((l + debrisCount) > 1)
        {
            var stone1 = 0;
            var stone2 = 0;

            var x0 = debrisCount > 0 ? debris[debrisCount - 1] : -1;
            var y0 = l > 0 ? sortedStones[l - 1] : -1;
            if (x0 >= y0)
            {
                debris.RemoveAt(--debrisCount);
                stone1 = x0;
                if (debrisCount == 0)
                {
                    stone2 = y0;
                    l--;
                }
                else
                {
                    x0 = debris[debrisCount - 1];
                    if (x0 >= y0)
                    {
                        debris.RemoveAt(--debrisCount);
                        stone2 = x0;
                    }
                    else
                    {
                        l--;
                        stone2 = y0;
                    }
                }
            }
            else
            {
                l--;
                stone1 = y0;

                y0 = l > 0 ? sortedStones[l - 1] : -1;
                if (x0 >= y0)
                {
                    debrisCount--;
                    debris.RemoveAt(debrisCount);
                    stone2 = x0;
                }
                else
                {
                    l--;
                    stone2 = y0;
                }
            }

            var remain = stone1 - stone2;

            if (remain > 0)
            {
                var pos = debris.BinarySearch(remain);
                if (pos < 0) pos = ~pos;
                debris.Insert(pos, remain);
                debrisCount++;
            }
        }

        return l == 0 ? (debrisCount == 0 ? 0 : debris[0]) : sortedStones[0];
    }
}
