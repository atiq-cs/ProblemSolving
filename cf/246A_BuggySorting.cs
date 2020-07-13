/***************************************************************************************************
* Title : Buggy Sorting
* URL   : http://codeforces.com/problemset/problem/246/A
* Occasn: Codeforces Round #151 (Div. 2)
* Date  : 2017-11-01
* Comp  : O(n) 46ms, Space O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Here's Valera's program (consider 1 based index),
*   loop integer variable i from 1 to n-1
*   loop integer variable j from i to n-1
*   if (a[j] > a[j]+1)
*   Swap a[j] and a[j]+1
*   
*   To note, Valera's second loop is like Selection Sort.
*   Swap is like Bubble Sort or of the one that of Insertion Sort.
*   
*   Flaw,
*   First number in the array gets only one chance to be compared.
*   Second number in the array gets two chances.
*   If the smallest number lies in the last index it does not get enough
*   number of swap to propagate through the array and to be beseated at first
*   index.
*   
*   If second loop variable j started from the value 0 instead of i it would
*   complete the sorting.
*   Why?
*   Or if A[i] was used instead of A[j] in the swap that would also work.
*
* meta  : tag-algo-sort, tag-easy
***************************************************************************************************/
using System;

class BuggySorting {
  int n;

  public void TakeInput() {
    n = int.Parse(Console.ReadLine());
  }
  public int[] GetCounterExample() {
    if (n < 3)
      return null;
    int[] A = new int[n];
    for (int i = 0; i < n; i++)
      A[i] = n - i;
    return A;
  } 
}

public class CFSolution
{
  private static void Main() {
    BuggySorting buggySortingDemo = new BuggySorting();
    buggySortingDemo.TakeInput();
    int[] Example = buggySortingDemo.GetCounterExample();
    Console.WriteLine(Example == null? "-1" : string.Join(" ", Example));
  }
}
