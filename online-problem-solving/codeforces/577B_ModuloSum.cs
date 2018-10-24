/***************************************************************************
* Title : Modulo Sum
* URL   : http://codeforces.com/problemset/problem/577/B
* Contst: Codeforces Round #290 (Div. 2)
* Date  : 2018-05-18
* Author: Atiq Rahman
* Comp  : O(N * 2^n)
* Status: TLE
* Notes : Hints here: http://codeforces.com/blog/entry/20226
* meta  : tag-algo-dp
***************************************************************************/
using System;
using System.Collections.Generic;

public class SubsequenceUtil {
  private long[] nums;
  int n, m;
  public bool IsSubSequenceDivisible() {
    HashSet<long> subSequenceSet = new HashSet<long>();

    for (int i = 1; i < nums.Length; i++) {
      subSequenceSet.Add(nums[i - 1]);
      // List<int> newSubsets = new List<int>();
      HashSet<long> subSeqs = new HashSet<long>();

      foreach (long sum in subSequenceSet) {
        long newSubset = sum + nums[i];
        if (newSubset%m == 0)
          return true;
        // newSubsets.Add(newSubset);
        subSeqs.Add(newSubset);
      }
      subSequenceSet.UnionWith(subSeqs);
    }
    return nums[nums.Length - 1]%m == 0;
  }

  public void TakeInput() {
    string[] tokens = Console.ReadLine().Split();
    n = int.Parse(tokens[0]);
    m = int.Parse(tokens[1]);

    nums = new long[n];
    tokens = Console.ReadLine().Split();
    for (int i=0; i<n; i++)
      nums[i] = long.Parse(tokens[i]);
  }
}

public class CFSolution {
  public static void Main() {
    SubsequenceUtil demo = new SubsequenceUtil();
    demo.TakeInput();
    Console.WriteLine(demo.IsSubSequenceDivisible()? "YES" : "NO");
  }
}

/*
Last one failed:
997 997
873559963 873559963 873559963 873559963 873559963 873559963 873559963 873559963
873559963 873559963 873559963 873559963 873559963 873559963 873559963 873559963
873559963 873559963 873559963 873559963 873559963 873559963 873559963 873559963
873559963 873559963 873559963 873559963 873559963 873559963 873559963 873559963
873559963 873559963 873559963 873559963 873559963 873559963 873559963 873559963
873559963 873559963 873559963 873559963 873559963 873559963 873559963 873559963
873559963 873559963 87...
Output
NO
Answer
YES
Checker Log
wrong answer expected YES, found NO
*/
