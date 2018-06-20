/*
	wiki: https://en.wikipedia.org/wiki/Maximum_subarray_problem
	geeksforgeeks: http://www.geeksforgeeks.org/largest-sum-contiguous-subarray/
*/

#include <iostream>
#include <algorithm>
#include <vector>

/*
	Kadane's algorithm: https://en.wikipedia.org/wiki/Maximum_subarray_problem as it is
	returns max sum

*/
int kadane(std::vector<int> A) {
	// initialize max variables with first element
	int current_sum = A[0];
	int max_sum = current_sum;

	for (int i = 1; i < (int) A.size(); i++) {
		current_sum = std::max(A[i], current_sum + A[i]);
		max_sum = std::max(max_sum, current_sum);
	}
	return max_sum;
}

/*
	What if we need starting and ending index we used to compute the max sum
	- general-solving/lintcode/402_continuous-subarray-sum.cpp
	   used in solving the lintcode problem
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

int main() {
	// Testcase 1: {-7, 3, 4, -10, 5, 6}
	int sum = kadane({ { -7, 1, 2, -10, 2, 3 } });
	std::cout << "Max sum: " << sum << std::endl;
	std::vector<int> result = kadane_with_index({ 1, -7, -1, -2 });
	std::cout << "Maximum subarray interval: [" << result[0] << ", " << result[1] << "]" << std::endl;

	return 0;
}
