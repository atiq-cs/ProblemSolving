/***************************************************************************************************
* Title : Dungeon Master
* URL   : 532
* Status: Accepted
* Comp  : O (V+E)
* Notes : Learnt to use 3 dimensional arrays
* meta  : tag-graph-bfs, tag-lang-c
***************************************************************************************************/
#include<iostream>
#include<cstdio>
#include<algorithm>
#include <vector>
#include <queue>
#include <new>
using namespace std;

enum cltype { WHITE=1, GRAY, BLACK };
enum cltype color[28000];
short end, vertexNo;
vector <int> adj[28000];

short bfs(int s) {
  int *d, i, v, u;
  d = new int[vertexNo];
  memset(d, 255, sizeof(int)* vertexNo);

  color[s] = GRAY;
  d[s] = 0;

  queue<int> Q;
  Q.push(s);

  while (!Q.empty()) {
    u = Q.front();
    Q.pop();

    for (i = 0; i < adj[u].size(); i++) {
      v = adj[u][i];
      if (color[v] == WHITE) {
        color[v] = GRAY;
        d[v] = d[u] + 1;
        Q.push(v);
      }
    }
    color[u] = BLACK;
  }

  return d[end];
}

int main() {
  short L, R, C, i, j, k, dungeon[32][32][32], escTime, source;
  char ch;

  while (scanf("%hd %hd %hd", &L, &R, &C) && (L || R || C)) {
    for (i=1; i<L * R * C; i++)
      adj[i].clear();
    vertexNo = 1;

    for (i=0; i<L; i++)
      for (j=0; j<R; j++)
        for (k=0; k<C; k++) {
          do
            scanf("%c", &ch);
          while (ch != 's' && ch !='E' && ch != '.' && ch != '#' && ch !='e' && ch != 'S');

          switch(ch) {
            case '#':
              dungeon[i][j][k] = 0;
              break;
            case '.':
              color[vertexNo] = WHITE;
              dungeon[i][j][k] = vertexNo++;
              break;
            case 's':
              color[vertexNo] = WHITE;
              source = vertexNo;
              dungeon[i][j][k] = vertexNo++;
              break;
            case 'E':
              color[vertexNo] = WHITE;
              end = vertexNo;
              dungeon[i][j][k] = vertexNo++;
              break;
            case 'S':
              color[vertexNo] = WHITE;
              source = vertexNo;
              dungeon[i][j][k] = vertexNo++;
              break;
            case 'e':
              color[vertexNo] = WHITE;
              end = vertexNo;
              dungeon[i][j][k] = vertexNo++;
              break;
            default:
              printf("Error\n");
          }

          if (dungeon[i][j][k]) {
            if (i>0 && dungeon[i-1][j][k]) {
              adj[dungeon[i-1][j][k]].push_back(dungeon[i][j][k]); 
              adj[dungeon[i][j][k]].push_back(dungeon[i-1][j][k]);
            }
            if (j>0 && dungeon[i][j-1][k]) {
              adj[dungeon[i][j-1][k]].push_back(dungeon[i][j][k]); 
              adj[dungeon[i][j][k]].push_back(dungeon[i][j-1][k]);
            }
            if (k>0 && dungeon[i][j][k-1]) {
              adj[dungeon[i][j][k-1]].push_back(dungeon[i][j][k]);
              adj[dungeon[i][j][k]].push_back(dungeon[i][j][k-1]);
            }
          }
        }

    escTime = bfs(source);

    if (escTime > 0)
      printf("Escaped in %hd minute(s).\n",escTime);
    else
      puts("Trapped!");
  }
  return 0;
}
