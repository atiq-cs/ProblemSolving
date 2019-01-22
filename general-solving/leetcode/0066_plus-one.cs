/***************************************************************************
* Title : Plus One
* URL   : https://leetcode.com/problems/plus-one
* Date  : 2018-02-08
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : grade school math - add
*   iterate in reverse order
*   add 1
*
*   terminate early if there's no carry
*   demonstrates Array.Copy
* meta  : tag-string, tag-leetcode-easy
***************************************************************************/
using System;

public class Solution {
  public int[] PlusOne(int[] digits) {
    int c = 1;

    for (int i = digits.Length-1; i >=0 && c>0; i--) {
      int r = digits[i] + c;
      if (r >= 10) {
        r -= 10;
        c = 1;
      }
      else
        c = 0;
      digits[i] = r;
    }
    if (c > 0)
      return InsertMSD(digits, c);
    return digits;
  }

  // insert most significant digit
  // @param num: number to insert in front
  // allocates memory required
  private int[] InsertMSD(int[] source, int num) {
    int[] digits = new int[source.Length+1];
    digits[0] = num;
    Array.Copy(source, 0, digits, 1, source.Length);
    return digits;
  }


  private int[] InsertMSD(int[] source, int num) {
    int[] digits = new int[source.Length+1];
    digits[0] = num;
    for (int i=0; i<source.Length; i++)
      digits[i+1] = source[i];
    return digits;
  }

  /// <summary>
  /// This is from meetup 2018-02-08 where I wrote this, tested?
  /// rel: http://collabedit.com/fk87m
  /// </summary>
  public List<int> AddOne(List<int> nums) {
    int c = 1;
    for (int i = nums.Count - 1; i >= 0 && c > 0; i--) {
      int r = nums[i] + c;
      if (r >= 10) {
        r -= 10;
        c = 1;
      }
      else
        c = 0;
      nums[i] = r;
    }
    if (c > 0)
      nums.Insert(0, c);
    return nums;
  }
}
