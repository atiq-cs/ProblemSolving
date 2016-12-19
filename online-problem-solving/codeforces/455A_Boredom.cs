/***************************************************************************
*   Problem Name: Boredom
*   Problem URL : http://codeforces.com/problemset/problem/455/A
*   Date        : Dec 18, 2016
*   Occasion    : Codeforces Round #260 (Div. 1)
*   Complexity  : O(nlogn)
*   Author      : Atiq Rahman
*   Status      : Accepted (78ms)
*   Notes       : Linear DP
*                 final solution is developed by accruing upon previous
*                 solutions for example how many points can I make using
*                 n numbers depend upon max points made by n-1 numbers or
*                 n-2 numbers
*                 
*                 Alternate solution
*                  Runs a 10^5 loop
* https://www.quora.com/What-is-the-algorithmic-approach-to-solve-the-Codeforces-problem-Boredom
*                   this is how this problem actually should be solved
*   meta        : tag-dynamic-programming
***************************************************************************/
using System;
using System.Collections.Generic;

public class CF_Solution {
    // get the score for each number and distinct values
    // find score for each item
    // score is s array and values is distinct values
    static void get_score_and_values(uint[] a, uint n, ref List<ulong> score,
        ref List<uint> d_values) {
        for (int i = 0; i < n; i++)
            if (i>0 && a[i - 1] == a[i])
                score[score.Count - 1] += a[i];
            else {
                score.Add(a[i]);
                d_values.Add(a[i]);
            }
    }
    // Implemented considering numbers are consecutive
    // Then, corrected for non-consecutive numbers
    static ulong run_lineardp(List<ulong> s, List<uint> values) {
        for (int i = 1; i < s.Count; i++) {
            int interval = 2;
            if (values[i - 1] + 1 == values[i]) interval++;
            s[i] += (i >= interval) ? Math.Max(s[i - interval], s[i - interval
                + 1]) : ((i == interval - 1) ? s[i - interval + 1] : 0);
        }
        // at least 1 number is ensured by main function
        return s.Count>=2?Math.Max(s[s.Count - 2], s[s.Count - 1]): s[s.Count - 1];
    }

    public static void Main()
    {
        uint n = uint.Parse(Console.ReadLine());
        if (n == 0)
            return;
        string[] tokens = Console.ReadLine().Split();
        uint[] a = new uint[n];
        for (int i = 0; i < n; i++)
            a[i] = uint.Parse(tokens[i]);
        Array.Sort(a);

        List<ulong> s = new List<ulong>();
        List<uint> values = new List<uint>();
        get_score_and_values(a, n, ref s, ref values);

        Console.WriteLine(run_lineardp(s, values));
    }
}
