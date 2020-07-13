/***************************************************************************
* Title : Find max number of threats
* URL   : https://www.hackerrank.com/contests/magic-lines-september-2015/challenges/playing-with-numbers-magic-lines
* Occasn: contest/magic-lines-september-2015
* Comp  : 
* Author: Atiq Rahman
* Status: Unsolved!
* Notes : Mathematical formulation
*   Discussions have some clue, I could not cover all corner cases
*   my lower bound
* meta  : tag-math
****************************************************************************/
#include <cmath>
#include <cstdio>
#include <vector>
#include <iostream>
#include <algorithm>
using namespace std;

typedef long long ll;

const int MAX_N = 510000;
int n, q;
ll a[MAX_N];
ll s[MAX_N];  // prefix sum

int main() {
  scanf("%d", &n);
  for (int i = 0; i < n; i++) {
    scanf("%lld", &a[i]);
  }
  sort(a, a + n);
  for (int i = 0; i < n; i++) {
    s[i + 1] = s[i] + a[i];
  }
  scanf("%d", &q);
  ll sum = 0;
  while (q--) {
    ll x;
    scanf("%lld", &x);
    sum += x;
    /* this failed!!
    int p = a[n-1]<0?n-1:a[0]>0?0:(int)(lower_bound(a, a+n, 0)-a);
    */
    int p = ? ? ? ;
    printf("%lld\n", -(p * sum + s[p]) + ((n - p) * sum + s[n] - s[p]));
  }
  return 0;
}
