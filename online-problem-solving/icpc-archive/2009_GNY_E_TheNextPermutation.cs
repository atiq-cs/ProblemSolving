/***************************************************************************
* Title       : The Next Permutation
* URL         : http://acmgnyr.org/year2009/e.pdf
* Occasion    : ACM Regional 2009 GNY, Hofstra University, Hempstead, NY
* Date        : Sep 13 2017
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Output File matches
* Notes       : 
*               based on 'online-problem-solving/spoj/12150_JNEXT.cs'
*               Adapted from int[] to char[]
*               
*               http://www.spoj.com/PUJ2013/problems/NEXT/ (can't submit coz of
*               language restriction)
*               https://icpcarchive.ecs.baylor.edu/index.php?option=onlinejudge
*               &Itemid=99999999&category=367&page=show_problem&problem=2557
* meta        : tag-permutation
***************************************************************************/
using System;

public class ACMICPC_Solution {
   static int NextPermutation(char[] nums) {
    // iterate in reverse, find the index before which item is less
    int i = nums.Length - 1;
    while (i > 0 && nums[i - 1] >= nums[i])
      i--;
    // find the item that is immediately greater than nums[i-1] and swap
    if (i>0) {
      int j = nums.Length - 1;
      while (nums[i - 1] >= nums[j])  //>= so we choose the last one
        j--;  // so that after swapping small number comes at the later index
      char temp = nums[j]; nums[j] = nums[i - 1]; nums[i - 1] = temp;
    }   // afterwards, when we reverse the string order is maintained
    if (i == 0)   // only for this spoj problem
      return -1;
    for (int j=i, k=nums.Length-1; j<k;j++,k--)
      /* if (nums[j]>nums[k]) */ {  // swap condition not required
        char temp = nums[j]; nums[j] = nums[k]; nums[k] = temp;
      }
    return 0;
  }

  public static void Main() {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      int seq = int.Parse(tokens[0]);
      char[] str = tokens[1].ToCharArray();
      if (NextPermutation(str) == -1)
        Console.WriteLine(seq + " BIGGEST");
      else
        Console.WriteLine(seq + " " + new string(str));
    }
  }
}
