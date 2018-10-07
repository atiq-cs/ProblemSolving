/*******************************************************************
*    Problem Name:  Points in Figures: Rectangles, Circles, and Triangles
*    Problem ID:    476
*    Occassion:    Offline solving
*
*    Algorithm:      Intersection
*    Special Case:    Inside or coincide
*    Judge Status:    Accepted
*    Author:        Atiq Rahman
********************************************************************/
#include <cstdio>
#include <cmath>
#include <algorithm>
#define EPS 1e-8
using namespace std;

bool isPointInsideRectangle (double px, double py, double x1, double y1, double x2, double y2);

struct unionType {
  char type;
  double x1, y1, x2, y2, x3, y3, radius;
};

int main() {
  freopen("476_in.txt", "r", stdin);

  struct unionType figure[5000];
  double x, y;
  int ind = 0, top, pointNo, i;
  char figureType;
  bool insideNone;

  while (scanf("%c", &figureType) && figureType != '*') {
    if (figureType == 'r') {
      scanf("%lf %lf %lf %lf", &figure[ind].x1, &figure[ind].y1, &figure[ind].x2, &figure[ind].y2);
      figure[ind++].type = figureType;
    }
  }
  top = 0;
  pointNo = 0;
  while (scanf("%lf %lf", &x, &y)) {
    if (fabs(x-9999.9)<EPS && fabs(y-9999.9)<EPS)
      break;
    pointNo++;
    insideNone = true;
    for (i=0; i<ind; i++) {
      if (figure[i].type == 'r' && isPointInsideRectangle(x, y, figure[i].x1, figure[i].y1, figure[i].x2, figure[i].y2)) {
        insideNone = false;
        printf("Point %d is contained in figure %d\n", pointNo, i+1);
      }
    }
    if (insideNone==true)
      printf("Point %d is not contained in any figure\n", pointNo);
  }
  
  return 0;
}

bool isPointInsideRectangle (double px, double py, double x1, double y1, double x2, double y2) {
  bool insideX = false;
  bool insideY = false;
  if (x1 < x2) {
    if (x1<px && px<x2) {
      insideX = true;
    }
  }
  else   if (x1>x2) {
    if (x2<px && px<x1) {
      insideX = true;
    }
  }

  if (y1 < y2) {
    if (y1<py && py<y2) {
      insideY = true;
    }
  }
  else   if (y1>y2) {
    if (y2<py && py<y1) {
      insideY = true;
    }
  }
  if (insideX && insideY)
    return true;
  return false;
}
