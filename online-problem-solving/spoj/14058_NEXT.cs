/***************************************************************************
* Title : NEXT - The Next Permutation
* URL   : http://www.spoj.com/PUJ2013/problems/NEXT/
* Date  : 02-15-2018
* Author: Atiq Rahman
* Status: C# not supported
* Notes : version tried with judge 'coding-template/cpp/spoj.cpp'
*   slightly efficient version working with string/chars
*   replaced Swap with an utility function
*   pretty much same to 'uva-online-judge/146_ID_Codes_v03.cpp'
* meta  : tag-next-permutation, tag-judge-SPOJ
***************************************************************************/
using System;

public class SPOJSolution {
  // Basically the same function from general-solving/leetcode/0031_next-permutation.cs
  private static bool NextPermutation(char[] nums) {
    // iterate in reverse, find the index before which item is less
    int i = nums.Length - 1;
    while (i > 0 && nums[i - 1] >= nums[i])
      i--;
    // find the item that is immediately greater than nums[i-1] and swap
    if (i>0) {
      int j = nums.Length - 1;
      while (nums[i - 1] >= nums[j])  //>= so we choose the last one
        j--;  // so that after swapping small number comes at the later index
      Swap(nums, i - 1, j);
    }   // afterwards, when we reverse the string order is maintained
    if (i == 0)   // only for this spoj problem
      return false;
    for (int j=i, k=nums.Length-1; j<k;j++,k--)
      /* if (nums[j]>nums[k]) */  // swap condition not required
      Swap(nums, j, k);
    return true;
  }

  // Util swap instead..
  private static void Swap(char[] nums, int i, int j) {
    char temp = nums[i];
    nums[i] = nums[j];
    nums[j] = temp;
  }

  public static void Main() {
    int T = int.Parse(Console.ReadLine());
    while (T-->0) {
      string[] tokens = Console.ReadLine().Split();
      char[] str = tokens[1].ToCharArray();
        
      if (NextPermutation(str))
        Console.WriteLine(tokens[0] + " " + new string(str));
      else
        Console.WriteLine(tokens[0] + " BIGGEST");
    }
  }
}
