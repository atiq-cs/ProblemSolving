/***************************************************************************************************
* Title : Freckles
* URL   : 10034
* Author: Atiq Rahman
* Status: Accepted omitting use of array..
* Notes : Prim's MST, No special cases
* meta  : tag-graph-mst
***************************************************************************************************/
#include <cstdio>
#include <cmath>
#include <queue>
#define  INF 2147483640.0
#define EPS 1e-8
using namespace std;

class vertexType {
public:
  bool operator<(const vertexType& ob) const;
  double cost;
  int nodeNo;
};

double mst_visit(int root);

vertexType temp;
short n;
double weight[110][110];
bool Taken[110];

bool vertexType::operator<(const vertexType& ob) const {
  return (cost>ob.cost);
}

int main() {
  freopen("10034_in.txt", "r", stdin);
  freopen("10034_out.txt", "w", stdout);

  double minimumLength, x[110], y[110];
  short t, i, j, k;
  
  scanf("%hd", &t);
  for (i=0; i<t; i++) {
    scanf("%hd", &n);
    for (j=0; j<n; j++) {
      scanf("%lf %lf", &x[j], &y[j]);
    }
    
    for (j=0; j<n-1; j++) {
      for (k=j+1; k<n; k++) {
        weight[k][j] = sqrt((x[k]-x[j]) * (x[k]-x[j]) + (y[k]-y[j])*(y[k]-y[j]));
        weight[j][k] = weight[k][j];
      }
    }

    minimumLength = mst_visit(0);
    if (i)
      putchar('\n');
    printf("%.2lf\n", minimumLength+EPS);
  }
  return 0;
}

double mst_visit(int root) {
  int i, u;
  for (i=0; i<n; i++) {
    Taken[i] = false;
  }
  double length = 0.0;
  
  priority_queue<vertexType> Q;

  temp.nodeNo = root;
  temp.cost = 0.0;
  Q.push(temp);

  while (!Q.empty()) {
    temp = Q.top();
    u = temp.nodeNo;
    Q.pop();
    if (Taken[u]==false) {
      length += temp.cost;
      Taken[u] = true;
      for (i=0; i<n; i++) {
        if (Taken[i]==false) {
          temp.nodeNo = i;
          temp.cost = weight[u][i];
          Q.push(temp);
        }
      }
    }
  }
  return length;
}


// Presentation Error Source version from Board of Freckles
#include<stdio.h>
#include<math.h>

int main() {
  int t[100][2], nr[101], n, m, i, j, k;
  unsigned long c;
  float cost[101][101];
  float x[101], y[101], x1, y1;
  float min, temp;
  scanf("%lu", &c);

  while (c) {
    min = 0.0; c--;
    scanf("%d", &n);

    for (i = 1; i <= n; i++) {
      scanf("%f %f", &x1, &y1);
      x[i] = x1 * 10;
      y[i] = y1 * 10;
    }

    for (i = 1; i <= n; i++)
      cost[i][i] = 0.0;
    for (i = 1; i <= n; i++)
      for (j = i + 1; j <= n; j++) {
        cost[i][j] = (x[i] - x[j])*(x[i] - x[j]) + (y[i] - y[j])*(y[i] - y[j]);
        cost[j][i] = cost[i][j];
      }
    for (i = 2; i <= n; i++)
      nr[i] = 1;
    nr[1] = 0;

    for (i = 1; i < n; i++) {
      m = -2;
      for (j = 2; j <= n; j++) {
        if (nr[j] != 0 && m == -2)
          m = j;
        if (nr[j] != 0)
          if (cost[j][nr[j]] < cost[m][nr[m]]) m = j;
      }
      temp = cost[m][nr[m]] * 100;
      temp = sqrt(temp);
      min = min + temp;
      nr[m] = 0;
      for (k = 2; k <= n; k++) {
        if (nr[k] != 0)
          if (cost[k][nr[k]] > cost[k][m]) nr[k] = m;
      }
    }
    printf("%.2f", min / 100);
    if (c != 0)
      printf("\n\n");
  }
  return 0;
}
