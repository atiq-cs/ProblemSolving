/***************************************************************************
*   Problem Name:   Find modified fibonacci number given initial numbers and value of n
*   Problem URL :   https://www.hackerrank.com/challenges/fibonacci-modified
*   Date        :   July 22, 2015
*
*   Domain      :   algorithms/dynamic-programming
*                   https://www.hackerrank.com/domains/algorithms/dynamic-programming
*   Desc        :   Find modified fibonacci
*                   First implementation is DP, however this is not a good DP Problem
*
*   Complexity  :   Exponential considering growth of BigInteger Operations
*   Author      :   Atiq Rahman
*   Status      :   Terminated due to timeout (Test case and 3 and 6)
*   Notes       :   Same logic gets accepted using Java. However, C# is getting
*                    Timeout. Judge is most probably using an older implementation of C#
*                    compiler. No need to waste further time for judge's bad configuration.
*                    Discussion link: https://www.hackerrank.com/challenges/fibonacci-modified/forum
*                    Trick to get AC using C#: http://pastebin.com/F1MDkU2J
***************************************************************************/

using System;
using System.Collections.Generic;
using System.Numerics;

class Solution
{
    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string[] tokens = Console.ReadLine().Split();
        int first;
        Int32.TryParse(tokens[0], out first);
        int second;
        Int32.TryParse(tokens[1], out second);
        int steps;
        Int32.TryParse(tokens[2], out steps);

        if (steps == 1)
        {
            Console.WriteLine(first);
            return;
        }
        if (steps == 2)
        {
            Console.WriteLine(second);
            return;
        }

        // BigInteger ref: https://msdn.microsoft.com/en-us/library/system.numerics.biginteger%28v=vs.110%29.aspx?f=
        // 255&MSPPError=-2147217396
        BigInteger result = 0;
        BigInteger a = first;
        BigInteger b = second;
        for (int i = 2; i < steps; i++) {
            result = a + b * b;
            a = b;
            b = result;
        }
        Console.WriteLine(result);
    }
}

// First Implementation
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        string[] tokens = Console.ReadLine().Split();
        int first;
        Int32.TryParse(tokens[0], out first);
        int second;
        Int32.TryParse(tokens[1], out second);
        int steps;
        Int32.TryParse(tokens[2], out steps);
        
        BigInteger[] fibs = new BigInteger[steps];
        fibs[0] = first;
        fibs[1] = second;
        // DP Logic
        for (int i=2; i<steps; i++) {
            fibs[i] = fibs[i-1]*fibs[i-1] + fibs[i-2];
        }
        // considering if previous conversion 
        string result = fibs[steps-1].ToString();
        Console.WriteLine(result);
    }
}
