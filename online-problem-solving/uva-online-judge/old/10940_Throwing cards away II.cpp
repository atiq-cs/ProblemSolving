/*******************************************************
*    Problem Name:      Throwing cards away II
*    Problem ID:        10940
*    Occassion:        Offline Solving
*
*    Algorithm:        
*    Special Case:      
*    Judge Status:      
*    Author:          Atiq Rahman
*    Notes:          Simplicity of the solution,
                easy problem, easy thinking
*******************************************************/
//#include <iostream>
#include <cstdio>
//#include <cmath>
//#include <cstring>
//#include <new>
//#include <vector>
//#include <queue>
//#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
//#define  INF 2147483648
//#define EPS 1e-8
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
    if (m%2)  // number of integers is odd
      cutFromFirst = true;
    else
      end = end - interval;
  }
  interval = interval * 2;
  return true;
}

int main() {
  //freopen("10940_in.txt", "r", stdin);
  //freopen("10940_out.txt", "w", stdout);

  int n;

  while(scanf("%d", &n) && n) {
    start = 1;
    end = n;
    interval = 1;
    cutFromFirst = true;
    //printf("input: %d\n===========================================\n", n);
    while (update_cut()) {
      /*printf("Current deck:\n");
      for (int i = start; i<=end; i+= interval)
        printf("%d\n", i);
      putchar('\n');*/
    }
    //printf("output: %d, %d\n----------------------------------------\n\n", start, end);
    printf("%d\n", start);
  }

  return 0;
}

/*
    memset(arrayName, 255, )  
    cout.setf (ios::fixed, ios::floatfield);
    cout.setf(ios::showpoint);
    cout<<setprecision(2)<<sum_c + eps<<endl;

*/
