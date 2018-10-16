/******************************************************************************
* Title       : z-sort
* URL         : http://codeforces.com/problemset/problem/652/B
*   http://www.lintcode.com/en/problem/wiggle-sort/
*   https://leetcode.com/problems/wiggle-sort (locked, so tried lintcode)
*               
* Occasion    : Educational Codeforces Round 10
* Date        : Nov 1 2017
* Complexity  : O(n) 46ms, Space O(n), 0KB
* Author      : Atiq Rahman
* Status      : Accepted (also on lintcode)
* Notes       : Even though this problem is called 'z-sort' in codeforces it
*   actually known as wiggle sort in other sites i.e., leetcode.
* 
*   Initial implementation is based on ref:
*   https://www.quora.com/What-is-an-efficient-method-to-wiggle-sort-an-array
*
* meta        : tag-algo-sort, tag-easy, tag-wiggle-sort
******************************************************************************/
using System;

class WiggleSorting {
  private int n;
  private int[] a;

  public void TakeInput() {
    n = int.Parse(Console.ReadLine());
    a = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
  }

  /*
   * Wiggle Sort:
   * Wiggle sort is easy if equality is allowed.
   *
   * This sort is hard when the condition is that,
   *  a[0] < a[1] > a[2] < a[3] > a[4] < a[5] and so on..
   *  as in https://leetcode.com/problems/wiggle-sort-ii
   */
  public void Sort() {
    if (n > 1 && a[0] > a[1])
      Swap(0, 1);
    
    for (int i = 2; i < n; i++) {
      // if i is even, then we know a[i-2] >= a[i-1]
      if (i % 2 == 0) {
        if (a[i - 1] < a[i])
          Swap(i-1, i);
      }
      // a[i-2] <= a[i-1]
      // if a[i-1] < a[i] derives a[i] is the greatest
      else {
        if (a[i - 1] > a[i]) // swap a[i-1], a[i]
          Swap(i - 1, i);
      }
    }
  }

  public void ShowOutput() {
    Console.WriteLine(string.Join(" ", a));
  }

  private void Swap(int  i, int j) {
    int temp = a[i];
    a[i] = a[j];
    a[j] = temp;
  }
}

public class CF_Solution {
  private static void Main() {
    WiggleSorting sortingDemo = new WiggleSorting();
    sortingDemo.TakeInput();
    sortingDemo.Sort();
    sortingDemo.ShowOutput();
  }
}
