/*
    Problem     : http://www.lintcode.com/en/problem/continuous-subarray-sum/
    Description :
                Basically Kadane's algorithm: https://en.wikipedia.org/wiki/Maximum_subarray_problem
                Modified little bit to get min index
				For a general demonstration please have a look at
				  - Algorithms/kadane_demo.cpp

    Complexity  : O(n)

    Status      :   Accepted
*/


class Solution {
public:
	/**
	* @param A an integer array
	* @return  A list of integers includes the index of
	*          the first number and the index of the last number
	*/
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
		return{ final_min_index, max_index };
	}

	vector<int> continuousSubarraySum(vector<int>& A) {
		// Write your code here
		return kadane_with_index(A);
	}
};
