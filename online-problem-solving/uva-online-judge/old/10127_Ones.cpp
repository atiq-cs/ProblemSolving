/***********************************************************
  Author:          Atiqur Rahman
  Problem Name:    Ones
  Problem ID:      UVA 10127
  Judge status:     Accepted

***********************************************************/

#include <cstdio>
#include <queue>
using namespace std;

int main () {
  freopen("10127_in.txt", "r", stdin);

  int n, nDigits;
  //long long
  int num;

  while (scanf("%d", &n) != EOF) {
    num = 0;
    nDigits = 0;
    
     do {
      nDigits++;
      num *= 10;
      num ++;
      num = num % n;
     } while (num);
    printf("%d\n", nDigits);
  }

  return 0;
}