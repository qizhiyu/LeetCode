using System.Linq;
using System.Collections.Generic;

public class Solution {
    public int LastStoneWeight(int[] stones) {
        if(stones==null || stones.Length==0) return 0;
        
        var list = stones.OrderBy(s=>s).ToList();
        var list2= new List<int>(stones.Length);
        
        var l = list.Count();
        var k = 0;
        while((l+k)>1){
            var x = 0;
            var y = 0;
            
            var x0 = k>0?list2[k-1]:-1;
            var y0 = l>0?list[l-1]:-1;
            if(x0>=y0){
                k--;
                list2.RemoveAt(k);
                x = x0;
                if(k==0){
                    y = y0;
                    l--;
                }else{
                    x0 = list2[k-1];
                    if(x0>=y0){
                        k--;
                        list2.RemoveAt(k);
                        y= x0;
                    }else{
                        l--;
                        y = y0;
                    }
                }
            }else{
                l--;
                x = y0;
                
                y0 = l>0?list[l-1]:-1;
                if(x0>=y0){
                    k--;
                    list2.RemoveAt(k);
                    y = x0;
                }else{
                    l--;
                    y = y0;
                }
            }
            
            var w = x-y;

            if(w>0){
                var pos = list2.BinarySearch(w);
				if(pos<0) pos=~pos;
                list2.Insert(pos, w);
                k++;
            }
        }
        
        return l==0?( k==0?0:list2[0]):list[0];
    }
}
