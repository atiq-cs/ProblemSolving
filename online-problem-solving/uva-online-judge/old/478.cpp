/***************************************************************************************************
* Title : Points in Figures: Rectangles, Circles, Triangles
* URL   : 478
* Notes : Given a list of figures (rectangles, circles, and triangles) and a list of points in the
*   x-y plane, determine for each point which figures (if any) contain the point
*
*   Java/C# style variable is noticeable in this source file
* rel   : 476, 477
* meta  : tag-math, tag-lang-c
***************************************************************************************************/
#include <cstdio>
#include <cmath>
#include <algorithm>
#define EPS 1e-8
using namespace std;

struct unionType {
  char type;
  double x1, y1, x2, y2, x3, y3, radius;
};


bool isPointInsideRectangle (double px, double py, double x1, double y1, double x2, double y2) {
  bool insideX = false;
  bool insideY = false;

  if (x1 < x2) {
    if (x1<px && px<x2)
      insideX = true;
  }
  else if (x1>x2) {
    if (x2<px && px<x1)
      insideX = true;
  }

  if (y1 < y2) {
    if (y1<py && py<y2)
      insideY = true;
  }
  else if (y1>y2) {
    if (y2<py && py<y1)
      insideY = true;
  }
  if (insideX && insideY)
    return true;
  return false;
}

bool isPointInsideCircle(double px, double py, double x, double y, double radius) {
  double length = lengthLine(x, y, px, py);
  if (fabs(length - radius) < EPS)
    return false;
  if (length < radius)
    return true;
  return false;
}

bool isPointInsideTriangle (double px, double py, double x1, double y1, double x2, double y2, double x3, double y3) {
  double segment1 = triangleArea(px, py, x1, y1, x2, y2);
  double segment2 = triangleArea(px, py, x2, y2, x3, y3);
  double segment3 = triangleArea(px, py, x1, y1, x3, y3);

  if (segment1==0 || segment2==0 || segment3==0)
    return false;

  double Area = triangleArea(x1, y1, x2, y2, x3, y3);
  double checkArea = segment1 + segment2 + segment3;
  if (fabs(checkArea - Area) < EPS)
    return true;
  return false;
}

double triangleArea(double x1, double y1, double x2, double y2, double x3, double y3) {
  double Area = (x1 * (y2 - y3) + x2*(y3-y1) + x3 * (y1-y2)) / 2;
  if (Area < 0)
    return (-Area);
  return Area;
}

double lengthLine(double x1, double y1, double x2, double y2) {
  double dist = (x1 - x2) * (x1 - x2) + (y1-y2) * (y1-y2);
  dist = sqrt (dist);
  return dist;
}

int main() {
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
    if (figureType == 'c') {
      scanf("%lf %lf %lf", &figure[ind].x1, &figure[ind].y1, &figure[ind].radius);
      figure[ind++].type = figureType;
    }
    else if (figureType == 't') {
      scanf("%lf %lf %lf %lf %lf %lf", &figure[ind].x1, &figure[ind].y1, &figure[ind].x2, &figure[ind].y2, &figure[ind].x3, &figure[ind].y3);
      figure[ind++].type = figureType;
    }
  }
  top = 0;
  pointNo = 0;
  while (scanf("%lf %lf", &x, &y)) {
    if (fabs(x - 9999.9) < EPS && fabs(y - 9999.9) < EPS)
      break;
    pointNo++;
    insideNone = true;
    for (i = 0; i < ind; i++) {
      if (figure[i].type == 'r' && isPointInsideRectangle(x, y, figure[i].x1, figure[i].y1, figure[i].x2, figure[i].y2)) {
        insideNone = false;
        printf("Point %d is contained in figure %d\n", pointNo, i + 1);
      }
      else if (figure[i].type == 'c' && isPointInsideCircle(x, y, figure[i].x1, figure[i].y1, figure[i].radius)) {
        insideNone = false;
        printf("Point %d is contained in figure %d\n", pointNo, i + 1);
      }
      else if (figure[i].type == 't' && isPointInsideTriangle(x, y, figure[i].x1, figure[i].y1, figure[i].x2, figure[i].y2, figure[i].x3, figure[i].y3)) {
        insideNone = false;
        printf("Point %d is contained in figure %d\n", pointNo, i + 1);
      }
    }
    if (insideNone == true)
      printf("Point %d is not contained in any figure\n", pointNo);
  }

  return 0;
}
