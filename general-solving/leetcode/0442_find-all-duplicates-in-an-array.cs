/***************************************************************************************************
* Title : Find All Duplicates in an Array
* URL   : https://leetcode.com/problems/find-all-duplicates-in-an-array/
* Date  : 2019-02-02
* Occasn: leetcode meetup remote 229 Polaris Ave, Mtn View
* Comp  : O(n), O(1)
* Status: Accepted
* Notes : Utilize the fact that, 1 <= a[i] <= n (n = size of array)
*   As we are turning numbers negative, later during iteration, just the number being negative
*   does not mean it's duplicate. To find duplicate check its respective index (1 off).
*
* meta  : tag-algo-dp, tag-leetcode-medium
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class Solution {
  public IList<int> FindDuplicates(int[] nums) {
    IList<int> dupList = new List<int>();

    foreach (var num in nums) {
      // as index is a new var it's alright to have different sign than num
      // however, it would be a problem if we were changing sign for nums[i] (= num)
      int index = Math.Abs(num)-1;

      if (nums[index] < 0)
        dupList.Add(index+1);
      else
        nums[index] *= -1;
    }

    return dupList;
  }
}

/* prev version,

  for (int i = 0; i < nums.Length; i++) {
    int num = nums[i] * ( nums[i] < 0 ? -1 : 1 );
    // just the number being negative does not mean it's duplicate
    if (num < 0)
      num = -num;
    if (nums[num - 1] < 0)
      dupList.Add(num);
    else
      nums[num - 1] = -nums[num - 1];
  } 
*/
