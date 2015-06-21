/*
    Problem     : http://www.lintcode.com/en/problem/permutations/
    Description :
                Recursive solution. Problem asks to do without recursion
                Idea used from basic permutation Basics/Basic_Permutation.cpp
                This also solves the problem: Basics/next_permutation_demo.cpp

    Complexity  : O(n!) geeksforgeek is saying (n * n!), have to check

    Status      :   Accepted
*/


class Solution {
    vector<vector<int>> perm_array;
private:
    void permute(vector<int> &nums, int index) {
        if (index == nums.size() - 1) {
            perm_array.push_back(nums);
            return;
        }
        // if provided index from main call is wrong
        if (index >= nums.size())
            return;

        permute(nums, index + 1);
        for (int i = index + 1; i < nums.size(); i++) {
            std::swap(nums[index], nums[i]);
            permute(nums, index + 1);
            std::swap(nums[index], nums[i]);
        }
    }

public:
    /**
    * @param nums: A list of integers.
    * @return: A list of permutations.
    */
    vector<vector<int>> permute(vector<int> nums) {
        // write your code here
        perm_array.clear();
        if (nums.size() == 0) {
            return perm_array;
        }
        std::sort(nums.begin(), nums.end());
        permute(nums, 0);

        return perm_array;
    }
};
