/***************************************************************************
* Problem Name: Pangram
* Problem URL : http://codeforces.com/problemset/problem/520/A
* Occasion    : Codeforces Round #295 (Div. 2)
* Date        : Dec 31 2015
* Complexity  : O(n) to read all letters
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        :  
* Notes       : String is a pangram if all latin letters are present either
*                as upper case of lower case
*
* meta        : tag-anagram
***************************************************************************/

using System;
using System.Collections.Generic;

public class Solution {
    private static void Main() {
        int length = int.Parse(Console.ReadLine());
        string line = Console.ReadLine();
        int[] alpha = new int[26];
        foreach (char ch in line)
            alpha[(ch > 'Z' ? ch - 'a' : ch - 'A')]++;
        for (int i = 0; i < 26; i++)
            if (alpha[i] == 0)
            {
                Console.WriteLine("NO"); return;
            }
        Console.WriteLine("YES");
    }
}
