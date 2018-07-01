/***************************************************************************
* Title : Find Peak Element
* URL   : https://leetcode.com/problems/find-peak-element
* Date  : 2018-02-23
* Author: Atiq Rahman
* Comp  : Time O(lg n)
* Status: Accepted
* Notes : Alternative name "local maxima"
*   Finding a local minima is rather easy. Why Binary Search?
*   In worst case, local minima can be located at the end of the array.
*   It is possible that a search starts from the beginning of the array and the
*   cost to find that local minima will be O(N).
* 
*   Thereofre, a binary search which starts from the middle element and goes to
*   the left side if item on the left is larger is intuitive. Similarly if the
*   item on the right side is larger then it takes the search direction towards
*   the right side.
*   Detailed explanation: https://stackoverflow.com/q/12238241
*   https://www.geeksforgeeks.org/find-local-minima-array/
* meta  : tag-binary-search
***************************************************************************/
class Solution {
public:
  int findPeakElement(vector<int>& nums) {
    return findPeakElementRec(nums, 0, nums.size()-1);
  }
  
  int findPeakElementRec(vector<int>& num, int low, int high) {
    if(low == high)
      return low;
    else {
      int mid1 = (low+high)/2;
      int mid2 = mid1+1;
      if(num[mid1] > num[mid2])
        return findPeakElementRec(num, low, mid1);
      else
        return findPeakElementRec(num, mid2, high);
    }    
  }
};
