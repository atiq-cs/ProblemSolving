/*******************************************************
*    Problem Name:  Freckles  
*    Problem ID:    10034
*    Occassion:    Offline Solving
*
*    Algorithm:      Prim's MST
*    Special Case:    No special cases
*    Judge Status:    Accepted omitting use of array..
*    Author:        Atiq Rahman
*******************************************************/
//#include <iostream>
#include <cstdio>
#include <cmath>
//#include <cstring>
//#include <new>
//#include <vector>
#include <queue>
//#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
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

  /*  for (j=0; j<n; j++) {
      printf("%d: ", j);
      for (k=0; k<n; k++) {
        printf(" %lf(%d)",weight[j][k],k);
      }
      putchar('\n');
    }*/
    
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
    //  printf("Just popped: %d & cost: %.5lf\n\n", u, cost[u]);
      length += temp.cost;
      Taken[u] = true;
      for (i=0; i<n; i++) {
      //  printf("cost from %d to %d: %lf\n", u, i, weight);
        if (Taken[i]==false) {
          temp.nodeNo = i;
          temp.cost = weight[u][i];
        //  printf("Pushing %d with cost: %lf\n", i, cost[i]);
          Q.push(temp);
        }
      }
    }
  }
  return length;
}

/*
    memset(arrayName, 255, )  
    cout.setf (ios::fixed, ios::floatfield);
    cout.setf(ios::showpoint);
    cout<<setprecision(2)<<sum_c + eps<<endl;

*/
