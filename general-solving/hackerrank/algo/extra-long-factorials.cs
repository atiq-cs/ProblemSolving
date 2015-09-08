/***************************************************************************
*   Problem Name:   Extra long factorials
*   Problem URL :   https://www.hackerrank.com/challenges/extra-long-factorials
*   Date        :   Sept 07, 2015
*
*   Domain      :   algorithms/warmup
*                   https://www.hackerrank.com/domains/algorithms/warmup

*   Desc        :   Use BigInteger to calculate factorial
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/

using System;
using System.Collections.Generic;
using System.Numerics;

class Solution
{
    static void Main(String[] args)
    {
        int N = int.Parse(Console.ReadLine());
        Console.WriteLine(GetFactorial(N));
    }

    static BigInteger GetFactorial(int n)
    {
        BigInteger fact = 1;
        for (int i = 2; i <= n; i++)
            fact *= i;
        return fact;
    }
}
