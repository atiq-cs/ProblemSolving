/***************************************************************************
*   Problem Name:   Determines if given string has some properties
*   Problem URL :   https://www.hackerrank.com/challenges/funny-string
*   Domain      :   algorithms/strings
*   DateTime    :   July 24, 2015
*   Desc        :   Implements
*                   string reverse etc..
*
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/
using System;

class Solution {
    static void Main(String[] args) {
        string line;
        int nTestCases = Int32.Parse(Console.ReadLine());
        while (nTestCases-- >0) {
            line = Console.ReadLine();
            if (!String.IsNullOrEmpty(line)) {
                if (isFunny(line))
                    Console.WriteLine("Funny");
                else
                    Console.WriteLine("Not Funny");
            }
        }
    }

    static bool isFunny(string str) {
        char[] first = str.ToCharArray();
        // get reverse of the string
        char[] second = str.ToCharArray(); Array.Reverse(second);

        for (int i = 1; i < first.Length; i++) {
            if (Math.Abs(first[i] - first[i - 1]) != Math.Abs(second[i] - second[i - 1]))
                return false;
        }
        return true;
    }
}
