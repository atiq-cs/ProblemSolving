/***************************************************************************************************
* Title : Binary Subarrays With Sum
* URL   : https://leetcode.com/problems/combinations/
* Date  : 2019-01-20
* Comp  : O(N), O(N)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Find non-empty subarrays that sum to given target.
*   If we consider there are no multiple zeros together. This is pretty easy problem. Only second
*   loop suffices.
*   While deveoping loop started with as simple as,
*    numWays += kvp.Value * freq[kvp.Key - targetSum]
*
*   Then I have added conditions to handle some cses.
* meta  : tag-algo-dp, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  public int NumSubarraysWithSum(int[] A, int targetSum) {
    int prefixSum = 0;
    var freq = new Dictionary<int, int>();

    for (int i = 0; i < A.Length; i++) {
      prefixSum += A[i];
      if (freq.ContainsKey(prefixSum))
        freq[prefixSum]++;
      else
        freq.Add(prefixSum, 1);
    }

    int numWays = 0;
    // goddman it! patch for zeros here....
    if (targetSum == 0)
      foreach (var kvp in freq)
        numWays += kvp.Value * (kvp.Key == 0 ? (kvp.Value + 1) : (kvp.Value - 1)) / 2;
    else
      foreach (var kvp in freq)
        numWays += kvp.Value * (freq.ContainsKey(kvp.Key - targetSum) ? kvp.Key - targetSum == 0 ?
          freq[kvp.Key - targetSum] + 1 : freq[kvp.Key - targetSum] : kvp.Key - targetSum >= 0 ?
          1 : 0);

    return numWays;
  }
}

/*
Example inputs,
[0, 0, 0, 0, 1]
0
[0, 0, 0, 0, 1]
1
[1, 0, 0, 0, 0]
1

[1,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0]
0

[1,0,0,1,0,0,1,0,0]

[1,0,0,1,0,0,1,0,0]
0

some debug code,

  numWays += val;
  Console.WriteLine("Adding " + val);
*/
