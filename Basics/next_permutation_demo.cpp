/*
*	Problem Title:	 Using C++ next_permutation
*	Author		:	Atiqur Rahman
*	Email		:	mdarahman@cs.stonybrook.edu
*	Date		:	June 20, 2015
*	Desc		:
*					This solves http://www.lintcode.com/en/problem/permutations/ as well
*/

class Solution {
public:
    /**
    * @param nums: A list of integers.
    * @return: A list of permutations.
    */
    vector<vector<int> > permute(vector<int> nums) {
        // write your code here
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
