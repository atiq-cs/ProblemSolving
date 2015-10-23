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
