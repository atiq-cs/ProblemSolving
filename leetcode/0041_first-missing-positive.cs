/***************************************************************************************************
* Title : First Missing Positive
* URL   : https://leetcode.com/problems/first-missing-positive/
* Date  : 2015-08-07
* Notes : For this problem, positive number starts from 1
*   - there can be negative numbers
*   - if all positive numbers are there for example [1, 2]
*   then consider that we have to return 3
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted (0.172s)
* Notes : Problem challenge is not satisfied yet, do it in O(1) memory
*   why hashset instead of Dictionary?
*   In this problem, just for Demo.
*   A HashSet<T> is a class designed to give you O(1) lookup for containment (i.e., does this
*   collection contain a particular object, and tell me the answer fast).
*
*   A List<T> is a class designed to give you a collection with O(1) random access than can grow
* meta  : tag-ds-hashtable, tag-leetcode-hard
***************************************************************************************************/
public class Solution {
  public int FirstMissingPositive(int[] nums) {
    var numset = new HashSet<int>(nums);

    for (int i=1; i<=numset.Count+1; i++)
      if (numset.Contains(i) == false)
        return i;
    // to make the compiler satisfied, should never reach here
    return 1;
  }
}

/*
Readability,

  HashSet<int> numset = new HashSet<int>();
    
  for (int i=0; i<nums.Length; i++)
    numset.Add(nums[i]);

*/
