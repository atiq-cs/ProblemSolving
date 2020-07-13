/***************************************************************************************************
* Title : Permutation
* URL   : http://codeforces.com/problemset/problem/137/B
* Date  : 2015-10-25
* Comp  : O(n), O(n)
* Status: Accepted
* Notes : 
* Notes : What does the problem Ask?
*   The sequence of n integers is called a permutation if it contains all integers from 1 to n
*   exactly once.
*   Our task is to find how many numbers are missing from the given list to get a permutation
* meta  : tag-ds-hashset, tag-permutation, tag-easy
***************************************************************************************************/
using System;

public class CFSolution
{
  private static void Main() {
    int N = int.Parse(Console.ReadLine());
    string[] tokens = Console.ReadLine().Split();
    bool[] bHashSet = new bool[N];
    int countItems = 0;

    foreach (string token in tokens) {
      int item = int.Parse(token);

      if (item <= N && bHashSet[item - 1] == false) {
        bHashSet[item - 1] = true;
        countItems++;
      }
    }

    Console.WriteLine(N - countItems);
  }
}
