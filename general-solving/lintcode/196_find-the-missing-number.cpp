/*
    Problem     :   http://www.lintcode.com/en/problem/find-the-missing-number/
    Description :   Problem's challenge is not satisfied, have to solve it using O(1) memory
                    related: https://leetcode.com/problems/first-missing-positive/,
                        however, this one requires a set instead of a vector as there will be negative inputs that
                        cannot mapped with negative indices

    Complexity  :   O(n) in both space and time
    Status      :   Accepted
*/


class Solution {
public:
    int findMissing(vector<int> &nums) {
        vector<bool> numset(nums.size()+1, false);
        if (nums.size() == 0)
            return 0;
        if (nums.size() == 1)
            return nums[0]+1;
        // write your code here
        for (auto item: nums)
            numset[item] = true;

        for (int i=0; i<numset.size(); i++)
            if (numset[i] == false)
                return i;
    }
};
