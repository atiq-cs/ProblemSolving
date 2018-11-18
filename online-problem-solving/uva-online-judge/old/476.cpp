/********************************************************************
* Title : Points in Figures: Rectangles
* URL   : 476
* Notes : Given a list of rectangles and a list of points in the x-y plane, determine for each
*   point which figures (if any) contain the point
*
*   Check '478.cpp' for header file inclusion list and functions
*   - isPointInsideRectangle
* rel   : 477, 478
* meta  : tag-math, tag-lang-c
********************************************************************/

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
    }
    if (insideNone == true)
      printf("Point %d is not contained in any figure\n", pointNo);
  }

  return 0;
}
