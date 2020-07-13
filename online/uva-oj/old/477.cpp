/***************************************************************************************************
* Title : Points in Figures: Rectangles and Circles
* URL   : 477
* Notes :
*   Check '478.cpp' for header file inclusion list and functions
*   - struct unionType
*   - isPointInsideCircle
*   - isPointInsideRectangle
*   - lengthLine
* rel   : 476, 478
* meta  : tag-math, tag-lang-c
***************************************************************************************************/
int main() {
  struct unionType figure[5000];
  double x, y;
  int ind = 0, top, pointNo, i;
  char figureType;
  bool insideNone;

  while (scanf("%c", &figureType) && figureType != '*')
    if (figureType == 'r') {
      scanf("%lf %lf %lf %lf", &figure[ind].x1, &figure[ind].y1, &figure[ind].x2, &figure[ind].y2);
      figure[ind++].type = figureType;
    }
    else if (figureType == 'c') {
      scanf("%lf %lf %lf", &figure[ind].x1, &figure[ind].y1, &figure[ind].radius);
      figure[ind++].type = figureType;
    }

  top = 0;
  pointNo = 0;

  while (scanf("%lf %lf", &x, &y)) {
    if (fabs(x - 9999.9) < EPS && fabs(y - 9999.9) < EPS)
      break;

    pointNo++;
    insideNone = true;

    for (i = 0; i < ind; i++)
      if (figure[i].type == 'r' && isPointInsideRectangle(x, y, figure[i].x1,
          figure[i].y1, figure[i].x2, figure[i].y2)) {
        insideNone = false;
        printf("Point %d is contained in figure %d\n", pointNo, i + 1);
      }
      else if (figure[i].type == 'c' && isPointInsideCircle(x, y, figure[i].x1,
          figure[i].y1, figure[i].radius)) {
        insideNone = false;
        printf("Point %d is contained in figure %d\n", pointNo, i + 1);
      }

    if (insideNone == true)
      printf("Point %d is not contained in any figure\n", pointNo);
  }

  return 0;
}
