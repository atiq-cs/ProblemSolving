/***************************************************************************
* Title : Word Pattern
* URL   : https://leetcode.com/problems/word-pattern
* Date  : 2018-05-06
* Author: Atiq Rahman
* Comp  : O(N^2), O(N), N = Length of pattern
* Status: Accepted
* Notes : Given a pattern (a number of chars) and a string (a number of words)
*   find if the string is following given pattern. First word first char in the
*   pattern; second word follows the second char and so on.
*   Example, pattern = "abba", str = "dog cat cat dog"
*   A few cases to consider,
*   - if the char and word do not exist in the hash-table we add a new entry for
*   them
*    - we also check if word exists even if the key does not exist because such
*    a case violates the pattern
*   - if the char exists in hash-table we match the word found in respective
*   index
*   
*   Time Complexity of ContainsValue()
*   O(N) time complexity for value look up in hashtable in C#, Java
*   "This method performs a linear search; therefore, this method is an O(n)
*   operation, where n is Count."
*   ref: https://msdn.microsoft.com/en-us/library/system.collections.hashtable.
*     containsvalue.aspx
*     
*   Overall time complexity of algorithm would be O(N^2) because in worst case
*   all items are unique in the pattern and string. Everytime new entry is
*   added O(N) lookup is done for ContainsValue()
*   
* meta  : tag-ds-hashtable, tag-leetcode-easy
***************************************************************************/
public class Solution {
  public bool WordPattern(string pattern, string str) {
    var charDict = new Dictionary<char, string>();

    string[] tokens = str.Split();
    if (pattern.Length != tokens.Length)
      return false;

    for (int i=0; i<tokens.Length; i++)
      if (charDict.ContainsKey(pattern[i]) == false) {
        if (charDict.ContainsValue(tokens[i]))    // O(N), note above
          return false;
        charDict.Add(pattern[i], tokens[i]);
      }
      else if (charDict[pattern[i]] != tokens[i])
        return false;

    return true;
  }
}
