/***************************************************************************
* Title       : Easy Longest Increasing Subsequence
* URL         : http://www.spoj.com/problems/ELIS/
* Occasion    : tutorial
* Date        : 2017-10-11
* Complexity  : O(n lg n)
* Status      : Accepted
* Notes       : tutorial input set should be trivial
* meta        : tag-algo-dp, tag-dp-lis, tag-algo-bsearch
***************************************************************************/
using System;
using System.Collections.Generic;

public class LISDemo {
  List<int> lis;
  int n;
  int[] A;

  public int GetLengthOfLIS() {
    // Initialization
    lis = new List<int>();
    int limit = -1;

    for (int i = 0; i<n; i++) {
      // get lower bound
      int j = BSearch(A[i], 0, limit) + 1;
      // returned index does not exist
      // that means it's time to create that index
      if (j == lis.Count) {
        lis.Add(A[i]);
        limit++;
      }
      // update lis if item is greater
      else if (lis[j] > A[i])
        lis[j] = A[i];
        /* to allow equal items in subsequence
         * not required for this problem
         */
    }
    return limit+1;
  }

  public void TakeInput() {
    n = int.Parse(Console.ReadLine());
    A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
  }

  /*
   * Modified Binary Search to return immediate smaller one if item looked up is
   * not found.
   */
  private int BSearch(int item, int start, int end) {
    int mid = start + (end-start) / 2;
    // lower_bound: return lower index
    if (start > end)
      return end;
    // to allow equal items in the subsequence use <=
    else if (lis[mid] < item)
      return BSearch(item, mid + 1, end);
    else
      return BSearch(item, start, mid - 1);
  }
}

public class Demo {
  public static void Main() {
    LISDemo demoLIS = new LISDemo();
    demoLIS.TakeInput();
    Console.WriteLine(demoLIS.GetLengthOfLIS());
  }
}
