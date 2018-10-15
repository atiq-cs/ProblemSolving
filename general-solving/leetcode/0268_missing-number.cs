/***************************************************************************************************
* Title : Missing Number
* URL   : https://leetcode.com/problems/missing-number/
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : The solution works because given inputs are in range 0 to N-1
* rel   : http://www.lintcode.com/en/problem/find-the-missing-number/
***************************************************************************************************/
public class Solution
{
  public int MissingNumber(int[] nums) {
    // initialize the list with false values
    List<bool> numset = new List<bool>(nums.Length + 1);
    for (int i = 0; i <= nums.Length; i++)
      numset.Add(false);

    foreach (var item in nums)
      numset[item] = true;

    // index i exactly matches with the number that is missing
    for (int i = 0; i < numset.Count; i++)
      if (numset[i] == false)
        return i;
    return 0;
  }
}
