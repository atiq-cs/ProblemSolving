/***************************************************************************************************
* Title : BerSU Ball
* URL   : http://codeforces.com/problemset/problem/489/B
* Occasn: Codeforces Round #277.5 (Div. 2)
* Date  : 2017-09-22
* Comp  : O(n^2); can be reduced to O(n lg n) by replacing linear
*   search with binary search
* Author: Atiq Rahman
* Status: Accepted
* Notes : Naive Approach:
*   Do a (n^2) loop to find how many girls match with boys
*   Similarly, compute it for boys. Since some of these will have multiple overlaps take the minimum
*   However, this intuition is wrong since there is overlapping of matches. A boy can be matched
*   with multiple boys which gives increased number of boys matched than original. Similarly, that
*   happens as well on the girls' side.
*   
*   Approach 2 (Improvement on naive):
*   Keep track of girls who got already matched while counting number of boys matched.
*   There is still a problem with this approach. A girl can get matched to somebody who could be
*   matched with somebody else.
*   This girl is marked as matched. However, there was a match with a boy who never matched with
*   anybody else.
*   
*   Approach 3, sorting before doing approach 2 solves this problem.
*   
*   sorting ensures maintaining the invariant matches are done in order. If a boy has only one
*   match. His match won't be matched with somebody else.
* meta  : tag-algo-dp, tag-algo-sort, tag-graph-dfs, tag-two-pointers
***************************************************************************************************/
using System;

public class CFSolution 
{
  public static void Main() {
    int  n = int.Parse(Console.ReadLine());   // discard n
    // dancing skill boys
    int[] a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    int m = int.Parse(Console.ReadLine());   // discard m
    // dancing skill girls
    int[] b = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    Array.Sort(a);
    Array.Sort(b);

    bool[] occupied = new bool[b.Length];

    int match_count = 0;    // number of boys matched with girls
    for (int i = 0; i < n; i++)
      for (int j = 0; j < m; j++)
        if (occupied[j] == false && Math.Abs(a[i] - b[j]) < 2) {
          match_count++;
          occupied[j] = true;
          break;
        }
    Console.WriteLine(match_count);
  }  
}


/*
Method 1: mark occuopied ones
first come first server basis
1 3
5 2 6 0
However, this example shows it does not work

Method 2:
Sort the arrays first. Then, the closer number from a would match with a
closer number from b. A closer number now cannot appear later in the sequence
and cannot be matched with another number.
This ensure max number of matches.

*/
