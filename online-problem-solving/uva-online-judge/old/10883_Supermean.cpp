/***************************************************************************************************
* Title : Supermean
* URL   : 10883
* Author: Atiq Rahman
* Notes : combinatories, handling big numbers, logarithm etc
* meta  : tag-combinatorics, tag-math, tag-order-stat
***************************************************************************************************/
#include <cstdio>
#include <cmath>
using namespace std;

long double comb;

long double combinatory_value (int i, int n, double a) {
  int isneg, j;

  if (i==0)
    comb = 0.0;

  // if n is even and i upto mid and if n is odd and upto mid
  else if ((n%2 && i<=n/2) || ((!(n%2)) && i<n/2))
    comb = comb  + log (n - i) - log(i);
  else if ((n%2 && i>n/2) || (!(n%2)) && i>n/2) {
    j = n - i;
  //  if n is even and i is greater then mid(first mid) + 1 and if n is odd and i greater
    comb = comb  + log(j) - log (n - j);
  }

  long double coef;
  isneg = 1;
  if (a<0) {
    coef = comb + log (-a);
    isneg = -1;
  }
  else
    coef = comb + log (a);

  long double res = coef - (n-1) * log(2.0);
  return (isneg * exp(res));
}

int main() {
  long double sum;
  int i,j,t, n;
  double a;

  scanf("%d", &t);
  for (i=1; i<=t; i++) {
    scanf("%d", &n);

    comb = log(1.0);
    sum = 0.0;
    for (j=0; j<n; j++) {
      scanf("%lf", &a);
      sum += combinatory_value(j, n, a);
    }
  }
  
  return 0;
}
