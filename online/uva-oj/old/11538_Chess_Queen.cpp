/***************************************************************************************************
* Title : Chess Queen
* URL   : 11538
* Notes : BUET NCPC 2008; solved long after the contest time
* meta  : tag-math
***************************************************************************************************/
#include <cstdio>
using namespace std;

int main() {
  long long M, N, sum, mulF, mulI;
  
  while (scanf("%lld %lld", &M, &N)) {
    mulF = (n-1) * 4;
    mulI = (n-1) * 3;
    sum = 0;
    if (n%2) {
      while (mulF>0) {
        sum += mulF * mulI;
        mulI += 2;
        mulF -= 8;
      }
      sum += mulI;
    }
    else {
      while (mulF>-5) {
        sum += mulF * mulI;
        mulI += 2;
        mulF -= 8;
      }
    }
    printf("%lld", sum);
  }  
  return 0;
}

// draft
// This version is probably not solved one
int main_v0() {
  long long res, m, n, tmp;

  while (scanf("%lld %lld", &m, &n) && (m || n)) {
    if (m < n) {
      tmp = m;
      m = n;
      n = tmp;
    }
    res = 2 * (2 * n * (n * n - 1) / 3 + (m - n - 1) * n * (n - 1)) + m * n * (m + n - 2);
    printf("%lld\n", res);
  }
  return 0;
}
