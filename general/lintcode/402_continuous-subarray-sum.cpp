/***************************************************************************************************
* Title : continuous-subarray-sum
* Date  : 2015-09-06
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes :
*   Basically Kadane's algorithm (check ref)
*   Modified to get min index
*   For a general demonstration please have a look at
*   - Algorithms/kadane_demo.cpp
*
* ref   : https://en.wikipedia.org/wiki/Maximum_subarray_problem
* meta  : tag-algo-dp, tag-kadane
***************************************************************************************************/
class Solution {
public:
  std::vector<int> kadane_with_index(std::vector<int> A) {
    // initialize max variables with first element
    int current_sum = A[0];
    int max_sum = current_sum;
    int min_index = 0;
    int final_min_index = 0;
    int max_index = 0;

    for (int i = 1; i < (int)A.size(); i++) {
      // continue with pevious sequence
      if (A[i] < current_sum + A[i]) {
        // if (current_sum > 0) {   // equivalent to previous condition
        current_sum += A[i];
      }
      else
      // we should restart the sequence from current index
      {
        // if I add previous sum it will not maximize sum
        current_sum = A[i];
        min_index = i;
      }

      if (max_sum < current_sum) {
        max_sum = current_sum;
        final_min_index = min_index;
        max_index = i;
      }
    }
    return { final_min_index, max_index };
  }

  vector<int> continuousSubarraySum(vector<int>& A) {
    // Write your code here
    return kadane_with_index(A);
  }
};
