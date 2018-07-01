/***************************************************************************
*   Problem Name:   First Missing Positive
*   Problem URL :   https://leetcode.com/problems/first-missing-positive/ 
*   Date        :   August 7, 2015
*   Desc        :   For this problem, positive number starts from 1
*                   - there can be negative numbers
*                   - if all positive numbers are there for example [1, 2]
*                     then consider that we have to return 3
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted (0.172s)
*   Note        :   Problem challenge is not satisfied yet, do it in O(1) memory
*   Tech Note   :   why hashset instead of Dictionary?
*                   In this problem, just for Demo.
                    A  HashSet<T> is a class designed to give you O(1) lookup for containment (i.e.,
                        does this collection contain a particular object, and tell me the answer fast).

                    A List<T> is a class designed to give you a collection with O(1) random access than can grow
*   meta        : tag-hashtable
***************************************************************************/

public class Solution {
    public int FirstMissingPositive(int[] nums) {
        HashSet<int> numset = new HashSet<int>();
        
        for (int i=0; i<nums.Length; i++)
            numset.Add(nums[i]);
            
        for (int i=1; i<=numset.Count+1; i++)
            if (numset.Contains(i) == false)
                return i;
        // to make the compiler satisfied, should never reach here
        return 1;
    }
}
