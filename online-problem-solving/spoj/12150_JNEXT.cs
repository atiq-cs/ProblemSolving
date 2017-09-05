/***************************************************************************
* Title : Just Next !!!
* URL   : http://www.spoj.com/problems/JNEXT
* Date  : Oct 25, 2015
*
* Author: Atiq Rahman
* Status: Accepted
* Notes : same as general-solving/leetcode/031_next-permutation.cs
*         Was getting time limit exceeded
*         Replacing the foreach Console.Write of each num with
*         Console.WriteLine(string.Join("", nums)); reduced runtime and got accepted
*         Bad gmcs of spoj I guess
* Desc  : SPOJ Problem desc differences
*         - if there is no next permutation return -1
*         - no need to cycle back to starting perm i.e., 54321 to 12345
*         - inputs are probably simple
* meta  : tag-next-permutation
***************************************************************************/
using System;

public class Test {
  // Basically the same function from general-solving/leetcode/031_next-permutation.cs
  static int NextPermutation(int[] nums) {
    // iterate in reverse, find the index before which item is less
    int i = nums.Length - 1;
    while (i > 0 && nums[i - 1] >= nums[i])
      i--;
    // find the item that is immediately greater than nums[i-1] and swap
    if (i>0) {
      int j = nums.Length - 1;
      while (nums[i - 1] >= nums[j])  //>= so we choose the last one
        j--;  // so that after swapping small number comes at the later index
      int temp = nums[j]; nums[j] = nums[i - 1]; nums[i - 1] = temp;
    }   // afterwards, when we reverse the string order is maintained
    if (i == 0)   // only for this spoj problem
      return -1;
    for (int j=i, k=nums.Length-1; j<k;j++,k--)
      /* if (nums[j]>nums[k]) */ {  // swap condition not required
        int temp = nums[j]; nums[j] = nums[k]; nums[k] = temp;
      }
    return 0;
  }

  public static void Main() {
    int T = int.Parse(Console.ReadLine());
    while (T-->0) {
      int N = int.Parse(Console.ReadLine());
      int[] nums = new int[N];
      
      string[] tokens = Console.ReadLine().Split();
      for (int i=0; i<N; i++)
        nums[i] = int.Parse(tokens[i]);
        
      if (NextPermutation(nums) == 0)
        Console.WriteLine(string.Join("", nums));
      else
        Console.WriteLine("-1");
    }
  }
}
