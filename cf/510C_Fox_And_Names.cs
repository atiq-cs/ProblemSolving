/***************************************************************************
* Title : Fox And Names
* URL   : http://codeforces.com/problemset/problem/281/A
* Contst: Codeforces Round #290 (Div. 2)
* Date  : 2018-04-08
* Author: Atiq Rahman
* Comp  : O(V+E), where #V = 26
* Status: Accepted
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
*   Have a look at the draft for initial examples worked out.
*
*   Early termination on cycle detection (interpreted as error)
* meta  : tag-graph, tag-topological-sort, tag-dfs
***************************************************************************/
using System;
using System.Collections.Generic;
using System.Text;

public class TopoSort {
  internal enum COLOR { WHITE, GRAY, BLACK };
  internal class Vertex {
    // Additional space complexity
    // can be replaced with an array indexing or HashSet
    // currently only used for marking if it is in result set of topo sort or
    // not using -1
    public int CharValue { get; set; }
    public COLOR Color { get; set; }
    public Vertex(int ch, COLOR color) {
      CharValue = ch;
      Color = color;
    }
  }

  // Array of List
  List<int>[] AdjList;
  int nV;
  bool HasCycle;
  StringBuilder sb;
  Vertex[] vertices;
  List<char> orderedChars;

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

  public string GetResult() {
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

  /*
   * GRAY color is necessary to detect cycle
   * It cannot be replaced with simple boolean visited array that I usually use
   */
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
    TopoSort demo = new TopoSort();
    demo.TakeInput();
    Console.WriteLine(demo.GetResult());
  }
}

/*
First version of Topological sort I implemented following visit function uses
a global time variable and we sort the vertices later in decreasing order of
finishing itme.

private void DFSVisit(int u) {
  if (HasCycle)
    return;
  time++;
  IsVisited[u] = true;
  foreach (int v in AdjList[u])
    if (IsVisited[v]) { 
      HasCycle = true;
      return;
    } else
      DFSVisit(v);
  time++;
  vertices[u].FinishTime = time;
}
*/


/* Draft of calculations below,
3
rivest
shamir
adleman

Need enforce following order,
r < s < a
Output becomes,
bcdefghijklmnopqrsatuvwxyz

10
tourist
petr
wjmzbmr
yeputons
vepifanov
scottwu
oooooooooooooooo
subscriber
rowdark
tankengineer

t < p
y < v
v < s
s < o
o < s
cycle so,
output: impossible


10
petr
egor
endagorion
feferivan
ilovetanyaromanova
kostka
dmitriyh
maratsnowbear
bredorjaguarturnik
cgyforever

p < e
g < n
f < i
i < k
k < d
d < m
m < b
b < c

g < n &
p < e < f < i < k < d < m < b < c

apefikdmbcghjnoqrstuvwxyz


if two strings are equal or first one's length greater than the second one
then, it's impossible.

abc
abcd

3
abc
bcd
cde

a -> b
b -> c

3
bbc
acd
cde

3
bac
abd
cde

4
bac
abd
bde
cde

2
abc
abc
*/
