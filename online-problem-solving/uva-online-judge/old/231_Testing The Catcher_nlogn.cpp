/*
  Author:  Atiq
  Status:  Accepted by UVA
  Update: this has moved to
  "online-problem-solving/uva-online-judge/231_TestingTheCatcher_lis_algo2.cpp"
*/
#include <cstdio>
#include <iostream>
using namespace std;

#define INF  2147483647

int BSearch(int item, int start, int end);
int getLenLIS(int n);

int LIS[1000005];
int data[1000005];

int main () {
  int sq=1, d, top;
  bool prev;

  freopen("231_in.txt","r",stdin);
  
  prev = true;
  
  while (true) {
    scanf("%d",&d);
    if (prev && (d == -1))
      break;
    else if (prev) {
      // beginning of an input set
      prev = false;
      top = 0;
      data[top++] = d;
    }
    else if (d == -1){
      if (sq>1) putchar('\n');
      // end of an input set
      LIS[top] = -INF;
      prev = true;
    //  printf("top: %d\n", top);
      printf("Test #%d:\n  maximum possible interceptions: %d\n",sq++, getLenLIS(top));

      /*
Test #1:
  maximum possible interceptions: 6
Test #1:
  maximum possible interceptions: 4

      */
    
    }
    else {
      LIS[top] = -INF;
      data[top++] = d;
    }
  }
  return 0;
}

int getLenLIS(int n) {
    int i, j, k, Limit=0;

    for (LIS[0]=INF,i=0; i<n; i++) {
      j = BSearch(data[i], 0, Limit) + 1;
      if (LIS[j] == -INF)
        Limit = j;


      if (LIS[j] < data[i]) {
        LIS[j] = data[i];
      //  printf("set lis[%d]: %d\n",j,LIS[j]);
      }
      else if (LIS[j] == data[i]) {
        for (k=j;;k++) {
          if (LIS[j] != LIS[k]) {
            LIS[k] = data[i];
            Limit = Limit>k?Limit:k;
            break;
          }
        }
      }
      /*printf("Step: %d\tj: %d for %d & limit: %d\n",i,j,data[i], Limit);
      for (k=1; k<=Limit; k++) printf(" %d",LIS[k]); putchar('\n');*/
    }
/*    for (i=1; i<=Limit; i++) printf(" %d",LIS[i]); putchar('\n');*/
    return Limit;
}

/*
  Redesigned Binary Search to work with descending ordered data
*/
int BSearch(int item, int start, int end) {
  int mid = (start + end) / 2;
  //printf("start: %d, mid: %d and end: %d\n", start, mid, end);

  if (start > end)
    return end;
  else if (LIS[mid] > item)
    return BSearch(item, mid +1, end);
  else
    return BSearch(item, start, mid -1);
}
