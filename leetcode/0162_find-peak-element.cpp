/***************************************************************************
* Title : Find Peak Element
* URL   : https://leetcode.com/problems/find-peak-element
* Date  : 2018-02-23
* Author: Atiq Rahman
* Comp  : Time O(lg n)
* Status: Accepted
* Notes : moved to '0162_find-peak-element.cs'
* meta  : tag-binary-search, tag-ds-array, tag-leetcode-medium
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
