/*
*    Title      : Lonely Integer
*    Problem#   : https://www.hackerrank.com/challenges/lonely-integer
*    Domain     : Algorithms/Bit Manipulation
*    Data       : Sept 7 2015
*    Alogirthm  :   
*    Complexity : O(n)
*    Author     : Atiqur Rahman
*    Status     : Accepted
*    Notes      : This solution applies if all numbers are given in pairs (or even number of times) except
*                  the number we want to find
*                 ref: http://www.geeksforgeeks.org/find-the-element-that-appears-once/
*                 Indeed a nice trick to find the lonely integer
*   meta        : tag-bit-manipulation
*/
using System;

class Solution {
    static int lonelyinteger(int[] a) {
        int res = a[0];
        for (int i = 1; i<a.Length; i++) {
            res ^= a[i];
        }
        return res;
    }
}
