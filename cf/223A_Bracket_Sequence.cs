/***************************************************************************
* Title : Bracket Sequence
* URL   : http://codeforces.com/problemset/problem/223/A
* Contst: Codeforces Round #290 (Div. 2)
* Date  : 2018-04-20
* Author: Atiq Rahman
* Comp  : O(V+E), where #V = 26
* Status: WA
* Notes : The problem asks us to find an ordering of the letters of alphabet so
*   that original list of given author names are still lexicographically sorted
*   As we can see, interestingly, this problem, instead of asking to sort
*   author names it is asking to generate a permutation of letters in alphabet
*   so that author names stay sorted instead.
*   
*   This requires creating a graph based on the char edges from names. However,
*   if there is a cylce we should report "Impossible". Additionally, cases to
*   consider,
*   - if both strings are equal (length as well) then it's impossible
*   - if first string is longer than second one but contains same length of
*   prefix then it is impossible as well.
*
*   Early termination on cycle detection (interpreted as error)
*
*   Misunderstood the problem, look at the bottom for understanding judge's
*   test-case.. yet to solve.. ToDo
* meta  : tag-string, tag-easy, tag-judge-ToDo
***************************************************************************/
using System;

public class BracketCounter {
  public void TakeInput() {
    int n = int.Parse(Console.ReadLine());
    nV = 26;                              // number of lowercase latin letters
    HasCycle = false;
    orderedChars = new List<char>();
    string[] names = new string[n];
    vertices = new Vertex[nV];
    for (int i = 0; i < n; i++)
      names[i] = Console.ReadLine();

    AdjList = new List<int>[nV];
    for (int i = 0; i < nV; i++) {
      AdjList[i] = new List<int>();
      vertices[i] = new Vertex(i, COLOR.WHITE);
    }

    // Build adjacency list from given list of strings
    for (int i = 1; i < n && HasCycle==false; i++) {
      int len = Math.Min(names[i-1].Length, names[i].Length);
      int j = 0;
      for (; j < len && HasCycle == false; j++) {
        // we got u and v, an arrow from u to v
        int u = names[i - 1][j] - 'a';
        int v = names[i][j] - 'a';
        if (u != v) {
          AdjList[u].Add(v);
          break;
        }
      }
      if (j == len && names[i - 1].Length >= names[i].Length)
        HasCycle = true;
    }
  }

  public string Count(string exp) {
    if (HasCycle)
      return "Impossible";

    sb = new StringBuilder();
    for (int i=0; i<nV; i++)
      if (vertices[i].Color==COLOR.WHITE && AdjList[i].Count > 0)
        DFSVisit(i);
    if (HasCycle)
      return "Impossible";

    for (int i = orderedChars.Count - 1; i >= 0; i--) {
      sb.Append(orderedChars[i]);
      vertices[orderedChars[i] - 'a'].CharValue = -1;
    }

    foreach (Vertex v in vertices)
      if (v.CharValue != -1)
        sb.Append((char)(v.CharValue+'a'));

    return sb.ToString();
  }

  private void DFSVisit(int u) {
    if (HasCycle)
      return;
    if (vertices[u].Color == COLOR.BLACK)
      return;
    if (vertices[u].Color == COLOR.GRAY) {
      HasCycle = true;
      return;
    }

    vertices[u].Color = COLOR.GRAY;
    foreach (int v in AdjList[u])
      DFSVisit(v);
    vertices[u].Color = COLOR.BLACK;
    orderedChars.Add((char)(vertices[u].CharValue+'a'));
  }
}

public class CFSolution {
  public static void Main() {
    BracketCounter demo = new BracketCounter();
    Console.WriteLine(demo.Count(Console.ReadLine()));
  }
}

/* To understand consider following test-case,
Input
(][)
My output
0
()
Expected answer
0

Checker comment
wrong answer Answer is not a substring of input string 
*/
