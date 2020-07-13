/***************************************************************************************************
* Title : Fibonacci Freeze
* URL   : http://uva.onlinejudge.org/external/5/495.html
* Comp  :
* Status: Accepted (time 0.029)
* Notes : 
* Ack   : Md Abdul Kader(http://dal.cs.utep.edu/members/mkader/) for BigInteger Class
* meta  : tag-algo-dp, tag-big-integer
***************************************************************************************************/
#include <cstdio>
#include <cstring>
using namespace std;

// ref: 'ds/BigInt.cpp'
class BigInt;

int main() {
  int i, n;

  BigInt num[5001];
  num[0] = BigInt("0");
  num[1] = BigInt("1");

  for (i = 2; i < 5001; i++)
    num[i] = num[i - 1] + num[i - 2];

  while (scanf("%d", &n) != EOF) {
    printf("The Fibonacci number for %d is ", n);
    num[n].show();
  }

  return 0;
}
