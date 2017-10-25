/***************************************************************************
*   Problem Name: Boredom
*   Problem URL : http://codeforces.com/problemset/problem/455/A
*   Date        : Dec 18, 2016
*   Occasion    : Codeforces Round #260 (Div. 1)
*   Complexity  : O(nlogn)
*   Author      : Atiq Rahman
*   Status      : Accepted (78ms)
*   Notes       : Linear DP
*     The way better way to read this problem is,
*     if we delete a number x from the sequence we have to delete all (x-1) and
*     (x+1) as well.

*     final solution is developed by accruing upon previous solutions for
*     example how many points can I make using n numbers depend upon max points
*     made by n-1 numbers or n-2 numbers
*                 
*     Alternate solution
*       Runs a 10^5 loop
*         https://www.quora.com/What-is-the-algorithmic-approach-to-solve-the-Codeforces-problem-Boredom
*                 this is how this problem actually should be solved
*                 
*     ArrayList vs List<> in C#
*       http://stackoverflow.com/questions/2309694/arraylist-vs-list-in-c-sharp
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

/* 
 draft
 Maximizing total points will depend on the following,
1 2 1 3 2 2 2 2 3
if we start with first 1
we have to delete all 2s
which gives us 
score =1 
but will lose all 2s that is a bad idea so,

let's delete the first 2
which gives us,
3 2 2 2 2 3

score = 2
now let's delete 2 again

score = 4

1 2 1 3 2 2 2 2 3

strategy: start with a number x where (x-1) and (x+1) is not very frequent?
or start with a number which is most frequent..

1 2
if frequency is same start with the one that is bigger


1 2 3
start with 3

how much can we get with a_k?
if we get a_k
 how much do we lose?

 
Naive solution: we find frequency of each of the numbers
Why does my solution look like greedy??

Because it is indeed greedy

1 2 1 3 2 2 2 2 3

After sorting
1 1 2 2 2 2 2 3 3

lose 1 
and we have,
1 2 2 2 2 2 3 3

count is really easy..
for each number we know,
we can get n_i * a_i where 

let's create a complicated case,
2 2 2 3 3

if it's equal taking any of those is fine...

1 1 2 2 2 3 3
now if take 
find total damange done by each number x,
s[x-1] + s[x+1]

score(x) = f[x] * x
damange(x) = s[x-1] + s[x+1]

*/
