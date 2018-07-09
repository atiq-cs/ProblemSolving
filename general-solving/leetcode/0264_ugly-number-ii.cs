/***************************************************************************
*   Problem Name:  Ugly Number II
*   Problem URL :  https://leetcode.com/problems/ugly-number-ii/
*   Date        :  Oct 12, 2015
*   Complexity  :  O(n)
*   Author      :  Atiq Rahman
*   Status      :  Accepted
*   Notes       :  Use the last chosen ugly numbers, multiply them (with 2,3,5)
*                  and keep building
*   Ref         :  http://www.geeksforgeeks.org/ugly-numbers/
*   meta        :  tag-dynamic-programming
***************************************************************************/

public class Solution {
    public int NthUglyNumber(int n) {
        int[] ugly_nums = new int[n + 1];
        int i2, i3, i5; i2 = i3 = i5 = 0;
        ugly_nums[0] = 1;
        for (int i = 1; i < n;) {
            ugly_nums[i] = GetMin(ugly_nums[i2] * 2, ugly_nums[i3] * 3, ugly_nums[i5] * 5);
            if (ugly_nums[i - 1] != ugly_nums[i])
                i++;
            if (ugly_nums[i] == ugly_nums[i2] * 2)
                i2++;
            else if (ugly_nums[i] == ugly_nums[i3] * 3)
                i3++;
            else if (ugly_nums[i] == ugly_nums[i5] * 5)
                i5++;
        }
        return ugly_nums[n - 1];
    }
    int GetMin(int a, int b, int c) { return Math.Min(Math.Min(a, b), c); }
}