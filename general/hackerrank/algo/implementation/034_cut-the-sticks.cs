/***************************************************************************************************
* Title : Cut the sticks
* URL   : https://www.hackerrank.com/challenges/cut-the-sticks/
* Date  : 2015-09-21
* Comp  : O(n^2)
* Author: Atiq Rahman
* Status: Accepted
* meta  : tag-implementation, tag-easy
***************************************************************************************************/
using System;
using System.Collections.Generic;

class HKSolution
{
  static void Main(String[] args) {
    int N = int.Parse(Console.ReadLine());
    string[] tokens = Console.ReadLine().Split();
    List<int> nums = new List<int>();
    int minItem = 0x7FFFFFFF;   // or we could use the first item as min and start look up from second

    // take inputs and add to List, also find minimum item
    for (int i = 0; i < N; i++) {
      int num = int.Parse(tokens[i]);
      nums.Add(num);
      minItem = Math.Min(minItem, num);
    }
    int preMinItem = minItem;
    minItem = 0x7FFFFFFF;

    while (nums.Count > 0) {
      Console.WriteLine(nums.Count);
      // every time find minimum and subtract/remove
      for (int j = 0; j < nums.Count;) {
        if (nums[j] <= preMinItem)  // don't increase index as item at this position is removed
          nums.RemoveAt(j);
        else {
          nums[j] -= preMinItem;
          minItem = Math.Min(minItem, nums[j]);
          j++;
        }
      }
      preMinItem = minItem;
      minItem = 0x7FFFFFFF;
    }
  }
}
