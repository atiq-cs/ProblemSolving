/***************************************************************************
* Title : Subsets II
* URL   : https://leetcode.com/problems/subsets-ii
* Date  : 2018-08-15
* Author: Atiq Rahman
* Occasn: InnoWorld old, Charan
* Comp  : O(N * 2^n), O(N * 2^n)
* Status: Accepted
* Notes : Adapted from 78 - subsets 
*   Here we got,
*    k = ssindex[q]
*
*   Space comp analysis, Each combination can hold N items hence complexity i
*   Time comp, the way I was filling up adding one item to previous subset each
*   time.. I thought it's O(1) for each of them.. I totally missed that I am
*   copying entire old subset to new one before adding. That's where O(N) is
*   cost every time.
*
*   ToDo, implement recursive solution
* Ack   : Md Abdul Kader (Sreezin) for handling duplicates with i==k
* rel   : https://leetcode.com/problems/subsets/
* meta  : tag-csharp-lang-initializer-syntax, tag-leetcode-medium
***************************************************************************/
public class Solution {
  public IList<IList<int>> SubsetsWithDup(int[] nums) {
    Array.Sort(nums);
    var subLists = new List<IList<int>>(new List<int>[] { new List<int>() } );
    var ssindex = new List<int>( new int[] { 0 });

    for (int i=0; i<nums.Length; i++) {
      int len = subLists.Count; // coz list (& it's length) will be modified
      for (int q=0; q<len; q++)
        // first condition takes care of the bound for the second cond.
        if (ssindex[q] == i || nums[i-1] != nums[i]) {
          subLists.Add(new List<int>(subLists[q]));
          subLists[subLists.Count-1].Add(nums[i]);
          ssindex.Add(i+1);
        }
    }
    return subLists;
  }
}

/* Draft
[]
[2]
[2, 2]
[2, 2, 2]

only add to the one that has all the 2s we seen before..

{1, 2, 2}
[]
[1]
[2]
[1, 2]
[2, 2]
[2, 2, 2]

[]
[2]
[2, 2]
[2, 2, 2]

only add to the one that has all the 2s we seen before..

{1, 2, 2}
[]
[1]
[2]
[1, 2]
[2, 2]
[2, 2, 2]

Consider input:
[1,2,3,2,3]
*/
