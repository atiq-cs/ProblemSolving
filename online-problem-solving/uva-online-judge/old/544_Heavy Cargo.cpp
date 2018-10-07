/*******************************************************
*    Problem Name:    Freckles  
*    Problem ID:      544
*    Occassion:      Offline Solving
*
*    Algorithm:        Prim's MST
*    Special Case:    No special cases
*    Judge Status:     Accepted
*    Author:          Atiq Rahman
*******************************************************/
//#include <iostream>
#include <cstdio>
#include <cmath>
//#include <cstring>
//#include <new>
#include <vector>
#include <queue>
#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
#define  INF 100000
//#define EPS 1e-8
using namespace std;

int mst_visit(int root, int dest);

class vehicle {
  char str[40];
public:
  vehicle() {  }
  vehicle(char *s) { strcpy(str,s); }
  char *get() {  return str; }
//  void show() { puts(str); }
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


int main() {
  freopen("544_in.txt", "r", stdin);
//  freopen("544_out.txt", "w", stdout);

  map<vehicle, int> cargo;
  map<vehicle, int>::iterator p;

    char str[40];
  short r, i, j, k, ind, a, b, sq=0;
    int maxLoad;
  
  while(scanf("%hd %hd", &n, &r) && (n || r)) {
    for (i=0; i<n; i++)
      adj[i].clear();
      
    for (j=0; j<n-1; j++)
      for (k=j+1; k<n; k++)
        load[j][k] = load[k][j] = INF;

    cargo.clear();
    ind = 0;
    for (i=0; i<r; i++) {
      scanf("%s", str);
        //    printf("string1: %s\n", str);
      p = cargo.find(str);
      if (p==cargo.end()) {
        a = ind;
        cargo.insert(pair<vehicle, int>(vehicle(str), ind++));
      }
      else
        a = p->second;
  
      scanf("%s", str);
        //    printf("string2: %s\n", str);
      p = cargo.find(str);
      if (p==cargo.end()) {
        b = ind;
        cargo.insert(pair<vehicle, int>(vehicle(str), ind++));
      }
      else
        b = p->second;
      scanf("%d", &load[a][b]);
      load[b][a] = load[a][b];
    //  printf("weight %d %d: %d\n", a, b, load[b][a]);
      adj[a].push_back(b);
      adj[b].push_back(a);
    }
    /*for (j=0; j<n; j++) {
      printf("%d:", j);
      for (k=0; k<n; k++) {
        printf("  %d ",load[j][k]);
      }
      putchar('\n');
    }

    puts("in map");
    for (p = cargo.begin(); p != cargo.end(); p++) {
      vehicle tmp = p->first;
      printf("String %d: %s\n", p->second, tmp.get());
    }*/

    scanf("%s", str);
    p = cargo.find(str);
    a = p->second;

    scanf("%s", str);
    p = cargo.find(str);
    b = p->second;
//    printf("a: %d, b: %d\n", a, b);

    maxLoad = mst_visit(a, b);
    
    printf("Scenario #%d\n%d tons\n\n", ++sq, maxLoad);
  }
  return 0;
}

int mst_visit(int root, int dest) {
  int i, u, v;
  for (i=0; i<n; i++) {
    Taken[i] = false;
  }
  int min=INF;
  
  priority_queue<vertexType> Q;

  temp.nodeNo = root;
  temp.cost = INF;
  Q.push(temp);

  while (!Q.empty()) {
    temp = Q.top();
//    printf("cost of popped: %d\n", temp.cost);
    u = temp.nodeNo;
//    printf("In sequence: %d\n", u);
    Q.pop();
    if (Taken[u]==false) {
    //  printf("Just popped: %d & cost: %.5lf\n\n", u, cost[u]);
            if ( min > temp.cost)
                min = temp.cost;
      Taken[u] = true;
            if (u == dest)
                return min;
      for (i=0; i<adj[u].size(); i++) {
        v = adj[u][i];
      //  printf("cost from %d to %d: %lf\n", u, i, weight);
        if (Taken[v]==false) {
          temp.nodeNo = v;
          temp.cost = load[u][v];
      //    printf("updating %d with respect to %d with cost %d\n", v, u, load[u][v]);
          Q.push(temp);
        }
      }
    }
  }
  return min;
}
