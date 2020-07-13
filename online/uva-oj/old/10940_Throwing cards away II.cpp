/***************************************************************************************************
* Title : Throwing cards away II
* URL   : 10940
* Notes : Think simple
* meta  : tag-algo-dp
***************************************************************************************************/
#include <cstdio>
using namespace std;

int start, end, cutFromFirst, interval;

bool update_cut() {
  int m = (end - start) / interval + 1;

  if (m==1)
    return false;

  if (cutFromFirst) {
    start = start + interval;

    if (m%2) {  // number of integers is odd
      end = end - interval;
      cutFromFirst = false;
    }
  }
  else {
    if (m % 2)  // number of integers is odd
      cutFromFirst = true;
    else
      end = end - interval;
  }

  interval = interval * 2;
  return true;
}

int main() {
  int n;

  while(scanf("%d", &n) && n) {
    start = 1;
    end = n;
    interval = 1;
    cutFromFirst = true;
    while (update_cut());
    printf("%d\n", start);
  }

  return 0;
}
