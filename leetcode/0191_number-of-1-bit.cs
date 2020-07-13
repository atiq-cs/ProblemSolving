/***************************************************************************************************
* Title : Number of 1 Bits
* URL   : https://leetcode.com/problems/number-of-1-bits/
* Date  : 2015-08-05
* Comp  : O(k) Time (k = number of 1 bits)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Optimized,
*   example 0191
*   10100
*   10011
*   after and op,
*   10000
*   01111
*   after and op,
*   0
*   and count is 2.
*
*   Naive approach, Iterate over each bit and perform AND operation with a number that exactly has
*   that bit set and all other bits set to zero
* meta  : tag-bit-manip, tag-leetcode-easy
***************************************************************************************************/
public class Solution {
  // Optimized - O(k) - EPI
  public int HammingWeight(uint n)
  {
    int count = 0;
    while (n != 0) {
      count++;
      n = n & (n - 1);
    }
    return count;
  }

  // naive - O(N)
  public int HammingWeight(uint n) {
    uint m = 0x1;
    int count = 0;
    
    for (int i=0; i< 8 * sizeof(uint); i++) {
      if ((n&m) > 0)
        count++;
      m <<= 1;
    }
    return count;
  }
}
