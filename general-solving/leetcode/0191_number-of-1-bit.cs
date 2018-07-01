/***************************************************************************
* Problem Name: Number of 1 Bits
* Problem URL : https://leetcode.com/problems/number-of-1-bits/
* Date        : Aug 5 2015
* Complexity  : O(n) Time (n = number of bits)
* Author      : Atiq Rahman
* Status      : Accepted (beats 68%)
* Desc        : Iterate over each bit and perform AND operation with a number
*               that exactly has that bit set and all other bits set to zero
* Notes       : 
* meta        : tag-bitwise, tag-easy
***************************************************************************/

public class Solution {
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
