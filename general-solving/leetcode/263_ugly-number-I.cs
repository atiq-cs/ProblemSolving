/***************************************************************************
*   Problem Name:   Find the minimum depth of a binary tree
*   Problem URL :   https://leetcode.com/problems/ugly-number/
*
*   Complexity  :   how to compute complexity of this
*   Author      :   Atiq Rahman
*   Status      :   Accepted
*   Notes       :   
***************************************************************************/

public class Solution
{
    public bool IsUgly(int num)
    {
        if (num == 0)
            return false;

        int[] divs = { 2, 3, 5 };
        for (int i = 0; i < 3; i++)
            while (num % divs[i] == 0)
                num /= divs[i];

        return num == 1;
    }
}
