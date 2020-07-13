/***************************************************************************************************
* Title : http://www.lintcode.com/en/problem/binary-search/
* Date  : 2015-06-04
* Author: Atiq Rahman
* Comp  : theta(lg n)
* Status: Accepted
* Notes : Solved to verify the binary search algo
* meta  : tag-recursion, tag-algo-binary-search
***************************************************************************************************/
class Solution {
public:
  int binarySearch(vector<int> &array, int target) {
    return binarySearch(array, 0, array.size(), target);
  }

  int binarySearch(vector<int> &array, int low, int high, int target) {
    if (low > high)
      return -1;

    int mid = (low + high) / 2;
    if (array[mid] == target) {
      if (mid == 0 || array[mid] != array[mid - 1])
        return mid;
      return binarySearch(array, low, mid - 1, target);
    }
    if (array[mid] > target)
      return binarySearch(array, low, mid - 1, target);
    return binarySearch(array, mid + 1, high, target);
  }
};
