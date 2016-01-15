/***************************************************************************
*   Problem Name:   Counter game
*   Problem URL :   https://www.hackerrank.com/challenges/counter-game
*   Date        :   Sept 18, 2015
*
*   Domain      :   algorithms/Bit Manipulation
*   Desc        :   Based on 64 bit unsigned integer all bit manipulation tricks
*                    ** The power of bit manipulation
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   meta        :   tag-bit-manipulation
***************************************************************************/
using System;

class Solution {
    static ulong getPowerRemainder(ulong n) {
        ulong m = 0x8000000000000000;
        uint p = 64;
        while (p > 0) {
            if ((m & n) > 0)
                return m;
            m >>= 1;
            p--;
        }
        return m;
    }

    static bool isPowerOfTwo(ulong n) {
        return (n != 0 && (n & (n - 1)) == 0);
    }

    static void Main(String[] args) {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0) {
            int count = 0;
            ulong n = ulong.Parse(Console.ReadLine());
            while (n > 1) {
                if (isPowerOfTwo(n))
                    n >>= 2;
                else
                    n = n ^ getPowerRemainder(n);
                count++;
            }
            Console.WriteLine((count % 2 == 0) ? "Richard" : "Louise");
        }
    }
}

/* Implementation of approx power of 2 using recursion: this is not used */
static ulong getPowerApproxValueRec(ulong n) {
    if (n == 2)
        return 1;
    if (n < 2)
        return 0;
    return getPowerApproxValueRec(n / 2) + 1;
}
