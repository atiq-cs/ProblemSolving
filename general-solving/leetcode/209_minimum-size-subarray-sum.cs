/***************************************************************************
*   Problem Name:   Minimum Size Subarray Sum 
*   Problem URL :   https://leetcode.com/problems/minimum-size-subarray-sum/
*                   related: http://www.geeksforgeeks.org/minimum-length-subarray-sum-greater-given-value/
*                   derived from: http://www.geeksforgeeks.org/find-subarray-with-given-sum/

*   Date        :   July 25, 2015
*   Algo, DS    :   Subarray sum
*   Desc        :   Sliding windw approach - use the fact that input numbers are positive
*
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted
***************************************************************************/

public class Solution
{
    public int MinSubArrayLen(int s, int[] nums)
    {
        return get_min_subarray_length(s, nums);

    }

    /*  kadane algorithm is not right approach to find min subarray length
        kadane is appropriate for maximizing sum not minimizing length based on a given sum
        
        This algorithm is suitable when given set of numbers are positive
    */
    private int get_min_subarray_length(int given_sum, int[] A)
    {
        // initialize variables
        int min_length = A.Length + 1;
        int current_sum = 0;
        int start_index = 0;
        for (int i = start_index; i < A.Length; i++)
        {
            bool should_update_min_length = false;
            current_sum += A[i];
            // only update minimum length if current sum exceeds given sum
            if (current_sum >= given_sum)
                should_update_min_length = true;

            /*
                Imagine test case like this:
                A[i] is equal or greather than sum of significant amount of numbers which are in
                the start of the window we are considering
                In that case, this part should be improved
                One of the ways to improve is to use a combination of binary search and prefix sum
            */
            while (current_sum >= given_sum)
            {
                current_sum -= A[start_index];
                start_index++;
            }
            if (should_update_min_length)
                min_length = Math.Min(min_length, i - start_index + 2);
        }
        // if sum has never reached given_sum min length should be 0
        if (min_length == A.Length + 1)
            min_length = 0;
        return min_length;
    }

    /* Naive Approach: O(n^2) solution
     * gets time limit exceeded on leetcode
     */
    private int get_min_length(int sum, int[] A)
    {
        int min_length = A.Length;
        // for each index
        for (int i = 0; i < A.Length; i++)
        {
            int current_sum = 0;
            for (int j = i; j < A.Length; j++)
            {
                current_sum += A[j];
                if (current_sum >= sum)
                {
                    min_length = Math.Min(min_length, (j - i + 1));
                    // early stop
                    if (min_length == 1)
                        return min_length;
                }
            }
        }
        return min_length;
    }
}
