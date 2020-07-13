/***************************************************************************************************
* Title : z-sort
* URL   : http://codeforces.com/problemset/problem/652/B
*   http://www.lintcode.com/en/problem/wiggle-sort/
*   https://leetcode.com/problems/wiggle-sort (locked, so tried lintcode)
*
* Occasn: Educational Codeforces Round 10
* Date  : 2017-11-01
* Comp  : O(n) 46ms, Space O(n), 0KB
* Status: Accepted (also on lintcode)
* Notes : Even though this problem is called 'z-sort' in codeforces it
*   actually known as wiggle sort in other sites i.e., leetcode.
*   
*   Initial implementation is based on ref:
*   https://www.quora.com/What-is-an-efficient-method-to-wiggle-sort-an-array
*
* meta  : tag-algo-sort, tag-wiggle-sort, tag-easy
***************************************************************************************************/
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
          Swap<int>(ref a[i-1], ref a[i]);
      }
      // a[i-2] <= a[i-1]
      // if a[i-1] < a[i] derives a[i] is the greatest
      else {
        if (a[i - 1] > a[i]) // swap a[i-1], a[i]
          Swap<int>(ref a[i - 1], ref a[i]);
      }
    }
  }

  public void ShowOutput() {
    Console.WriteLine(string.Join(" ", a));
  }
}

public class CFSolution {
  private static void Main() {
    WiggleSorting wiggle = new WiggleSorting();
    wiggle.TakeInput();
    wiggle.Sort();
    wiggle.ShowOutput();
  }
}
