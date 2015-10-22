/***************************************************************************
*   Problem Name:   A+B Problem
*   Problem URL :   http://acm.timus.ru/problem.aspx?space=1&num=1000
*   Date        :   Jul 26, 2015
*
*   Desc        :   Arithmetic
*
*   Complexity  :   constant time
*   Author      :   Atiq Rahman
*   Status      :   Accepted (Time: 0.015)
*   meta        :   tag-easy
***************************************************************************/

using System;

public class Solution
{
    private static void Main()
    {
        string[] tokens = Console.ReadLine().Split();
        Console.WriteLine(int.Parse(tokens[0]) + int.Parse(tokens[1]));
    }
}
