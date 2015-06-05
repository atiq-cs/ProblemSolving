/*
    Problem: http://www.lintcode.com/en/problem/binary-search/
    Description:
            Recursive solution.

            Complexity: theta(log n) always

    Status  :   Accepted
*/

class Solution {
public:
    /**
    * @param nums: The integer array.
    * @param target: Target number to find.
    * @return: The first position of target. Position starts from 0.
    */
    int binarySearch(vector<int> &array, int target) {
        // write your code here

        return binarySearch_rec(array, 0, array.size(), target);
    }

    int binarySearch_rec(vector<int> &array, int low, int high, int target) {
        if (low > high)
            return -1;

        int mid = (low + high) / 2;
        if (array[mid] == target) {
            if (mid == 0 || array[mid] != array[mid - 1])
                return mid;
            return binarySearch_rec(array, low, mid - 1, target);
        }
        if (array[mid] > target)
            return binarySearch_rec(array, low, mid - 1, target);
        return binarySearch_rec(array, mid + 1, high, target);
    }
};
