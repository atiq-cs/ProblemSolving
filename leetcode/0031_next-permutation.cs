/***************************************************************************************************
* Title : Next Permutation
* URL   : https://leetcode.com/problems/next-permutation/
* Date  : 2015-10-24
* Comp  : O(n), O(1) modifying original array
* Author: Atiq Rahman
* Status: Accepted (beat 93%)
* Notes : have to test the approach with
*   Tested with spoj: online-problem-solving/spoj/12150_JNEXT.cs
*   Credits, https://github.com/animeshh
*   Further improvement: http://codeforces.com/blog/entry/3980
* rel   : UVA - 146
* ref   : 1. leetcode implements exactly same thing,
*   https://leetcode.com/problems/next-permutation/solution/
*   2. http://blog.csdn.net/m6830098/article/details/17291259
* meta  : tag-next-permutation, tag-permutation, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
  public void NextPermutation(int[] nums) {
    // iterate in reverse, find the index before which item is less
    int i = nums.Length - 1;
    while (i > 0 && nums[i - 1] >= nums[i])
      i--;
    // find the item that is immediately greater than nums[i-1] and swap
    if (i>0) {
      int j = nums.Length - 1;
      while (nums[i - 1] >= nums[j])  //>= so we choose the last one
        j--;  // so that after swapping small number comes at the later index
      Swap<int>(nums, j, i - 1);
    }   // afterwards, when we reverse the string order is maintained
    for (int j=i, k=nums.Length-1; j<k;j++,k--)
      Swap<int>(nums, j, k);
      //if (nums[j]>nums[k]) */  // swap condition not required
      /* {
        int temp = nums[j]; nums[j] = nums[k]; nums[k] = temp;
      } */
  }
}

/*
Mental sketch:
  5, 4, 3, 1, 2
  5 4 3 2 1
  5 4 3 1 2

  [5, 4, 1, 3, 2]
  [5, 4, 2, 3, 1]
  [5, 4, 2, 1, 3]


  [2,3,1,3,3]
  [2,3,3,1,3]

  [2,1,2,2,2,2,2,1]
  [2,2,2,2,2,2,1,1]

  [2,1,3,2,2,2,2,1]
  [2,3,1,2,2,2,2,1]

  [2,2,3,2,2,2,2,1]

  [2,2,3,3,3,3,3,2]
  [2,3,2,3,3,3,3,2]

  [2,2,1,1,2,2,2,2]

  [5, 4, 2, 3, 1, 0]
  [5, 4, 3, 2, 1, 0]

  [3,4,1,4,3,3]
  [3,4,3,4,3,1]
  [3,4,3,3,1,4]

 Special Inputs:
  [3,4,1,4,3,3]
  [5, 4, 3, 2, 1]
  [5, 4, 3, 1, 2]
  [4, 3, 5, 2, 1]
  [2,3,1,3,3]
  [2,1,2,2,2,2,2,1]
  
More draft from previous note,
5431876

5436871
5436178

54312
54321
54231
54132
54231
54213
54312
54213
54321

corner case:
 if we reached index 0 then we don't find next bigger, we don't swap with next bigger
reverse

1234567899
7654321

Found draft in a cpp solution
-----------------------------
abcdefgh

I try to find starting from last index from where it is not sorted in descending order
we reach to h
since there is nothing after h, we do the post swap operation
and then we swap h with g
result is abcdefhg

abcdefhg
we reach to f after which things are not sorted in descending order
swap g with h and then g with f

abcdegfh

reach to h
result is 
abcdeghf

now reach to g
abc
acb
bac



Analyzing the permutation problem
1, 2, 3 [swap index 1 with 1]
1, 3, 2 [swap index 2 with 3]
2, 1, 3 [swap index 1 with 2]
2, 3, 1
3, 1, 2
3, 2, 1

analyzing next permutation,
1, 2, 3, 4

iterate from reverse direction and find the first one that is smaller than next one
consider example, 4 3 2 1
 if length becomes 0, reverse the string
 example results
 1, 2, 3, 4
*/
