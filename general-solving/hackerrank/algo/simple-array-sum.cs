/***************************************************************************
*   Problem Name:   Simple Array Sum
*   Problem URL :   https://www.hackerrank.com/challenges/simple-array-sum
*   Date        :   Sept 07, 2015
*
*   Domain      :   algorithms/warmup
*                   https://www.hackerrank.com/domains/algorithms/warmup
*   Desc        :   Find sum of given integers
*
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   Practicing C# IO
***************************************************************************/

using System;
using System.Collections.Generic;

class Solution
{
    static void Main(String[] args)
    {
        int N = int.Parse(Console.ReadLine());

        string[] tokens = Console.ReadLine().Split();
        int sum = 0;
        for (int i = 0; i < N; i++)
        {
            int num = int.Parse(tokens[i]);
            sum += num;
        }
        Console.WriteLine(sum);
    }
}
