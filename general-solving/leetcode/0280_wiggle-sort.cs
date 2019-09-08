/***************************************************************************************************
* Title : Wiggle Sort
* URL   : https://leetcode.com/problems/wiggle-sort
* Date  : 2019-03-19
* Comp  : O(N), O(1)
* Status: Accepted
* Notes : string matching
* rel   : algo/string/KMP-String-Matcher.cs
* meta  : tag-algo-sort, tag-leetcode-premium, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  // And, here's the shortest solution from leetcode discuss
  public void wiggleSort(int[] nums) {
    for (int i = 0; i < nums.length - 1; i++) {
      if ((i % 2 == 0) == (nums[i] > nums[i + 1])) {
        Swap<int>(nums, i, i + 1);
      }
    }
  }

  // my soln
  public void WiggleSort(int[] a) {
    int n = a.Length;

    if (n > 1 && a[0] > a[1])
      Swap<int>(a, 0, 1);

    for (int i = 2; i < n; i++) {
      // if i is even, then we know a[i-2] >= a[i-1]
      if (i % 2 == 0) {
        if (a[i - 1] < a[i])
          Swap<int>(a, i - 1, i);
      }
      // a[i-2] <= a[i-1]
      // if a[i-1] < a[i] derives a[i] is the greatest
      else {
        if (a[i - 1] > a[i]) // swap a[i-1], a[i]
          Swap<int>(a, i - 1, i);
      }
    }
  }
}
