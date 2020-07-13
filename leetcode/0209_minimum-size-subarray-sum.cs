/***************************************************************************
* Title : Minimum Size Subarray Sum
* URL   : https://leetcode.com/problems/minimum-size-subarray-sum/
* Date  : 2015-07-25
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : Sliding window approach - utilize given that input numbers are
*   positive. kadane algorithm is not right approach to find min subarray
*   length. kadane works great for maximizing sum not minimizing length based
*   on a given sum.
*   
*   This algorithm is suitable when given set of numbers are positive.
*   Example illustrated at the bottom of this source file.
*   i is end of current Window.
*   startIndex is start of current Window.
*   
*   Follow up, would it work if asked to find this for equal to target sum?
*
*   Calling it sliding windows approach; not clear about the pattern 'sweeping'
*   algorithm (C.L.R.S 3rd ed, p#1021) follows yet.
* rel   : geeksforgeeks.org/minimum-length-subarray-sum-greater-given-value
* ref   : http://www.geeksforgeeks.org/find-subarray-with-given-sum
* meta  : tag-sliding-window, tag-leetcode-medium
***************************************************************************/
public class Solution {
  public int MinSubArrayLen(int givenSum, int[] nums)
  {
    // initialize variables
    int minLength = nums.Length + 1;
    int sum = 0;
    int startIndex = 0;
    for (int i = startIndex; i < nums.Length; i++) {
      bool shouldUpdateMinLength = false;
      sum += nums[i];
      // only update minimum length if current sum exceeds given sum
      if (sum >= givenSum)
        shouldUpdateMinLength = true;
      /*
      Imagine test case like this:
      A[i] is equal or greather than sum of significant amount of numbers which
      are in start of currently considered window.
      In that case, this part should be improved
      One of the ways to improve is to use a combination of binary search and
      prefix sum
      */
      while (sum >= givenSum) {
        sum -= nums[startIndex];
        startIndex++;
      }
      // We do it here because in previous code block we minimize the length by
      // incresaing starting index
      if (shouldUpdateMinLength)
        minLength = Math.Min(minLength, i - startIndex + 2);
      // +1 because the previous block decrements startIndex once more
      // +1 because of 0 based index. That is why total we do is +2
    }
    // if sum has never reached given_sum min length should be 0
    if (minLength == nums.Length + 1)
      minLength = 0;
    return minLength;
  }

  // Naive Approach: O(n^2) solution: Time limit exceeded on leetcode
  private int MinSubArrayLen_v1(int sum, int[] A)
  {
    int min_length = A.Length;
    for (int i = 0; i < A.Length; i++) {
      int current_sum = 0;
      for (int j = i; j < A.Length; j++) {
        current_sum += A[j];
        if (current_sum >= sum) {
          min_length = Math.Min(min_length, (j - i + 1));
          // early termination
          if (min_length == 1)
            return min_length;
        }
      }
    }
    return min_length;
  }
}

/* Example iteration for second version - O(N)
{2,3,1,2,4,3}

i=0,
 flag = false    // shouldUpdateMinLength
 sum = 2
i=1,
 flag = false; sum = 2 + 3 = 5
i=2,
 flag = false; sum = 5 + 1 = 6
i=3,
 flag = true; sum = 6 + 2 = 8
 8 >= 7? Yes. Keep removing items from starting of the window
 1 item {2} is removed,
  startIndex becomes 1
  sum becomes 6
  min = 3 - 1 + 2 = 4
i=4,
 flag = true; sum = 6 + 4 = 10
 10 >= 7? Yes. Keep removing items from starting of the window
 2 items {3, 1} are removed,
  startIndex becomes 3
  sum becomes 6
  min = 4 - 3 + 2 = 3
i=5,
 flag = true; sum = 6 + 3 = 9
 9 >= 7? Yes. Keep removing items from starting of the window
 2 items {2, 4} are removed,
  startIndex becomes 5
  sum becomes 3
  min = 5 - 5 + 2 = 2

As we can see last two elements, {4, 3} makes the minimum length subarray for
this solution.
*/
