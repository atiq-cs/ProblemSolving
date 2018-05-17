/***************************************************************************
* Title : Merge Sorted Array
* URL   : https://leetcode.com/problems/merge-sorted-array
* Date  : 2018-05-16
* Author: Atiq Rahman
* Comp  : O(m+n)
* Status: Accepted
* Notes : Because nums1 has enough space assign from the end and there is no
*   risk of over-writing.
* meta  : tag-binary-tree, tag-leetcode-easy, tag-two-pointer
***************************************************************************/
public class Solution {
  public void Merge(int[] nums1, int m, int[] nums2, int n) {
    // int i = m+n-1; replaced by i1+i2-1
    int i1 = m-1;
    int i2 = n-1;
    while (i1>=0 || i2>=0) {
      if (i1 == -1 || (i2>=0 && nums2[i2] >= nums1[i1])) {
        nums1[i1+i2+1] = nums2[i2--];
      }
      else if (i2 == -1 || (i1>=0 && nums2[i2] < nums1[i1]))
        nums1[i1+i2+1] = nums1[i1--];
    }
  }
}
/*
nums1 = [1,2,3,0,0,0], m = 3
nums2 = [2,5,6],       n = 3

i1 -> 3
i2 -> 6

put the bigger one in the end and continue..
*/
