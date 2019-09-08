/***************************************************************************************************
* Title : 
* URL   : 374
* Status: Accepted
* Notes : 
* meta  : tag-big-mod, tag-math
***************************************************************************************************/
#include <cstdio>
#include <iostream>
using namespace std;

long long res;

long long calculateMod(long long n, long long p, long long m) {
  if (p == 1)
    return (n%m);
  else if (p % 2)
    return (calculateMod(n, p - 1, m) * (n%m)) % m;
  else {
    res = calculateMod(n, p / 2, m) % m;
    return ((res*res) % m);
  }
}


int main() {
  long long B, P, M, R;

  while (scanf("%lld %lld %lld", &B, &P, &M) == 3) {
    if (P == 0)
      R = 1 % M;
    else
      R = calculateMod(B, P, M);

    printf("%lld\n", R);
  }
  return 0;
}
