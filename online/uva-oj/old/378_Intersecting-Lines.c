/***************************************************************************************************
* Title : Intersecting Lines
* URL   : 378
* Status: Accepted (0.000s)
* Notes : line is found checking area for 3 points. If that's a zero then print line
*   Use tag like this to detect online judge,
*   #ifndef ONLINE_JUDGE
*   freopen("378.in","r",stdin);
*   #endif
*
* check if parallel for 3 points, this solution with slight change is having slightly faster runtime
* meta  : tag-math, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>
#include<math.h>

#define EPS 1e-8

int main() {
  int n, i;
  double a1, b1, c1, a2, b2, c2, x, y;
  int x1, x2, y1, y2, x3, y3, x4, y4;

  printf("INTERSECTING LINES OUTPUT\n");

  scanf("%d", &n);
  for (i = 0; i < n; i++) {
    scanf("%d %d %d %d %d %d %d %d", &x1, &y1, &x2, &y2, &x3, &y3, &x4, &y4);
    a1 = y1 - y2;
    b1 = x2 - x1;
    c1 = x1 * y2 - y1 * x2;
    a2 = y3 - y4;
    b2 = x4 - x3;
    c2 = x3 * y4 - y3 * x4;



    if (a1*b2 == a2 * b1) {
      if ((x3 - x1)*(y2 - y1) == (y3 - y1) * (x2 - x1))
        printf("LINE\n");
      else
        printf("NONE\n");
    }
    else {
      x = (b1 * c2 - b2 * c1) / (a1 * b2 - a2 * b1);
      y = (c1 * a2 - c2 * a1) / (a1 * b2 - a2 * b1);

      printf("POINT %.2lf %.2lf\n", x + EPS, y + EPS);
    }
  }
  printf("END OF OUTPUT\n");

  return 0;
}

// run time for following version: 0.010s, replace line 39 to 44
int main_v1() {
  // ... ...
  if (a1*b2 == a2 * b1) {
    if (x1 * (y2 - y3) + x2 * (y3 - y1) + x3 * a1)
      printf("NONE\n");
    else
      printf("LINE\n");
  }
  // ... ... 
}
