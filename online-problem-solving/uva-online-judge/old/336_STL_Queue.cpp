/***************************************************************************************************
* Status: Accepted
* Notes:
*   There are problems with judge input file (such as number of nodes more than that it is described)
*   check other files,
*   - charlie
*   - judge
*   - My_Queue
* meta  : tag-graph-bfs, tag-ds-queue
***************************************************************************************************/

#include <cstdio>
#include <map>
#include <queue>
using namespace std;


int Adj[100][100], len[100], VertexNo;

int main () {
  int BFS_visit(int source, int range);

  int u, v, i, uI, vI, TTL, unreachable, NC, sq=1;
  map<int, int> mp;
  map<int, int>::iterator p;
  
  while (scanf("%d", &NC) && NC) {
    // Initialization
    mp.clear();
    memset(len, 0, sizeof(len));
    VertexNo = 0;

    // Input adjacency lists and build
    for (i=0; i<NC; i++) {
      scanf("%d %d", &u, &v);

      if (u == v) {
        p = mp.find(u);
        if (p == mp.end())
          mp.insert(pair<int, int>(u, VertexNo++));
      }
      else {
        p = mp.find(u);
        if (p == mp.end()) {
          uI = VertexNo;
          mp.insert(pair<int, int>(u, VertexNo++));
        }
        else
          uI = p->second;

        p = mp.find(v);
        if (p == mp.end()) {
          vI = VertexNo;
          mp.insert(pair<int, int>(v, VertexNo++));
        }
        else
          vI = p->second;

        Adj[vI][len[vI]++] = uI;
        Adj[uI][len[uI]++] = vI;
      }
    }
    // Take queries and BFS visit.
    while (scanf("%d %d", &v, &TTL) && (v || TTL)) {
      unreachable = VertexNo - BFS_visit(mp[v], TTL);
      printf("Case %d: %d nodes not reachable from node %d with TTL = %d.\n", sq++, unreachable, v, TTL);
    }
  }
  return 0;
}

int BFS_visit(int source, int range) {
  int d[40], reachable =0, u, i, v;

  memset(d, 255, VertexNo * sizeof(int));
  d[source] = 0;

  queue<int> Q;
  Q.push(source);

  while (!Q.empty()) {
    u = Q.front();
    Q.pop();
    if (d[u] <=range) {
      reachable++;
      for (i=0; i<len[u]; i++) {
        v = Adj[u][i];
        if (d[v]<0) {
          d[v] = d[u] + 1;
          Q.push(v);
        }
      }
    }
    else
      break;
  }
  return reachable;
}
