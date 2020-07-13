/***************************************************************************************************
* Title : Heavey Cargo
* URL   : 544
* Status: Accepted
* Comp  : O (V+E)
* Notes : Demonstrates operator overloading
* meta  : tag-graph-mst, tang-lang-cpp
***************************************************************************************************/
#include <cstdio>
#include <cmath>
#include <vector>
#include <queue>
#include <map>
#define  INF 100000
using namespace std;

class vehicle {
  char str[40];
public:
  vehicle() {  }
  vehicle(char *s) { strcpy(str,s); }
  char *get() {  return str; }
};

bool operator<(vehicle a, vehicle b) {
  return (strcmp(a.get(), b.get())<0);
}

class vertexType {
public:
  bool operator<(const vertexType& ob) const;
  int cost;
  int nodeNo;
};

bool vertexType::operator<(const vertexType& ob) const {
  return (cost<ob.cost);
}

vector<int> adj[305];
vertexType temp;
short n;
int load[205][205];
bool Taken[205];

int mst_visit(int root, int dest) {
  int i, u, v;
  for (i = 0; i < n; i++) {
    Taken[i] = false;
  }
  int min = INF;

  priority_queue<vertexType> Q;

  temp.nodeNo = root;
  temp.cost = INF;
  Q.push(temp);

  while (!Q.empty()) {
    temp = Q.top();
    u = temp.nodeNo;
    Q.pop();
    if (Taken[u] == false) {
      if (min > temp.cost)
        min = temp.cost;
      Taken[u] = true;
      if (u == dest)
        return min;
      for (i = 0; i < adj[u].size(); i++) {
        v = adj[u][i];
        if (Taken[v] == false) {
          temp.nodeNo = v;
          temp.cost = load[u][v];
          Q.push(temp);
        }
      }
    }
  }
  return min;
}


int main() {
  map<vehicle, int> cargo;
  map<vehicle, int>::iterator p;

  char str[40];
  short r, i, j, k, ind, a, b, sq = 0;
  int maxLoad;

  while (scanf("%hd %hd", &n, &r) && (n || r)) {
    for (i = 0; i < n; i++)
      adj[i].clear();

    for (j = 0; j < n - 1; j++)
      for (k = j + 1; k < n; k++)
        load[j][k] = load[k][j] = INF;

    cargo.clear();
    ind = 0;
    for (i = 0; i < r; i++) {
      scanf("%s", str);
      p = cargo.find(str);
      if (p == cargo.end()) {
        a = ind;
        cargo.insert(pair<vehicle, int>(vehicle(str), ind++));
      }
      else
        a = p->second;

      scanf("%s", str);
      p = cargo.find(str);
      if (p == cargo.end()) {
        b = ind;
        cargo.insert(pair<vehicle, int>(vehicle(str), ind++));
      }
      else
        b = p->second;

      scanf("%d", &load[a][b]);
      load[b][a] = load[a][b];
      adj[a].push_back(b);
      adj[b].push_back(a);
    }

    scanf("%s", str);
    p = cargo.find(str);
    a = p->second;

    scanf("%s", str);
    p = cargo.find(str);
    b = p->second;

    maxLoad = mst_visit(a, b);

    printf("Scenario #%d\n%d tons\n\n", ++sq, maxLoad);
  }

  return 0;
}
