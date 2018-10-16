/*
*  Problem Title:  Find balance index of an array
*  Problem source:  Interview question 2
*                       can be related with this:http://www.glassdoor.com/Interview/Find-the-balance-point-in-an-a
    rray-The-index-where-the-sum-of-the-elements-to-the-left-it-is-the-same-as-the-sum-of-the-e-QTN_245781.htm
*  Problem Type:  Tree, Data Structure
*  Alogirthm  :
*  Author    :  Atiq Rahman
*  Email    :  atiqcs 'at' outlook 'dot' com
*  Date    :  June 03, 2015
*  Desc    :
*
*  Status    :  Yet to be tested against different type of input
*   meta        :   tag-interview, tag-prefix-sum
*/

#include <iostream>

int find_balance_index(vector<int> A) {
    int n = A.size();
    //     vector<int> perfix_sum = calculate_prefix_sum(A);
    int total_sum = get_total_sum(A);

    int current_sum = A[0];
    for (int i = 1; i<n - 1; i++) {
        current_sum += A[i];
        int sum_left = current_sum - A[i];
        int sum_right = total_sum - current_sum;
        if (sum_left == sum_right)
            return i;
    }
    return -1;
}
