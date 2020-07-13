/***************************************************************************************************
* Title : Count of Smaller Numbers After Self
* URL   : count-of-smaller-numbers-after-self
* Date  : 18-10-29
* Author: Atiq Rahman
* Comp  : O(n lg n)
* Status: Accepted
* Notes : Simplified problem: Given a list of numbers (no duplicates) find count of smaller numbers
*   on the right side of the number.
*   Iterate the array in reverse order. For each number, add 1 to the rank index (index as in sorted
*   version of original array) of the number.
*   
*   How to handle duplicate numbers?
*   Find the first one of the duplicate numbers in sorted order. Get the Sum for (rank of that number
*   - 1). Example,
*    5 7 5 4 5 2
*   Then, sorter order is,
*    2 4 5 5 5 7
*   To get how many numbers are smaller to the right of 5 (index 4 in unsorted input array). First 5
*   in sorter order has rank 2 (index in sorted array). We get the Sum for index 2-1=1.
*   See example at bottom. Solution will be inefficient for time when there are large number of
*   duplicate numbers because of linear search to find previous rank of the first one in duplicate
*   numbers.
*   Ideally, duplicate numbers should have same rank or a label in order. However, in this solution,
*   they don't have same rank -- rank here is the index in sorted order. Depending on stability of
*   sort, numbers can have out of order ranks i.e., for unstable sort.
*   It is not proved whether the sort we are doing (specifically on 'idx') stable or not. Finding
*   first duplicate would be necessary anyway to get count for previous number's rank.
*   
* ref   : C.L.R.S 3rd Ed., Ch 14, Section 14.3 Interval Trees would also work
* rel   : https://leetcode.com/problems/range-sum-query-mutable
* meta  : tag-algo-fenwick-tree, tag-ds-binary-indexed-tree, tag-leetcode-hard
***************************************************************************************************/
public class Solution
{
  // original input numbers array; not required for this problem
  // int[] nums;

  // auxillary methods

  // slightly changed not to use nums, and just add provided value instead of adding difference
  // ref, 'ds/FenwickTree.cs'
  public void Update(int i, int val) {
    if (i < 0)
      throw new ArgumentException();
    i++;
    while (i <= accumNums.Length) {
      accumNums[i - 1] += val;
      i += LSB(i);
    }
  }

  // ref, 'ds/FenwickTree.cs'
  // int Sum(int i)


  public IList<int> CountSmaller(int[] nums) {
    IList<int> counts = new int[nums.Length];

    // sorted index -> index
    var idx = new int[nums.Length];
    for (int i = 0; i < idx.Length; i++)
      idx[i] = i;
    Array.Sort(idx, (x, y) => {
      return nums[x] - nums[y];
    });

    // index -> sorted index; rank as in quick-select or in,
    //  Ch. 14 (Augmenting Data Structures)
    var ranks = new int[nums.Length];
    for (int i = 0; i < nums.Length; i++)
      ranks[idx[i]] = i;

    this.accumNums = new int[nums.Length];
    for (int i = nums.Length - 1; i >= 0; i--) {
      Update(ranks[i], 1);
      if (ranks[i] == 0)
        counts[i] = 0;
      else {
        int ii = ranks[i] - 1;
        while (ii >= 0 && nums[idx[ii]] == nums[idx[ii + 1]])
          ii--;

        if (ii == -1)
          counts[i] = 0;
        else
          counts[i] = Sum(ranks[idx[ii + 1]] - 1);
      }
    }
    return counts;
  }
}

/*
Input:
[9,20,2,12,2,9,6,12,5,17,14,6,12,5,12,3,0]

Sorted - nums[idx[i]]:
 0 2 2 3 5 5 6 6 9 9 12 12 12 12 14 17 20

Sorted index -> current index: idx
 16 2 4 15 13 8 6 11 5 0 7 3 12 14 10 9 1

Current index -> sorted index: ranks:
 9 16 1 11 2 8 6 10 5 15 14 7 12 4 13 3 0

*/
