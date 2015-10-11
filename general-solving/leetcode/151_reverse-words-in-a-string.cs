/***************************************************************************
*   Problem Name:  Reverse Words in a String
*   Problem URL :  https://leetcode.com/problems/reverse-words-in-a-string/
*   Date        :  Sept 29, 2015
*   Author      :  Atiq Rahman
*   Status      :  Accepted
*   Complexity  :  O(n) considering Array.Reverse (confirm)
*   Notes       :  Look after source code for detail analysis of the solution
*
*   meta        :  tag-string
***************************************************************************/

public class Solution {
    public string ReverseWords(string s) {
        string[] tokens= s.Split(' ');
        Array.Reverse(tokens);
        StringBuilder result = new StringBuilder();
        
        foreach (var str in tokens)
            if (str.Length != 0)
                result.Append(str+" ");
        
        return result.ToString().TrimEnd(' ');
    }
}
