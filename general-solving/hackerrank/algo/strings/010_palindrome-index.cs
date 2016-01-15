/***************************************************************************
* Problem Name: Palindrome Index
* Problem URL : https://www.hackerrank.com/challenges/palindrome-index
* Domain      : algorithms/Strings
* Date        : Jan 3 2016
* Complexity  : O(N)
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        :  
* Notes       : A simple palindrome problem
*             - Find the index where a char does not match on the other side
*             -  Check excluding that character whether rest is palindrome
* meta        : tag-string
***************************************************************************/
using System;

class Solution {
    static void Main(String[] args) {
        int T = int.Parse(Console.ReadLine());

        while (T-- > 0) {
            string str = Console.ReadLine();
            /* i starts from beginning,
               j starts from end
            */
            int i = 0, j = str.Length - 1;
            for (; i < j; i++, j--) {
                if (str[i] != str[j]) {
                    // remove i-th char and check if rest is palindrome
                    if (isPalindrome(str, i + 1, j)) {
                        Console.WriteLine(i);
                        break;
                    }
                    // remove j-th char and check if rest is palindrome
                    if (isPalindrome(str, i, j - 1)) {
                        Console.WriteLine(j);
                        break;
                    }
                }
            }
            if (i >= j)
                Console.WriteLine("-1");
        }
    }

    /*
        This function tests if sub-string of the string is palindrome
         starting from index i to index j
    */
    static bool isPalindrome(string str, int i, int j)
    {
        for (; i < j; i++, j--)
            if (str[i] != str[j])
                return false;
        return true;
    }
}
