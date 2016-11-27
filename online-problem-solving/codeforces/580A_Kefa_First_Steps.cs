/***************************************************************************
*   Problem Name: Kefa and First Steps
*   Problem URL : http://codeforces.com/problemset/problem/580/A
*   Date        : Nov 26, 2016
*   Occasion    : Codeforces Round #321 (Div. 2)
*   Complexity  : O(n)
*   Author      : Atiq Rahman
*   Status      : Accepted (77ms)
*   Notes       : Linear DP, not LIS variation at all
*   meta        : tag-dp
***************************************************************************/
using System;

public class Demo {
    static uint run_lineardp(uint[] a, uint n) {
        uint cur_seq_len = 1;
        uint max_seq_len = 0;
        for (int i = 1; i < n; i++)
            if (a[i] >= a[i - 1])
                cur_seq_len++;
            else {
                max_seq_len = Math.Max(max_seq_len, cur_seq_len);
                cur_seq_len = 1;
            }
        return Math.Max(max_seq_len, cur_seq_len);
    }

    public static void Main() {
        uint n = uint.Parse(Console.ReadLine());
        string[] tokens = Console.ReadLine().Split();
        uint[] a = new uint[n];
        for (int i = 0; i < n; i++)
            a[i] = uint.Parse(tokens[i]);
        Console.WriteLine(run_lineardp(a,n));
    }
}
