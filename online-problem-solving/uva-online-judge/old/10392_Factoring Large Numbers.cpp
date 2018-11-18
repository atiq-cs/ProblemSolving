/***************************************************************************************************
* URL   : 10260
* Status: Accepted
* Notes : Trick Visual Studio C++ supported online judge only, for gcc it is not required,
*   #ifndef ONLINE_JUDGE
*   typedef __int64 LL;
*   //#define lld %I64
*   #else if
*   typedef long long LL;
*   //#define lld I64d
*   #endif
*
* meta  : tag-string, tag-hash-table, tag-uva-easy
***************************************************************************************************/
#include<iostream>
#include<cstdio>

using namespace std;

const int limit = 1000000;
LL prime[limit] = {2};
int top = 1;
bool isPrime[limit];

// Seive_generate_prime is at 'algo\num-theory\prime.cpp'

int main() {
  Seive_generate_prime(limit);
  
  LL n;
  LL factor[100];
  bool f= true;

  while (scanf("%I64d",&n) && n >= 0) {
    int i;
    int top = 0;

    if (f)
      f = false;
    else
      cout<<endl;

    for (i = 0; prime[i] * prime[i] <= n; i++) {
      if (n % prime[i] == 0)
        factor[top++] = prime[i];

      while (n % prime[i] == 0)
        n /= prime[i];
    }

    if (n > 1)
      factor[top++] = n;

    for (i = 0; i<top; i++)
      printf("    %I64d\n",factor[i]);
  }

  return 0;
}
