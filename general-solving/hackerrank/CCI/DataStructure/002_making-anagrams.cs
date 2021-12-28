﻿/***************************************************************************
* Problem Name: Strings: Making Anagrams
* Problem URL : https://www.hackerrank.com/challenges/ctci-making-anagrams
* Date        : Jan 22, 2017
* Complexity  : O(n+m) Time
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : 
*               Find frequencies of chars
*               Get differences and then sum
*               
* meta        : tag-easy, tag-string, tag-hash-table
***************************************************************************/
using System;

class Solution {
    static void Main(String[] args) {
        string a = Console.ReadLine();
        string b = Console.ReadLine();

        /* array with known size - alternative to hash table */
        int[] fa= new int['z'+1];
        int[] fb= new int['z'+1];
        getFrequency(a, fa);
        getFrequency(b, fb);
        
        /* sum of difference for two strings */
        int dSum = 0;
        for (int i='0'; i<='z'; i++)
            dSum += Math.Abs(fa[i]-fb[i]);
            
        Console.WriteLine(dSum);
    }
    
    static void getFrequency(string s, int[] f) {
        for (int i=0; i<s.Length; i++)
            f[s[i]]++;
    }
}
