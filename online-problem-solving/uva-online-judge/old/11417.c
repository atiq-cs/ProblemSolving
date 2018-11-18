/***************************************************************************************************
* Title : 
* URL   : 11417
* Notes : 
* meta  : tag-math, tag-uva-easy
***************************************************************************************************/
#include <stdio.h>

int find_gcd(int a, int b) {
  int tmp;
  while (a) {
    tmp = a;
    a = b % a;
    b = tmp;
  }
  return b;
}

int GCD[502] = {0, 0};

int main () {
  int i,j;
  const int limit = 501;
  int n;

  for (i=2; i<limit; i++) {
    GCD[i] = GCD[i-1];

    for (j=1; j < i; j++)
        GCD[i] += find_gcd(i,j);
  }

  while( scanf("%d", &n) && n )
    printf("%d\n", GCD[n]);

  return 0;
}
