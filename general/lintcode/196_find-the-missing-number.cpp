/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/find-the-missing-number/
* Date  : 2015-09-06
* Author: Atiq Rahman
* Comp  : O(n), O(n)
* Status: Accepted
* Notes : ToDo: Problem req is not satisfied, have to solve it using O(1) memory
*   however, this one requires a set instead of a vector as there will be negative inputs that
*   cannot mapped with negative indices. Review..
* rel   : https://leetcode.com/problems/first-missing-positive/,
* meta  : tag-hash-table
***************************************************************************************************/
class Solution {
public:
  int findMissing(vector<int> &nums) {
    vector<bool> numset(nums.size()+1, false);
    if (nums.size() == 0)
      return 0;
    if (nums.size() == 1)
      return nums[0]+1;

    for (auto item: nums)
      numset[item] = true;

    for (int i=0; i<numset.size(); i++)
      if (numset[i] == false)
        return i;
  }
};
