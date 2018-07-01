/***************************************************************************
* Title : Word Ladder
* URL   : https://leetcode.com/problems/word-ladder/
* Date  : 2018-05-17
* Author: Atiq Rahman
* Comp  : O(V+E*n), where n is worst case length of string
* Status: TLE (30/39 test cases passed)
* Notes : BFS solves this problem. We use null as end of level indicator, I took
*   this hint from https://leetcode.com/problems/word-ladder/discuss/40717/
*   Another-accepted-Java-solution-(BFS)
* meta  : tag-bfs, tag-leetcode-medium, tag-graph, tag-company-imo-im
***************************************************************************/
public class Solution {
  public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
    Queue<string> queue = new Queue<string>();
    queue.Enqueue(beginWord);
    queue.Enqueue(null);
    HashSet<string> VisitedSet = new HashSet<string>();
    int level = 1;
    HashSet<string> wordSet = new HashSet<string>();
    foreach (string word in wordList)
      wordSet.Add(word);
    
    while (queue.Count > 0) {
      string u = queue.Dequeue();
      if (u == null) {
        level++;
        if (queue.Count > 0)
          queue.Enqueue(null);
        continue;
      }      
      VisitedSet.Add(u);

      for (int i=0; i<u.Length; i++) {
        char[] chars = u.ToCharArray();
        for (char ch = 'a'; ch <= 'z'; ch++) {
          chars[i] = ch;
          string v = new string(chars);
          if (wordSet.Contains(v) == false)
            continue;
          if (v == endWord)
            return level + 1;
          if (VisitedSet.Contains(v) == false)
            queue.Enqueue(v);
        }
        
      }
    }
    return 0;
  }
}
/* TLE - Test-case# 31
nanny"
"aloud"
*/
