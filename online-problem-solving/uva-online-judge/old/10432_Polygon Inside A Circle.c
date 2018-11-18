/***************************************************************************************************
* Title : Polygon inside a circle
* URL   : 10432
* meta  : tag-math
***************************************************************************************************/
#include<stdio.h>
#include<math.h>

int main() {
  double r, n, area;

  // Determining value of 2 * PI using cos
  const double PI2 = 4 * acos(0);
  while (scanf("%lf %lf", &r, &n) != EOF) {
    // The area of triangle is: 1/2 ab sinC and all math functions use radian values
    area = n * r * r * sin(PI2 / n) / 2;
    printf("%.3lf\n", area);
  }

  return 0;
}
