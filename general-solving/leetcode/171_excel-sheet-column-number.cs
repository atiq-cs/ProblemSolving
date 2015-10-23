/***************************************************************************
* Problem Name: Excel Sheet Column Number
* Problem URL : https://leetcode.com/problems/excel-sheet-column-number/
* Date        : Oct 7 2015
* Complexity  : O(n) Time and constant space
* Author      : Atiq Rahman
* Status      : Accepted (beats 98%)
* Notes       : 
* meta        : tag-binary-tree, tag-easy
***************************************************************************/

public class Solution
{
    public int TitleToNumber(string s)
    {
        int sum = 0;
        foreach (char ch in s)
            sum = sum * 26 + (int)(ch - 'A' + 1);
        return sum;
    }
}

/*
    Drafts,
    We know,
    Z = 26
    AA = 1 + 26
    BA = 1 + 2 * 26
    CA = 1 + 3 * 26
    ZA = 1 + 26 * 26

    base is 26
    first number is 1

    we can generalize that the number is,
    n = L0 + L1 * 26 + L2 * 26 * 26 + ....

*/
