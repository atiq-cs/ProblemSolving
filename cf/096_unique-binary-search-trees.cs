/***************************************************************************************************
* Title : Unique Binary Search Trees
* URL   : https://leetcode.com/problems/unique-binary-search-trees
* Date  : Jan 2016
* Comp  : O(n^2) Time
* Author: Atiq Rahman
* Status: Accepted (56ms)
* Notes : Largest sum in contiguous subarray
*   fill in ...
* meta  : tag-algo-dp
***************************************************************************************************/
public class Solution
{
  public int NumTrees(int n) {
    int[] numWays = new int[n+1];
    // initialization; note on 0 nodes: above
    numWays[0] = 1;
    
    for (int target=1; target<=n; target++)
      for (int i=1; i<=target; i++)
        numWays[target] += numWays[i-1] * numWays[target-i];
    return numWays[n];
  }
}
