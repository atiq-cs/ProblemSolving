/***************************************************************************************************
* Title : Jewels and Stones
* URL   : https://leetcode.com/problems/jewels-and-stones
* Date  : 2018-05-25
* Author: Atiq Rahman
* Comp  : O(N+M), O(1)
* Status: Accepted
* Notes : 
* meta  : tag-hashtable, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  public int NumJewelsInStones(string J, string S) {
    // [int][char] 'z'-[char]'A' = 57, starting with index 0 ('A') we need 58
    bool[] isJewel = new bool[58];
    int count = 0;
    foreach (char ch in J)
      isJewel[ch - 'A'] = true;
    foreach (char ch in S)
      if (isJewel[ch - 'A'])
        count++;
    return count;
  }
}
