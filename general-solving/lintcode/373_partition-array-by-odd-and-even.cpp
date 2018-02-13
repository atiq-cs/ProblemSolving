/***************************************************************************
* Title : Partition Array by Odd and Even
* URL   : http://lintcode.com/en/problem/partition-array-by-odd-and-even/
* Date  : 2018-02-08
* Author: Atiq Rahman
* Comp  : O(N)
* Status: Accepted
* Notes : Problem: rearrange the array in such a way so that
*   all odd numbers appear first and
*   even numbers appear later
*
*   can be related to quick sort's partition and DNF
* meta  : tag-easy, tag-EPI, tag-partition
***************************************************************************/
class Solution {
public:
  /*
  * @param nums: an array of integers
  * EPI's algo
  */
  void partitionArray(vector<int> &nums) {
    for (int i = 0, j = nums.size() - 1; i<j; i++) {
      while (nums[j] % 2 == 0 && i<j)
        j--;
      if (nums[i] % 2 == 0) {
        std::swap(nums[i], nums[j]);
      }
    }
  }

  // previous version
  void partitionArray(vector<int> &nums) {
    //int j = nums.size() - 1;
    for (int i = 0, j = nums.size() - 1; i<j; i++) {
      if (nums[i] % 2 == 0) {
        while (nums[j] % 2 == 0 && i<j)
          j--;
        swap(nums[i], nums[j]);
      }
    }
  }
};
