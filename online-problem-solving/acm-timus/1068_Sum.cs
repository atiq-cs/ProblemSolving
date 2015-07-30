/***************************************************************************
*   Problem Name:   Sum
*   Problem URL :   http://acm.timus.ru/problem.aspx?space=1&num=1068
*   Date        :   July 24, 2015
*
*   Algo, DS    :   Simple Sum
*   Desc        :   Arithmetic
*
*   Complexity  :   O(1)
*   Author      :   Atiq Rahman
*   Status      :   Accepted (Time: 0.046)
*   Notes       :   Example, how to write C# to solve: http://acm.timus.ru/help.aspx?topic=csharp&locale=en
*                   long integer reference: https://msdn.microsoft.com/en-us/library/ctetwysk.aspx
***************************************************************************/

using System;

public class Sum
{
    private static void Main()
    {
        // take input to num
        int N;
        Int32.TryParse(Console.ReadLine(), out N);

        // computer sum
        int result;
        if (N <= 0)  // sum from N to -1, 0, 1
            result = N * (1 - N) / 2 + 1;
        else  // sum from 1 to N
            result = N * (N + 1) / 2;

        // print sum
        Console.WriteLine(result);
    }
}
