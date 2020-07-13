/***************************************************************************
*   Problem Name: Coprimes
*   Problem URL : http://acm.sgu.ru/problem.php?contest=0&problem=102
*   Date        : Oct 13, 2015
*
*   Complexity  : O(n log n)
*   Author      : Atiq Rahman
*   Status      : Accepted
*   Notes       : complexity of gcd is log n, ref:
                    http://stackoverflow.com/questions/9060816/running-time-of-euclids-gcd-algorithm
*   meta        : tag-easy, tag-gcd, tag-prime-number
***************************************************************************/

using System;

public class Solution
{
    private static void Main()
    {
        // take input
        int N = int.Parse(Console.ReadLine());
        int count = 0;
        for (int i = 2; i < N; i++)
            if (gcd(i, N) == 1)
                count++;
        Console.WriteLine(count + 1);
    }

    static int gcd(int a, int b)
    {
        return b == 0 ? a : gcd(b, a % b);
    }
}
