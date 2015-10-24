/***************************************************************************
* Title     : Contains Duplicate
* URL       : https://leetcode.com/problems/contains-duplicate/
* Date      : July 25, 2015
* Algo, DS  : Set
* Desc      : Demonstrates use of hashset which has O(1) lookup time
*                 HashSet<T> Class ref: https://msdn.microsoft.com/en-us/library/bb359438(v=vs.110).aspx
*
* Complexity: O(n)
* Author    : Atiq Rahman
* Status    : Accepted
* Notes     : Hashtable vs Dictionary vs HashSet in C#
*                 https://vikrantravi.wordpress.com/2012/07/24/hashtable-vs-dictionary-vs-hashset-in-c/
* meta      : tag-hashset
***************************************************************************/

public class Solution
{
    public bool ContainsDuplicate(int[] nums)
    {
        HashSet<int> numset = new HashSet<int>();
        foreach (int num in nums)
        {
            if (numset.Contains(num))
            {
                return true;
            }
            numset.Add(num);
        }
        return false;
    }
}
