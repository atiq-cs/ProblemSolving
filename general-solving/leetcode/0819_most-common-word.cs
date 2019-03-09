/***************************************************************************
* Title : Most Common Word
* URL   : https://leetcode.com/problems/most-common-word
* Date  : 2018-07-16
* Author: Atiq Rahman
* Comp  : O(N), O(N)
* Status: Accepted
* Notes : Solution simulated as it looked like
* meta  : tag-leetcode-easy, tag-hashtable
***************************************************************************/
public class Solution
{
  public string MostCommonWord(string paragraph, string[] banned) {
    string[] words = paragraph.Split(new char[] {' ', '!', '?', '\'', ',', ';', '.'});
    var bannedSet = new HashSet<string>();

    foreach(var word in banned)
      bannedSet.Add(word);

    string maxFreqIndex = "";
    var freq = new Dictionary<string, int>();

    foreach(var lWord in words) {
      if (lWord == "")
        continue;

      var word = lWord.ToLower();
      if (bannedSet.Contains(word) == false) {
        if (maxFreqIndex=="")
          maxFreqIndex = word;

        if (freq.ContainsKey(word)) {
          freq[word]++;
          if (freq[word] > freq[maxFreqIndex])
            maxFreqIndex = word;
        }
        else
          freq.Add(word, 1);
      }
    }
    return maxFreqIndex;
  }
}
