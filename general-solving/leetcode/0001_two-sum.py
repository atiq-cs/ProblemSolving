'''*************************************************************************************************
* Title : Two Sum
* URL   : https://leetcode.com/problems/two-sum/
* Date  : 2019-08
* Comp  : O(N), O(N)
* Status: Accepted
* Notes :
* ref   : https://leetcode.com/articles/two-sum/
* rel   : 0001_two-sum.cs
* meta  : tag-ds-hashtable, tag-company-microsoft, tag-leetcode-easy
*************************************************************************************************'''
class Solution:
  def twoSum(self, nums: List[int], target: int) -> List[int]:
    num_set: Dict[int, int] = {}

    for i in range(len(nums)):
      diff = target - nums[i]
      if diff in num_set:
          return [i, num_set[diff]]
      else:
          num_set[nums[i]] = i
    
    return None
