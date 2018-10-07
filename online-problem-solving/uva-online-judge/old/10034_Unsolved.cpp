#include <cstdio>
#include <queue>
#include <cmath>
#define INF 2147483647.0
#define EPS 1e-8
using namespace std;

int nV;
double weight[110][110], cost[110];

class vertexType {
public:
  bool operator<(const vertexType& ob) const { return cost[nodeNo]>cost[ob.nodeNo]; }
  int nodeNo;
  double x, y;
} freckle[110];

int main () {
  freopen("10034_in.txt", "r", stdin);
  double mst_PRIM(int r);

  int i, j, k, t;
  double minLength;

  scanf("%d", &t);
  for (i=0; i<t; i++) {
    scanf("%d", &nV);
    for (j=0; j<nV; j++) {
      scanf("%lf %lf", &freckle[j].x, &freckle[j].y);
      freckle[j].nodeNo = j;
    }
    for (j=0; j<nV-1; j++) {
      for (k=j+1; k<nV; k++) {
        weight[j][k] = sqrt((freckle[k].x - freckle[j].x) *  (freckle[k].x - freckle[j].x) + (freckle[k].y- freckle[j].y) *  (freckle[k].y- freckle[j].y));
        weight[k][j] = weight[j][k];
      }
    }

  /*  for (j=0; j<nV; j++) {
      for (k=0; k<nV; k++) {
        printf(" %lf", weight[j][k]);
      }
      putchar('\n');
    }*/

    minLength = mst_PRIM(0);
    if (i) putchar('\n');
    printf("%.2lf\n", minLength+EPS);
  }
  return 0;
}

double mst_PRIM(int r) {
  priority_queue<vertexType> Q;
  double length=0.0;
  bool Taken[110];

  int i, u;
  for (i=0; i<nV; i++) {
    cost[i] = INF;
    Taken[i] = false;
  }
  cost[r] = 0.0;


  Q.push(freckle[r]);

  while (!Q.empty()) {
    u = Q.top().nodeNo;
  //  printf("Just popped %d\n", u);
    Q.pop();
    if (Taken[u]==false) {
      length += cost[u];
      Taken[u] = true;
      for (i=0; i<nV; i++) {
        if (i != u && Taken[i
          ]==false && cost[i]>weight[i][u]) {
          cost[i] = weight[i][u];
        //  printf("Pushing %d\n",i);
          Q.push(freckle[i]);
        }
      }

    }
  }
  return length;
}