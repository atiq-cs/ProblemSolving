/***************************************************************************************************
* Title : Network
* URL   : 315
* Status: Accepted
* Notes : Articulation Point
* rel   : UVA 10199
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

enum cltype { WHITE, GRAY, BLACK };
enum cltype color[200];

int top = 0, Time = 0, pre[200], d[200], f[200], low[200], connected[200];
bool Taken[200];
vector<int> adj[200], arList;

void DFS_visit(int u) {
  connected[top++] = u;
  int v, i;
  color[u] = GRAY;
  low[u] = d[u] = ++Time;
  for (i = 0; i < adj[u].size(); i++) {
    v = adj[u][i];
    if (color[v] == WHITE) {
      pre[v] = u;
      DFS_visit(v);
      if (low[v] >= d[u]) {
        if (Taken[u] == false) {
          arList.push_back(u);
          Taken[u] = true;
        }
      }
      if (low[v] < low[u])
        low[u] = low[v];
    }
    else if (pre[u] != v) {
      if (d[v] < low[u])
        low[u] = d[v];
    }
  }
  color[u] = BLACK;
  f[u] = ++Time;
}

int main() {
  int i, nV, nE, a, b, j, u;

  while (scanf("%d", &nV) && nV) {
    memset(Taken, 0, nV);
    Time = 0;
    arList.clear();

    for (i = 0; i < nV; i++)
      adj[i].clear();

    while (scanf("%d", &a) && a) {
      a--;
      while (getchar() != '\n') {
        scanf("%d", &b);
        b--;
        adj[a].push_back(b);
        adj[b].push_back(a);
      }
    }


    for (i = 0; i < nV; i++) {
      color[i] = WHITE;
      pre[i] = -1;
      d[i] = INF;
      f[i] = INF;
      low[i] = INF;
    }

    // Avoiding loop to reduce time and because the graph is disconnected
    j = 0;
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

      // Find Articulation points (again) with new source to identify if root
      // is an articulation point
      // Condition: in mapping node 1 must exist
      u = connected[top - 1];
      if (u != j) {
        Taken[u] = true;
        DFS_visit(u);
      }
    }

    printf("%d\n", arList.size());
  }

  return 0;
}
