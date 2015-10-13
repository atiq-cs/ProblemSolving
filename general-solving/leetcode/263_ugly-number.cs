/***************************************************************************
*   Problem Name:  Ugly Number
*   Problem URL :  https://leetcode.com/problems/ugly-number/
*   Date        :  Aug 20, 2015
*   Complexity  :  O(n)
*   Author      :  Atiq Rahman
*   Status      :  Accepted
*   Notes       :  
*   meta        :  tag-easy
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
