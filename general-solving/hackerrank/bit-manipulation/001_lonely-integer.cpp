/*
*    Title      : Lonely Integer
*    Problem#   : https://www.hackerrank.com/challenges/lonely-integer
*    Data       : Sep 7 2015
*    Algorithm  :   
*    Complexity : O(n)
*    Author     : Atiq Rahman
*    Status     : Accepted
*    Notes      : This solution applies if all numbers are given in pairs (or even number of times) except
*                  the number we want to find
*                 ref: http://www.geeksforgeeks.org/find-the-element-that-appears-once/
*                 Indeed a nice trick to find the lonely integer
*   meta        : tag-bit-manip
*/
using System;

class Solution
{
    static int lonelyinteger(int[] a) {
        int res = a[0];
        for (int i = 1; i<a.Length; i++) {
            res ^= a[i];
        }
        return res;
    }
}
