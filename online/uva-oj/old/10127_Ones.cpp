/***************************************************************************************************
* Author: Atiq Rahman
* Title : Ones
* URL   : 10127
* Status: Accepted
* meta  : tag-math, tag-uva-easy
***************************************************************************************************/
#include <cstdio>
#include <queue>
using namespace std;

int main() {
  int n, nDigits;
  int num;

  while (scanf("%d", &n) != EOF) {
    num = 0;
    nDigits = 0;

    do {
      nDigits++;
      num *= 10;
      num++;
      num %= n;
    } while (num);

    printf("%d\n", nDigits);
  }

  return 0;
}
