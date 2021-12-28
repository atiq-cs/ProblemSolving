/***************************************************************************
*   Problem Name:  Gray code
*   Problem URL :  https://leetcode.com/problems/gray-code/
*   Date        :  Sept 28, 2015
*   Complexity  :  O(n log n)
*   Author      :  Atiq Rahman
*   Status      :  Accepted
*   Notes       :  Solved using both recursion and iterative DP
*                  Runtime improved after using 
*                    IList<int> grayList = new int[listSize];
*   meta        :  tag-recursion, tag-dynamic-programming, tag-interviews, tag-google
***************************************************************************/

public class Solution {
    public IList<int> GrayCode(int n) {
        int listSize = 0x1<<n;
        IList<int> grayList = new int[listSize];
        grayList[0] = 0;
        
        for (int i=1; i<=n ;i++) {
            int p = (int)0x1<<(i-1);
            for (int j=p;j<2*p;j++) {
                grayList[j] = p | grayList[2*p-j-1];
            }
        }
        return grayList;
    }
    // recursive version
    public IList<int> GrayCode(int n)
    {
        if (n == 0)
            return new List<int> { 0 };
        if (n == 1)
            return new List<int> { 0, 1 };

        IList<int> first_part = GrayCode(n - 1);
        List<int> second_part = new List<int>(first_part);
        // second_part reverse does not work if declared as IList<int> second_part
        // in that case probably use Array.Reverse
        second_part.Reverse();
        foreach (var item in second_part)
            first_part.Add(item | (0x1 << (n - 1)));
        return first_part;
    }

}
