/***************************************************************************************************
* Title : Tourist Guide
* URL   : 10199
* Status: Accepted
* Notes : Articulation Point
*   Confusions, Is the graph connected? If the graph is not connected then my algo does not work
*   Special Cases, The graph migt be disconnected, output should be in alphabetic order
*   ToDO, should go graph/algo core
* meta  : tag-graph-dfs
***************************************************************************************************/
#include <cstdio>
#include <cstring>
#include <cstdlib>
#include <cmath>
#include <vector>
#include <map>
#define  INF 2147483647
using namespace std;

enum cltype{ WHITE, GRAY, BLACK };
enum cltype color[200];

int top = 0, Time = 0, pre[200], d[200], f[200], low[200], connected[200];
bool Taken[200];
vector<int> adj[200], arList;

class location {
  char str[40];
public:
  location() {  }
  location(char *s) { strcpy(str,s); }
  char *get() {  return str; }
  void show() { puts(str); }
};

bool operator<(location a, location b) {
  return (strcmp(a.get(), b.get())<0);
}

void DFS_visit(int u) {
  connected[top++] = u;
  int v, i;
  color[u] = GRAY;
  low[u] = d[u] = ++Time;

  for (i=0; i<adj[u].size(); i++) {
    v = adj[u][i];

    if (color[v] == WHITE) {
      pre[v] = u;
      DFS_visit(v);

      if (low[v]>=d[u]) {
        if (Taken[u] == false) {
          arList.push_back(u);
          Taken[u] = true;
        }
      }

      if (low[v]<low[u])
        low[u] = low[v];
    }
    else if (pre[u] != v) {
      if (d[v]<low[u])
        low[u]  = d[v];
    }
  }

  color[u] = BLACK;
  f[u] = ++Time;
}

int main() {
  int i, nV, nE, a, b, sq = 0, j, u;

  char tmp[40];
  map<typeName, int> directory;
  map<typeName, int>::iterator p;

  location tmpC;

  while (scanf("%d", &nV) && nV) {
    directory.clear();
    memset(Taken, 0, nV);
    Time = 0;
    arList.clear();

    for (i = 0; i < nV; i++)
      adj[i].clear();

    for (i = 0; i < nV; i++) {
      scanf("%s", tmp);
      directory.insert(pair<location, int>(location(tmp), i));
    }

    scanf("%d", &nE);

    for (i = 0; i < nE; i++) {
      scanf("%s", tmp);
      // name must be valid to be found nor iterator p will be invalid
      p = directory.find(location(tmp));
      a = p->second;
      scanf("%s", tmp);
      // name must be valid to be found nor iterator p will be invalid
      p = directory.find(location(tmp));
      b = p->second;

      adj[a].push_back(b);
      adj[b].push_back(a);
    }

    for (i = 0; i < nV; i++) {
      color[i] = WHITE;
      pre[i] = -1;

      d[i] = INF;
      f[i] = INF;
      low[i] = INF;
    }

    for (j = 0; j < nV; j++) {
      if (color[j] == WHITE) {
        top = 0;

        // Condition:  in mapping node 0 must exist    
        Taken[j] = true;
        DFS_visit(j);
        Taken[j] = false;

        // Initialize
        Time = 0;
        for (i = 0; i < top; i++) {
          u = connected[i];
          color[u] = WHITE;
          pre[u] = -1;
          d[u] = INF;
          f[u] = INF;
          low[u] = INF;
        }

        // Re-find Articulation points with new source to identify if root is an articulation         point
        // Condition:    in mapping node 1 must exist
        u = connected[top - 1];
        if (u != j) {
          Taken[u] = true;
          DFS_visit(u);
        }
      }
    }

    if (sq)
      putchar('\n');
    printf("City map #%d: %d camera(s) found\n", ++sq, arList.size());

    // arrange in alphabetic order
    for (p = directory.begin(); p != directory.end() && arList.size(); p++)
      for (i = 0; i < arList.size(); i++)
        if (p->second == arList[i]) {
          tmpC = p->first;
          tmpC.show();
          arList.erase(arList.begin() + i);
        }
  }

  return 0;
}
