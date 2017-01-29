/***************************************************************************
* Problem Name: Hash Tables: Ransom Note
* Problem URL : https://www.hackerrank.com/challenges/ctci-ransom-note
* Date        : Jan 23, 2016
* Complexity  : O(n+m) Time
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : 
*               The passing of m and n is redundant
*               We could use Array.Length
*               
* meta        : tag-hashtable; tag-data-structure
***************************************************************************/
using System;
using System.Collections.Generic;

class Solution {
  static void Main(String[] args) {
    string[] tokens_m = Console.ReadLine().Split(' ');
    int m = Convert.ToInt32(tokens_m[0]);
    int n = Convert.ToInt32(tokens_m[1]);
    string[] magazine = Console.ReadLine().Split(' ');
    string[] ransom = Console.ReadLine().Split(' ');

    Dictionary<string, int> wordDict = new Dictionary<string, int>();
    GetWordDict(magazine, m, wordDict);
    if (CreateRansomReplica(ransom, n, wordDict))
      Console.WriteLine("Yes");
    else
      Console.WriteLine("No");
  }

  /* fill in the hashset with words from magazine */
  static void GetWordDict(string[] arr, int len, Dictionary<string, int> wordDict) {
    for (int i = 0; i < len; i++)
      if (wordDict.ContainsKey(arr[i]))
        wordDict[arr[i]]++;
      else
        wordDict.Add(arr[i], 1);
  }

  /*
    Assumption: input magazine word set is more treated as set then items with frequencies
    meaning we do not keep track of frequencies

    if any of the ransom string does not exist in the original set
    ransom is not replicable
  */
  static bool CreateRansomReplica(string[] arr, int len, Dictionary<string, int> wordDict) {
    for (int i = 0; i < len; i++) {
      if (wordDict.ContainsKey(arr[i]) == false || wordDict[arr[i]] == 0)
        return false;
      wordDict[arr[i]]--;
    }
    return true;
  }
}
