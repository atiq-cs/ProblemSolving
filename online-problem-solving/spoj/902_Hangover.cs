/***************************************************************************
*   Problem     :  HangOver
*   URL         :  http://www.spoj.com/problems/HANGOVER/
*                   UVA 2294 (icpc problems archive)
*                   poj 1003
*   Date        :  July 27, 2015
*
*   Algo, DS    :  Simple Sum
*   Desc        :  Arithmetic
*   Complexity  :  O(1), constant time
*   Author      :  Atiq Rahman
*   Status      :  Not solved, could not stabilize the relation between log and the hangover result
*   Notes       :  Example, how to write C# to solve: http://acm.timus.ru/help.aspx?topic=csharp&locale=en
*   meta        :  tag-math 
***************************************************************************/

using System;

public class Solution
{
    private const int eps = 0e-9;
    private static void Main()
    {
        while (true)
        {
            // take input to num
            int N;
            float.TryParse(Console.ReadLine(), out N);
            if (Math.Abs(N - 0.00) < eps)
                break;

            float result = N + 2.5;
            // print sum
            Console.WriteLine(result);
        }
    }
}
