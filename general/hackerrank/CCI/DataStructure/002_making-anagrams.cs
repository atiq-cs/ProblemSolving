/***************************************************************************************************
* Title : Strings: Making Anagrams
* URL   : https://www.hackerrank.com/challenges/ctci-making-anagrams
* Date  : 2017-01-22
* Comp  : O(n+m)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
*   Find frequencies of chars; get differences and then sum
*   
* meta  : tag-easy, tag-string, tag-hash-table
***************************************************************************************************/
using System;

class HKSolution {
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
