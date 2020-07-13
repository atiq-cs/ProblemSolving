/***************************************************************************
* Title : Rotate Words
* URL   : http://lintcode.com/en/problem/rotate-words/
* Date  : 2018-01-27
* Status: Accepted
* Comp  : O(N^2 * m) where N^2 is the complexity for the loops
* Notes : Example usage of dictionary
*   Implements an easy way of detecting rotated word
*   Worst case time analysis: 
*    1 + 2 + 3 + 4 + .... + N = N * (N+1) / 2 = O(N^2)
*   m is the length of the largest string being compared to check if the word
a rotated version
* meta  : tag-string, tag-hashtable
***************************************************************************/
class Solution {
private:
  unordered_set<string> uniqueWordList;

public:
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
