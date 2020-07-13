/***************************************************************************************************
* Title : 3Sum
* URL   : https://leetcode.com/problems/3sum
* Date  : 2018-03
* Author: Atiq Rahman
* Comp  : O(N^2), O(1) modifying/sorting original array though
* Status: Accepted
* Notes : Given data is unsorted.
*   If we develop an algorithm that has a run-time complexity of O(N^2) or
*   larger asymptotic complexity in that case, we can sort the data which takes
*   O(n lg n)
*   Therefore, solution basically boils down to,
*   - Utilize sorted data structure
*   - Handle duplicates
*   
*   As we take advantage of sorted data we don't need additional space for the
*   hash table data structure. My initial idea was to use a hash table that
*   takes around O(N * N * lg N) using hash table on the unsorted data.
*   However, this sliding window approach for this problem is better than that.
*
* ref   : https://leetcode.com/problems/3sum/discuss/7380/Concise-O(N2)-Java-solution (an easy to
*  understand solution kinda similar thinking as mine for this problem)
* meta  : tag-line-sweep, tag-two-pointers, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
  public IList<IList<int>> ThreeSum(int[] nums) {
    IList<IList<int>> result = new List<IList<int>>();
    Array.Sort(nums);

    for (int i=0; i<nums.Length-2; i++) {
      /*
       * Takes care of cases where we get duplicate result for iteration
       * variable i when values are same. Example,
       * Input: [-1,0,1,2,-1,-4], sorted: [-4, -1, -1, 0, 1, 2]
       * Note the duplicate in output: [[-1,-1,2], [-1,0,1], [-1,0,1]]
       */
      if (i>0 && nums[i] == nums[i-1])
        continue;
      int lo = i+1;
      int hi = nums.Length - 1;
      int sum = 0 - nums[i];
      while (lo < hi) {
        if (nums[lo] + nums[hi] == sum) {
          result.Add(new int[] { nums[i], nums[lo++], nums[hi--] });
          while (lo < hi && nums[lo] == nums[lo-1])
            lo++;
          while (lo < hi && nums[hi] == nums[hi+1])
            hi--;
        }
        else if (nums[lo] + nums[hi] < sum)
            lo++;
        else
            hi--;
      }
    }
    return result;
  }
}

/* Draft
if I had two numbers and I had to find pairs which sum to 0..
Later consider there are duplicates.

Can we use 2sum to solve 3-sum?
two sum can tell how many ways we can make 0-A[i]

How to solve two sum when there are duplicates?
keeping a hashset does not give me unique solution any more..

Sort first
for every number in the list do,
sum = 0 - num;
then,
 low = i +1; high = n-1;


Naive O(n^2); iterate over indices
HashSet of HashSet; output values order 
solved later using two pointers approach following a leetcode solution idea
 
Some cases considered to handle while developing the solution,
[-2,0,1,1,2]
[0,0,0]
[-1,0,1,2,-1,-4] 
*/
