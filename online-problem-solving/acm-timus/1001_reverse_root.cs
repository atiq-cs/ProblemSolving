/***************************************************************************
*   Problem Name:   Sum
*   Problem URL :   http://acm.timus.ru/problem.aspx?space=1&num=1001
*   Date        :   Oct 9, 2015
*
*   Desc        :   Arithmetic
*
*   Complexity  :   O(1)
*   Author      :   Atiq Rahman
*   Status      :   Accepted (Time: 0.046)
*   Notes       :   Demonstrates how to read till EOF from input using StreamReader
*                   Demonstrates use of decimal precision formatting in C#
*   meta        :   tag-easy
***************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
public class Solution
{
    static void Main(String[] args)
    {
        StreamReader streamReader = new StreamReader(Console.OpenStandardInput());
        string[] tokens = streamReader.ReadToEnd().Split();
        List<double> roots = new List<double>();

        foreach (string token in tokens)
            if (token.Length > 0)
                roots.Add(Math.Sqrt(ulong.Parse(token)));
        for (int i = roots.Count - 1; i >= 0; i--)
            Console.WriteLine("{0:F4}", roots[i]);
    }
}
