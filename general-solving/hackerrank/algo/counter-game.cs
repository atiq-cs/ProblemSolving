/***************************************************************************
*   Problem Name:   Alternating Characters
*   Problem URL :   https://www.hackerrank.com/challenges/alternating-characters
*   Date        :   Sept 18, 2015
*
*   Domain      :   algorithms/Strings
*   Desc        :   Find number of characters need to be deleted to make it alternating
*
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/

using System;

class Solution
{
    static void Main(String[] args)
    {
        int T = int.Parse(Console.ReadLine());
        while (T-- > 0)
        {
            String str = Console.ReadLine();
            // asssuming a value that is never likely to happen in input
            // another logic is to set it to first char of str and initialize count to -1
            char pre_ch = (char)0x7FFF;
            int count = 0;
            foreach (char ch in str)
            {
                if (ch == pre_ch)
                    count++;
                pre_ch = ch;
            }
            Console.WriteLine(count);
        }
    }
}
