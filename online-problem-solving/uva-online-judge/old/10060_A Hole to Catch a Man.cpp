#include <cstdio>
#include <cmath>
using namespace std;

#define EPS 1e-6

int main () {
  freopen("10060_in.txt", "r", stdin);

  int N, i, nP, res;
  double thick, x[2000], y[2000], area, sheetVol, manholeVol, mrad, mth;
  
  while (scanf("%d", &N) && N) {
    sheetVol = 0.0;
    while (N--) {
      nP = 0;
      scanf("%lf", &thick);
      scanf("%lf %lf", &x[nP], &y[nP]);
      nP++;
      
      while (scanf("%lf %lf", &x[nP], &y[nP]) && !(fabs(x[nP]-x[0])<EPS && (fabs(y[nP] - y[0]))<EPS))
        nP++;

      area = 0.0;
      for (i=1; i<nP-1; i++) {
        area += ((x[0]* y[i] + x[i] * y[i+1] + x[i+1] * y[0]) - (y[0]* x[i] + y[i] * x[i+1] + y[i+1] * x[0])) * 0.5;
      //  printf("area: %lf\n", area);
      }
    //  printf("areaLast: %lf\n", area);
      sheetVol += fabs(area) * thick;
    }
    scanf("%lf %lf", &mrad, &mth);
    manholeVol = 2 * acos(0.0) * mrad * mrad * mth;
  //  sheetVol = fabs(sheetVol);
  //  printf("man vol: %lf sheet vol: %lf\n", manholeVol, sheetVol);
    res = (int)(sheetVol / manholeVol);
    printf("%d\n", res);
  }
  
  return 0;
}
