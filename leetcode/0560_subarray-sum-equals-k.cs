/***************************************************************************************************
* Title : Subarray Sum Equals K
* URL   : https://leetcode.com/problems/subarray-sum-equals-k
* Date  : 2018-04-18
* Author: Atiq Rahman
* Comp  : O(N), O(N); O(N^2), O(1)
* Status: Accepted
* Notes : O(N) solution is intuitive.
*  Simple explanation, at each index if we can find how many subarrays end that sum to k. Using that
*   we can find how many ways we can make up the given sum. If we have frequencies of all prefix sums
*   then we can then by looking at, all sum-k we can tell how many ways we can make k.
*   Example,
*    say we have 1, 2, 2, 1, -1, 1, -1
*    
*    Hence, at index 3, 5 and 7 we can make 5.
*    Say we extend the given example upto some length >= 100, say k = 45 and at 100 our prefix sum
*    is 50. Then we look, 50-45 and see that there are 3 ways to make it 45 for the current prefix
*    sum.
*  
*  
*  Explanation by decoding
*   Saves all previous sums, hence a new sum-k will conform to exist. Also, use sum-k to compute
*   total number ways to make sum. By all previous sums, we mean previuos sum not previous sum-k.
*   
*   O(N^2) solution was the first one I did.
*   Why does O(N^2) Soln has space complexity of O(1). Because, we can replace it with a running sum
*   and total sum. We get SUM (i, n-1) by subtracting running sum from total sum.
*
*   https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.dictionary-2.item
*   if item doesn't exist a set operation creates a new element with the specified key.
*   
*   fb version is to return true or false
* ref   : leetcode.com/problems/subarray-sum-equals-k/discuss/102106/Java-Solution-PreSum-+-HashMap
*   enough trouble to understand though
* rel   : https://leetcode.com/problems/subarray-product-less-than-k
* ack   : Sreezin (Mak)
* meta  : tag-hash-table, tag-company-facebook, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
  // O(N): readable version
  public int SubarraySum_v2_readable(int[] nums, int k) {
    int sum = 0, result = 0;
    var numWays = new Dictionary<int, int> { { 0, 1 } };
    foreach (var num in nums) {
      sum += num;
      if (numWays.ContainsKey(sum - k))
        result += numWays[sum - k];
      if (numWays.ContainsKey(sum))
        numWays[sum]++;
      else
        numWays[sum] = 1;   // msdn: set operation creates a new element with the specified key
    }
    return result;
  }

  // O(N): shorter version
  public int SubarraySum_v2(int[] nums, int k) {
    int sum = 0, result = 0;
    var numWays = new Dictionary<int, int> { { 0, 1 } };
    foreach (var num in nums) {
      sum += num;
      result += numWays.ContainsKey(sum - k) ? numWays[sum - k] : 0;
      numWays[sum] = (numWays.ContainsKey(sum) ? numWays[sum] : 0) + 1;
    }
    return result;
  }

  // First version: O(n^2)
  public int SubarraySum_v1(int[] nums, int k) {
    int[] prefixSum = GetPrefixSum(nums);
    int count = 0;
    for (int j=0; j<nums.Length; j++)
      for (int i=0; i<=j; i++) {
        int sum = prefixSum[j] - (i==0?0:prefixSum[i-1]);
        if (sum == k)
          count++;
      }
    return count;
  }

  // auxillary to SubarraySum_v1
  int[] GetPrefixSum(int[] nums) {
    // prefixSum[i] contains sum from index 0 to index i
    int[] prefixSum = new int[nums.Length];
    prefixSum[0] = nums.Length ==0?0:nums[0];
    for (int i = 1; i < nums.Length; i++)
      prefixSum[i] += nums[i] + prefixSum[i - 1];
    return prefixSum;
  }
}

/*
Draft,
[3,6,4,7], 11
[now, I can't make sense of this test case]
anyway, a subArray represented by 0,1 containins {3}
0,4 contains all of em

simplest one would be

for (j=0; j<n; j++)
  for (i=0; i<=j; i++) {
    SubArray(i,j)
  }

GetSubArraySum(i,j) = PrefixSum[j] - PrefixSum[i]

Input:nums = [1,1,1], k = 2
Output: 2

dict
0 -> 1

i=0,
 sum = 1, sum - k = -1
 does not exist so,
 result = 0
dict
0 -> 1
1 -> 1

i=1,
 sum = 2, sum-k = 0
 does exist, adds the value
 result = 1

dict
0 -> 1
1 -> 1
2 -> 2

i=2,
 sum = 3, sum-k = 1
 does exist, adds the value
 result = 2

dict
0 -> 1
1 -> 1
2 -> 2

1, 2, 3, 4, 6 k=6

  0 -> 1

i=0,
 sum = 1, sum-k=-5
 does not
 result = 0

i=1,
 sum = 3, sum-k=-3
 does not exist so,
 result = 0
  0 -> 1
  3 -> 1

i=2,
 sum = 6, sum-k=0
 does exist so,
 result = 1
  0 -> 1
  3 -> 1
  6 -> 1

i=3,
 sum = 10, sum-k=4
 does not exist so,
 result = 1
  0 -> 1
  6 -> 1
  10 -> 1

i=4,
 sum = 16, sum-k=10
 does exist so,
 result = 2

At this point, check note at the top.

[0,0,0,0,0,0,0,0,0,0]
0 

[0,0,0]
0

0->1

i=0
 sum = 0, sum -k =0
 does exist,
 result = 1
 sum = 0, sum -k =0
 does exist,
 result = 1


Finally, figured out that I missed the parentheses around conditional operator statement
  dict[sum] = dict.ContainsKey(sum)?dict[sum]:0 + 1;

It looks innocent but it makes huge difference

Special input,
[0,0,0,0,0,0,0,0,0,0]
0 
Correct output flow (for each value of i),
sum: 0 cur: 0 result: 1
sum: 0 cur: 0 result: 3
sum: 0 cur: 0 result: 6
sum: 0 cur: 0 result: 10
sum: 0 cur: 0 result: 15
sum: 0 cur: 0 result: 21
sum: 0 cur: 0 result: 28
sum: 0 cur: 0 result: 36
sum: 0 cur: 0 result: 45
sum: 0 cur: 0 result: 55

helped to figure out the mentioned bug above.

more examples,
[0,0,0,0]
0

1, 3, 6, 10

[0,0,0]
0
1, 3, 6
*/
