/***************************************************************************
* Title       : X-MEN
* URL         : http://www.spoj.com/problems/XMEN/
* Occasion    : CodeCraft 13 -> classical
* Date        : Oct 11 2017
* Complexity  : O(n lg n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : 
* meta        : tag-algo-dp, tag-dp-lis, tag-dp-lcs
***************************************************************************/
using System;
using System.Collections.Generic;

public class LISDemo {
  List<int> lis;
  int n;
  int[] X, Y;

  public int GetLengthOfLIS() {
    // Initialization
    lis = new List<int>();
    int limit = -1;

    for (int i = 0; i<n; i++) {
      // get lower bound
      int j = BSearch(Y[i], 0, limit) + 1;
      // returned index does not exist
      // that means it's time to create that index
      if (j == lis.Count) {
        lis.Add(Y[i]);
        limit++;
      }
      // update lis if item is greater
      else if (lis[j] > Y[i])
        lis[j] = Y[i];
        /* to allow equal items in subsequence
         * not required for this problem
         */
    }
    return limit+1;
  }

  public void TakeInput() {
    n = int.Parse(Console.ReadLine());
    X = new int[n];
    Y = new int[n];
    string[] tokens = Console.ReadLine().Split();
    for (int i = 0; i < n; i++) {
      int num = int.Parse(tokens[i]);
      X[num - 1] = i;
    }

    tokens = Console.ReadLine().Split();
    for (int i = 0; i < n; i++) {
      int num = int.Parse(tokens[i]);
      Y[i] = X[num - 1];
    }
  }


   // Modified Binary Search to return immediate smaller one if looked up item is not found.
  private int BSearch(int item, int start, int end) {
    int mid = (start + end) / 2;
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
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      LISDemo demoLIS = new LISDemo();
      demoLIS.TakeInput();
      Console.WriteLine(demoLIS.GetLengthOfLIS());
    }
  }
}
