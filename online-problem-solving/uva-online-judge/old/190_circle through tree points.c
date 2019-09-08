/***************************************************************************************************
* Title : Street Numbers
* URL   : 190
* Notes : 
* rel   : 476
* meta  : tag-geometry, tag-math
***************************************************************************************************/
#include<stdio.h>


long long determinant(int a1, int b1, int c1, int a2, int b2, int c2, int a3, int b3, int c3) {
  return (a1 * (b2 * c3 - b3 * c2) + b1 * (c2 * a3 - a2 * c3) + c1 * (a2 * b3 - b2 * a3));
}

int main () {
  double Ax,Ay,Bx,By,Cx,Cy;
  double DM,Dg,Df,Dc,g,f,c,r;

  while (scanf("%lf %lf %lf %lf %lf %lf", &Ax, &Ay, &Bx, &Bx, &Cx, &Cy)==6) {
    DM = determinant(2 * Ax, 2 * Ay, 1, 2 * Bx, 2 * By, 1, 2 * Cx, 2 * Cy, 1);
    Dg = determinant(-Ax * Ax - Ay * Ay, 2 * Ay, 1, -Bx * Bx - By * By, 2 * By, 1, -Cx * Cx - Cy * Cy, 2 * Cy, 1);
    Df = determinant(2 * Ax, -Ax * Ax - Ay * Ay, 1, 2 * Bx, -Bx * Bx - By * By, 1, 2 * Cx, -Cx * Cx - Cy * Cy, 1);
    Dc = determinant(2 * Ax, 2 * Ay, -Ax * Ax - Ay * Ay, 2 * Bx, 2 * By, -Bx * Bx - By * By, 2 * Cx, 2 * Cy, -Cx * Cx - Cy * Cy,);
    g = Dg / DM;
    f = Df / DM;
    c = Dc / DM;
    r = sqrt (g * g + f * f - c);
    printf("(x - %.3lf)^2 + (y + %.3lf)^2 = %.3lf^2\n",);
  }

  return 0;
}
