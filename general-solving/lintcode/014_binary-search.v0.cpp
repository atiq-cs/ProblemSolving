/***************************************************************************************************
* URL   : http://www.lintcode.com/en/problem/binary-search/
* Comp  : theta(log n)
* Date  : 2015-06-04
* Status: Accepted
* Notes : Recursive solution
*
*   worst case, O(n) if all items are equal
*   can implement another binary search to handle that
***************************************************************************************************/

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
      int index = mid;
      // keep on comparing till we get a mismatch
      while (index--)
        if (array[mid] != array[index])
          break;
      return index + 1;

    }
    if (array[mid] > target)
      return binarySearch_rec(array, low, mid - 1, target);
    return binarySearch_rec(array, mid + 1, high, target);
  }
};
