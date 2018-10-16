/***************************************************************************************************
* Title : Counting Bits
* URL   : https://leetcode.com/problems/counting-bits/
* Date  : 2017-09-18
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : DP implementation by observation
* meta  : tag-dp-lis, tag-bit-manip, tag-algo-dp, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
  public int[] CountBits(int num) {
    int[] bit_count = new int[num+1];
    bit_count[0] = 0;
    
    int d = 0;
    for (int i=1; i<=num; i++) {
      if (IsPowerOfTwo(i)) // can be replaced with comparison with a multiple of 2
      d = i;
      bit_count[i] = bit_count[i-d] + 1;
    }
    return bit_count;
  }
  // check if number is power of 2 in O(1)
  private bool IsPowerOfTwo(int n) {
    if (n != 0 && ((n-1)&n)==0)
      return true;
    return false;
  }
}

/*
Looking at the sequence,
  0 - 0
  1 - 1
 10 - 1
 11 - 2
100 - 1
101 - 2

  0 - 0
  1 - 1
  2 - 1
  3 - 2
  4 - 1
  5 - 2
  6 - 2
  7 - 3
  8 - 1
  9 - 2
 10 - 2

every time number reaches a power of 2 add a 1
 - 0 
so right after 0, add a 1, - 1
 - 1
 so right after 2, add a 1, - 2
 
 {0, 1, 1, 2}
 
 now repeat the whole sequence
 {1, 2, 2, 3}
 
 n-th index becoming (n-m)th + 1

{0}

d = 1
for (int i=1; i<=num; i++) {
  a[i] = a[i-d] + 1;
  if (i is power of 2)
    d *= 2;
}
1st index content = (1-1)-th + 1 + 1

Developing solution, 
i = 0, v = a[0]   = 0
d = 1;
i = 1, v = a[1-1] +1 = 1
i = 2, v = a[2-2]

It looks like every time of i is power of 2 d needs to be doubled.
* Next half can always be acquired using the result from first half
*/
