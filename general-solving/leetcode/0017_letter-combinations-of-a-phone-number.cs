/***************************************************************************************************
* Title : Sort Colors
* URL   : https://leetcode.com/problems/sort-colors
* Occasn: medium top
* Date  : 2018-12-20
* Comp  : O(N)
* Status: Accepted
* Notes : Example is better than precept!
*   Input: [2,0,2,1,1,0]
*   Output: [0,0,1,1,2,2]
*   
*   Simplest approach feels like moving the Zeros to the beginning and moving Twos to the end.
*   However, there are cases such as,
*   - after finding 0 and swapping it with a 2, now 2 has to be taken care of
*   - similar case with 2 and swapping it with 0
*   To handle this, we decrement i in line 47
*   
*   start and end indices indicate where bunch of 0 ends and where bunch of 2 starts.
*   Index out of bound is handled at line 29 and line 31.
*   
*   There is a special case when i is at index 'end' which is the index right after which Twos
*   start. It's weird that nums[end] equals to 2 in some case or in last iteration of i.
*   ToDo: investiage what's going on..
*
* meta  : tag-algo-sort, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  public void SortColors(int[] nums) {
    for (int start = 0, i = start, end = nums.Length - 1; ; i++) {
      while (start < end && nums[start] == 0)
        start++;
      while (end > 0 && nums[end] == 2)
        end--;

      if (i < start)
        i = start;

      if ((i == end && nums[i] == 2) || i > end)
        break;

      if (nums[i] == 0)
        // Swap is at 'general-solving\leetcode\utils.cs'
        Swap(ref nums[i], ref nums[start++]);

      else if (nums[i] == 2)
        Swap(ref nums[i], ref nums[end--]);

      if (nums[i] == 0 || nums[i] == 2)
        i--;
    }
  }
}

/*
Draft,
Special input
[1,0,1,1,1,1,0,2,2,1,0,0,0,1,2,2,1,2,1,0,0,2,2,2,0,1,2,0,1,2,2,2,2,0,2,2,2,2,1,2,1,0,0,2,1,0,1,0,0,0,1,1,0,1,1]

Analysis
i < end-1
start 17 end 40
2 swapping 34 with 40 num 1
start 17 end 38
2 swapping 35 with 38 num 1
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2]

i<end (does 1 extra swap and ruins the output)
start 17 end 35
2 swapping 36 with 35 num 1
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2

More inputs,
[2,0,1]
[0, 2, 1]
[1, 2, 0]
[0, 2, 1]
[0, 2, 1, 1]
[0, 1, 1, 1, 0, 0, 0, 2, 2]
[0,2]
[2]
[2,0,2,1,1,0]
*/
