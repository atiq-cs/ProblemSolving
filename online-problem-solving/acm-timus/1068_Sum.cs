/***************************************************************************
*   Problem Name:   Sum
*   Problem URL :   http://acm.timus.ru/problem.aspx?space=1&num=1068
*   Date        :   July 23, 2015
*
*   Algo, DS    :   Binary Tree, Recursion
*   Desc        :   Preorder Traversal
*
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   Example, how to write C# to solve: http://acm.timus.ru/help.aspx?topic=csharp&locale=en
*                   had to use List instead
***************************************************************************/

using System;

public class Sum
{
    private static void Main()
    {
        // take input to num
        string in_str = Console.ReadLine();
        int N;
        Int32.TryParse(in_str, out N);

        long result;

        if (N < 0)
            result = N * (N - 1) / 2 + 1;
        else
            result = N * (N + 1) / 2;

        Console.WriteLine(result);
    }
}
