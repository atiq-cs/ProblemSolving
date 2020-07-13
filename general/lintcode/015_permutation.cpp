/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/permutations/
* Date  : 2015-06-22
* Author: Atiq Rahman
* Comp  : O(n!) geeksforgeek is saying (n * n!), have to check
* Notes : Recursive solution. Problem asks to do without recursion
*   Idea used from basic permutation Basics/Basic_Permutation.cpp
*   This also solves the problem: Basics/next_permutation_demo.cpp
*
*   C++ next permutation solution appended at the end of this file as well
* Status: Accepted
* meta  : tag-permutation, tag-recursion
***************************************************************************************************/
class Solution {
private:
  vector<vector<int>> perm_array;

  void permute(vector<int> &nums, int index) {
    // handle wrong index
    if (index >= nums.size())
      return;
    if (index == nums.size() - 1) {
      perm_array.push_back(nums);
      return;
    }

    permute(nums, index + 1);
    for (int i = index + 1; i < nums.size(); i++) {
      std::swap(nums[index], nums[i]);
      permute(nums, index + 1);
      std::swap(nums[index], nums[i]);
    }
  }

public:
  vector<vector<int>> permute(vector<int> nums) {
    perm_array.clear();
    if (nums.size() == 0) {
      return perm_array;
    }
    std::sort(nums.begin(), nums.end());
    permute(nums, 0);

    return perm_array;
  }
};

// Alternative: C++ next_permutation
class Solution {
public:
  vector<vector<int> > permute(vector<int> nums) {
    vector<vector<int>> perm_array;
    perm_array.clear();
    if (nums.size() == 0) {
      return perm_array;
    }
    std::sort(nums.begin(), nums.end());
    do {
      perm_array.push_back(nums);
    } while (std::next_permutation(nums.begin(), nums.end()));

    return perm_array;
  }
};
