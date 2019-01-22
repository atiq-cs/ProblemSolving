/***************************************************************************************************
* Title : Number of Ways
* URL   : http://codeforces.com/problemset/problem/466/C
* Occasn: Codeforces Round #266 (Div. 2)
* Date  : 2018-11-10 
* Comp  : O(n) 249ms, O(n) 55400 KB
* Status: Accepted
* Notes : First version is at the bottom.
*   Second version utilizes following properties,
*   - Note that first chunk always starts from index 0
*   - On the contrary, last chunk always ends with last index
*   
*   We make two lists of indices: one for prefix sum matches and other other one for suffix sum
*   matches.
*   
*   When we iterate through the prefix sum match indices list, assuming iteration index is i, we
*   find total count of how many suffix sum matches are available after index i+1. Hence, it gives
*   number of way split is possible keeping first part ending at index i,
*    [0...i] [i+1...j-1] [j...n-1]
*    
*   We ensure that j >= i + 2 to ensure a second chunk with size 1 or more.
*
*   I easily understood how I can find the indices for prefix sum matches and for suffix sum
*   matches. However, how I can get the count for total matches on the right side (suffix) for each
*   index i, wasn't clear to me. Briefly first chunk ends at i and we get total count for matches on
*   right side. We can easily get total count for splits on right side (using suffix matches) for
*   2nd and 3rd chunk. see, ack for this part.
*   
*   In the solution, Target Sum variable is S/3 to which we try to match sum of a chunk. Prefix sum
*   match indices List contains the indices where prefix sum matches with target sum. Similarly, for
*   suffix sum matches we have suffix sum match indices List. Two import count operations explained
*   below,
*   1. prefix sum match is as simple as the words say. Every time, a match is found at index i,
*   denoted by prefixSum[i], where,
*     prefixSum[i] = prefixSum[0] + prefixSum[1] ... + prefixSum[i]
*   becomes equal to target sum we get a count of 1.
*   2. number of count for suffix sum match is found by counting how many indices we have which are
*   greater than i+1. To find this in constant time, we subtract we passed number indices we passed
*   so far from list size.
* 
*   Implementation spec: limit of n is, <= 5 * 10^5.
*   Hence, decided to use List instead of two boolean arrays for prefix sum and suffix sum.
*   Instead of using two boolean arrays for indicating prefix sum match and suffix sum match we use
*   Lists to save space.
*   
*   Warning: too optimized, some part of the code might feel unreadable
* ref   : Editorial of the round, http://codeforces.com/blog/entry/13758, submission#45495771
*         ebanner's blog, https://codeforces.com/blog/entry/48079
* Ack   : Md Abdul Kader (Sreezin)
* meta  : tag-algo-dp, tag-two-pointers
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class LinearSplit {
  long[] A;
  long targetSum;   // S/3

  public void TakeInput() {
    int N = int.Parse(Console.ReadLine());
    string[] tokens = Console.ReadLine().Split();
    A = new long[N];

    for (int i = 0; i < N; i++)
      A[i] = int.Parse(tokens[i]);
  }

  /// <summary>
  /// return false if it is not possible to do 3 partitions. Calculate targetSum which is S/3.
  /// </summary>
  bool CanGetSplitSum() {
    long sum = 0;
    foreach (var num in A)
      sum += num;
    if (sum % 3 != 0)
      return false;
    targetSum = sum / 3;
    return true;
  }

  public long GetNumWays() {
    if (CanGetSplitSum() == false)
      return 0;
    long prefixSum = 0;
    long count = 0;
    var prefixSumMatchIndices = new List<int>();
    var suffixSumMatchIndices = new List<int>();

    // Find prefix sum match indices and suffix sum match indices
    for (int i = 0; i < A.Length; i++) {
      prefixSum += A[i];

      if (prefixSum == targetSum)
        prefixSumMatchIndices.Add(i);

      // 'else if' won't work here if both prefix and suffic sum are 0
      if (i < A.Length - 1 && prefixSum == 2 * targetSum)
        suffixSumMatchIndices.Add(i + 1);
    }

    // ToDo: make this two loops better, may be combine into single loop
    if (suffixSumMatchIndices.Count == 0)
      return 0;

    int sii = 0;    // index of item in suffix match list
    // use two pointers to find count: number of ways
    foreach (var pi in prefixSumMatchIndices) {  // pi = item in prefix match list
      for (; sii < suffixSumMatchIndices.Count && pi + 1 >= suffixSumMatchIndices[sii]; sii++) ;

      // early termination if there's no more suffix match
      if (sii == suffixSumMatchIndices.Count)
        break;
      // we ensured si is after pi so that middle block has at least size 1
      // we had following unused line,
      //  int si = suffixSumMatchIndices[sii];
      count += suffixSumMatchIndices.Count - sii;
    }

    return count;
  }

  /// <summary>
  /// first version (2017-09-12): this brute-force implementation was probably correct however
  /// inefficient does not take advantage of S/3 or the fact that first chunk starts from index 0
  /// and last chunk ends in last index
  /// </summary>
  public int GetNumWays_v1() {
    int n = A.Length;
    int count = 0;
    long sum1 = 0, orig_sum3 = 0;
    // pre-calculate original sum3
    for (int i = 0; i < n; i++)
      orig_sum3 += A[i];

    for (int i = 1; i < n - 1; i++) {
      sum1 += A[i - 1];
      long sum2 = 0;
      orig_sum3 -= A[i - 1];
      long sum3 = orig_sum3;
      for (int j = i + 1; j < n; j++) {
        sum2 += A[j - 1];
        sum3 -= A[j - 1];
        if (sum1 == sum2 && sum2 == sum3)
          count++;
      }
    }
    return count;
  }
}

public class CFSolution {
  private static void Main() {
    LinearSplit LS = new LinearSplit();
    LS.TakeInput();
    Console.WriteLine(LS.GetNumWays());
  }
}

/* Input,
5
1 2 3 0 3
10
2 5 -2 2 -3 -2 3 5 -5 -2

For large inputs like this,
100000
0 0 0 ... 0
result comes like 2431151270, out of integer range, hence use long
*/
