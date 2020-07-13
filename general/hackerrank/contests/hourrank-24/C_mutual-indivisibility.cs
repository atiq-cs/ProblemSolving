/***************************************************************************************************
* Title : Mutual Indivisibility
* URL   : hackerrank.com/contests/hourrank-24/challenges/mutual-indivisibility/
* Occasn: hourrank-24
* Date  : 2017-11-02
* Author: Atiq Rahman
* Comp  : O(n^2), O(n)
* Status: Accepted
* Notes : Start with n and try numbers in reverse direction n, n-1, n-2 and so on.. till n/2. From
*   n/2 start checking divisility with numbers added so far in the list.
* meta  : tag-divisibility, tag-number-theory, tag-algo-greedy
***************************************************************************************************/
using System;
using System.Collections.Generic;

class HKSolution
{
  static bool IsIndivisible(List<int> iList, int n) {
    for (int i=0; i<iList.Count; i++)
      if (iList[i]%n == 0)
        return false;
    return true;
  }

  static List<int> GetIndivisibleList(int a, int b, int size) {
    List<int> iList = new List<int>();
    int n=0;  // current size of indivisible list
    int i=b;

    for (; n<size && i>b/2; i--) {
      iList.Add(i);
      n++;
    }

    // i <= b/2 here
    for (; n<size && i>=a; i--)
      if (IsIndivisible(iList, i)) {
        iList.Add(i);
        n++;
      }
    return (n == size)?iList:null;
  }

  static void Main(String[] args) {
    int t = Convert.ToInt32(Console.ReadLine());
    for(int a0 = 0; a0 < t; a0++){
      // input
      string[] tokens_a = Console.ReadLine().Split(' ');
      int a = Convert.ToInt32(tokens_a[0]);
      int b = Convert.ToInt32(tokens_a[1]);
      int x = Convert.ToInt32(tokens_a[2]);
      // compute and output
      List<int> result = GetIndivisibleList(a, b, x);
      Console.WriteLine(result==null? "-1" : string.Join(" ", result));
    }
  }
}
