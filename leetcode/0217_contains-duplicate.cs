/***************************************************************************************************
* Title : Contains Duplicate
* URL   : https://leetcode.com/problems/contains-duplicate/
* Date  : 2015-07-25
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Hashtable vs Dictionary vs HashSet in C#
*   https://vikrantravi.wordpress.com/2012/07/24/hashtable-vs-dictionary-vs-hashset-in-c/
*   Demonstrates use of hashset which has O(1) lookup time
*   HashSet<T> Class ref: https://msdn.microsoft.com/en-us/library/bb359438.aspx
* meta  : tag-ds-hashset, tag-ds-binary-tree, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public bool ContainsDuplicate(int[] nums) {
    HashSet<int> numset = new HashSet<int>();
    foreach (int num in nums) {
      if (numset.Contains(num))
        return true;
      numset.Add(num);
    }
    return false;
  }
}
