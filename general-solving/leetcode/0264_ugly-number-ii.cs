/***************************************************************************************************
* Title : Ugly Number II
* URL   : https://leetcode.com/problems/ugly-number-ii/
* Date  : 2015-10-12
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Use the last chosen ugly numbers, multiply them (with 2,3,5) and keep building up solution
* ref   : http://www.geeksforgeeks.org/ugly-numbers/
* rel   : 'uva-online-judge\136_Ugly_Numbers.cpp'
* meta  : tag-math, tag-algo-dp, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
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
/*
Draft,
1, 2, 3, 4, 5, 6, 8, 9, 10, 12, 15, ...

2, 3, 4, 5
next numbr is either 2 * 2, 2 * 3, 

how i pointer works?
i2 -> 5, i2 points to 5
i3 -> 3
i5 -> 3

first number is 2
all of i2, i3,i5 points to 2

nextNum = Min(i2 * 2, i3 * 3, i5 * 5);

Then compare each of them with nextNum and increase pointer..
*/
