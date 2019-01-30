/***************************************************************************************************
* Title : Unique Binary Search Trees
* URL   : https://leetcode.com/problems/unique-binary-search-trees
* Date  : 2016-01
* Comp  : O(n^2), O(n)
* Status: Accepted
* Notes : Saw at Innoworld 2019-01-27
*    f(n) = Sum (for i=0...n-1, f(i) * f(n-i-1) )
*   where our base case is,
*    f(0) = 1
*
*   Also called, Calatan numbers, computing them efficiently would be considered extra-credit
*   during the interview.
*   
*   Can be solved using recursion as well
* meta  : tag-algo-dp, tag-recursion, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
  public int NumTrees(int numNodes) {
    int[] numWays = new int[numNodes+1];
    // initialization; note on 0 nodes: above
    numWays[0] = 1;
    
    for (int n=1; n<=numNodes; n++)
      for (int i=0; i<n; i++)
        numWays[n] += numWays[i] * numWays[n-i-1];
    return numWays[numNodes];
  }
}
