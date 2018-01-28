/***************************************************************************
* Title : Rotate Words
* URL   : http://lintcode.com/en/problem/rotate-words/
* Date  : 2018-01-27
* Author: Atiq Rahman
* Comp  : O(N^2 * m) where N^2 is the complexity for the loops, in wrost case,
*     1 + 2 + 3 + 4 + .... + N = N * (N+1) / 2 = O(N^2)
*   m is the length of the largest string being compared to check if the word
*   a rotated version
* Status: Accepted
* Notes : Example usage of dictionary
*   Implements an easy way of detecting rotated word
*
* meta  : tag-string, tag-hashtable, tag-easy
***************************************************************************/
class Solution {
private:
  unordered_set<string> uniqueWordList;
public:
  /*
  * @param words: A list of words
  * @return: Return how many different rotate words
  */
  int countRotateWords(vector<string> words) {
    int count = 0;
    for (auto& word : words)
      if (isRotatedWord(word) == false)
        count++;
    return count;
  }

  bool isRotatedWord(string word) {
    for (auto& uniqueWord : uniqueWordList)
      if (uniqueWord.size() == word.size() && (uniqueWord + uniqueWord).
        find(word) != std::string::npos)
        return true;
    uniqueWordList.insert(word);
    return false;
  }
};
