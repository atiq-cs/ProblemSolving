/***************************************************************************
* Title : Word Ladder
* URL   : https://leetcode.com/problems/word-ladder/
* Date  : 2018-05-17
* Author: Atiq Rahman
* Occasn: Den Meetup 2018-07-22 (TLE fixed), a variation probably been in InnoWorld as well.
* Comp  : O(V+E)
* Status: Accepted
* Notes : Complexity Analysis
*   Max |V| is number of words in wordList, however, consider we are generating
*   all words of 26 letters. Hence, complexity is exponential, 26^n where n is
*   worst case length of a word
*   
*   A classic BFS problem. This way of generating adjacent word list is working
*   because length of input string is less for testcases of this problem.
*   Hence, this approach works better than generating adjacency using word list
*   
*   Contains Generic Collections (queue) initiazer syntax
* ref   : https://leetcode.com/problems/word-ladder/discuss/40717/
*   Another-accepted-Java-solution-(BFS)
* meta  : tag-graph-bfs, tag-company-imo-im, tag-csharp-initializer-syntax, tag-leetcode-medium
***************************************************************************/
public class Solution {
  public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
    var queue = new Queue<string>(new[] { beginWord, null });
    HashSet<string> VisitedSet = new HashSet<string>();
    // TLE if this is not converted to HashSet
    HashSet<string> wordSet = new HashSet<string>(wordList);
    int level = 1;

    while (queue.Count > 0) {
      string u = queue.Dequeue();
      if (u == null) {
        level++;
        if (queue.Count > 0)
          queue.Enqueue(null);
        continue;
      }

      // TLE if this is not checked here
      if (VisitedSet.Contains(u))
        continue;

      VisitedSet.Add(u);

      // slight optimization here, instead of generating everytime, convert
      // once and reuse, by restoring the old value back at each index
      char[] chars = u.ToCharArray();

      for (int i=0; i<u.Length; i++)
        for (char ch = 'a'; ch <= 'z'; ch++) {
          char old = chars[i];
          chars[i] = ch;
          string v = new string(chars);
          chars[i] = old;
          if (wordSet.Contains(v) == false)
            continue;

          if (v == endWord)
            return level + 1;

          if (VisitedSet.Contains(v) == false)
            queue.Enqueue(v);
        }

    }
    return 0;
  }

  //first version TLE
  public int LadderLength() {
    // ... ...
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
}

/* Fixed TLE for Test-case# 31 and so on,
"nanny"
"aloud"
["ricky","grind","cubic","panic","lover","farce","gofer","sales","flint",
"omens","lipid","briny","cloth","anted","slime","oaten","harsh","touts", ... ]
*/
