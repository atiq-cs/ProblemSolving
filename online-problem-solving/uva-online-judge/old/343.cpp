/*******************************************************
*    Problem Name:  What Base Is This?
*    Problem ID:      343
*    Occassion:      Offline Solving
*
*    Algorithm:      All possible combinations
*    Special Case:      Minimum base =2
*    Judge Status:    Accepted
*    Author:        Atiqur Rahman
*******************************************************/
#include <cctype>
#include <cstdio>
//#include <cmath>
#include <cstring>
//#include <new>
//#include <vector>
//#include <queue>
//#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
//#define  INF 2147483648
//#define EPS 1e-8
using namespace std;

int main() {
  bool f;  
  char str1[400], str2[400];
  int len1, len2, i, aBase, bBase;
  short num1[400], num2[400], maxA, maxB;
  long long asc, p, a, b;

  while (scanf("%s %s", str1, str2) != EOF) {
    // convert strings
    len1 = strlen(str1);
    maxA = 1;
    for (i=0; i<len1; i++) {
      if (isdigit(str1[i]))
        asc = str1[i] - 48;
      else if (isupper(str1[i]))
        asc = str1[i] - 55;
      else if (islower(str1[i]))
        asc = str1[i] - 87;
      num1[len1-i-1] = asc;
      if (maxA < asc)
        maxA = asc;
    }
    
    // debug
/*    for (i=len1-1; i>=0; i--)
      printf("%d\n", num1[i]);*/

    len2 = strlen(str2);
    maxB = 1;
    for (i=0; i<len2; i++) {
      if (isdigit(str2[i]))
        asc = str2[i] - 48;
      else if (isupper(str2[i]))
        asc = str2[i] - 55;
      else if (islower(str2[i]))
        asc = str2[i] - 87;
      num2[len2-i-1] = asc;
      
      if (maxB < asc)
        maxB = asc;
    }
    // debug
/*    for (i=len2-1; i>=0; i--)
      printf("%d\n", num2[i]);*/
      
    f = false;
    // check for each base between 1 and 36 inclusive
    for (aBase=maxA+1, f=false; aBase<37; aBase++) {
      // calculate first number in current base
      a = 0;
      for (i=0, p=1; i<len1; i++, p*=aBase)
        a += num1[i] * p;

      for (bBase=maxB+1; bBase<37; bBase++) {
        b = 0;
        for (i=0, p=1; i<len2; i++, p*=bBase)
          b += num2[i] * p;
          
        if (a==b) {
          printf("%s (base %d) = %s (base %d)\n", str1, aBase, str2, bBase);
          f = true;
          break;
        }
      }
      
      if (f)
        break;
    }
    if (f== false)
      printf("%s is not equal to %s in any base 2..36\n", str1, str2);
  }
  return 0;
}
