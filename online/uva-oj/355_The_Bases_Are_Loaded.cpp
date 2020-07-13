/***************************************************************************
* Title : The Bases Are Loaded
* URL   : https://uva.onlinejudge.org/external/3/355.pdf
* Date  : 2011-08-08
* Author: Atiq Rahman
* Comp  : 
* Status: Accepted
* Notes : in code comment
* meta  : tag-base-conversion, tag-math, tag-string
***************************************************************************/
#include <cstdio>
#include <cmath>
#include <cstring>
#include <vector>
#include <queue>
#include <map>
#include <algorithm>
#include <iomanip>  //for cout formatting
using namespace std;

// should be defined as a greater value than max base value
#define INVALID_CHAR    31

int CharToInt(char ch) {
  if (ch >= '0' && ch <= '9')
    return (ch - '0');
  if (ch >= 'A' && ch <= 'F')
    return (ch - 'A' + 10);
  if (ch >= 'a' && ch <= 'z')
    return (ch - 'a' + 10);
  return INVALID_CHAR;
}

bool IsNumberInBase(const char *num, int base) {
  int len = strlen(num);
  for (int i = 0; i<len; i++)
    if (CharToInt(num[i]) >= base)
      return false;
  return true;
}

char IntToChar(int n) {
  // expects valid of n, it is not checked here
  if (n < 10)
    return (n + '0');
  if (n < 16)
    return (n + 'A' - 10);
  // error case, should not come here
  return '0';
}

long long strtoull(const char *str, int base) {
  long long dcVal = 0;
  int len = strlen(str);
  for (int i = 0; i<len; i++)
    dcVal = dcVal * base + CharToInt(str[i]);
  return dcVal;
}

class BaseConvert {
private:
  char pNum[15];   // Previous number
  char cNum[70];   // Convert to number
  unsigned int pBase;      // Previous base
  unsigned int cBase;      // Convert to base
  long long decValue;
public:
  BaseConvert();
  void Convert();
  void Run();
};

BaseConvert::BaseConvert() {
  // Initiaze used variables
  pBase = 0;
  cBase = 0;
  pNum[0] = '\0';
  cNum[0] = '\0';
}

void BaseConvert::Convert() {
  long long num = decValue;
  char cNumRev[128] = "";
  int revIndex = 127;
  cNumRev[revIndex] = '\0';

  // do while loop works for number 0
  do {
    cNumRev[--revIndex] = IntToChar((int)(num%cBase));
    //printf("index %d: char: %c\n", revIndex, cNumRev[revIndex]);
    num = num / cBase;
  } while (num);
  //printf("got reverse: %s\n", &cNumRev[revIndex]);
  strcpy(cNum, &cNumRev[revIndex]);
}

void BaseConvert::Run() {
  // Take Input
  while (scanf("%d %d %s", &pBase, &cBase, pNum) == 3) {
    // Check invalid
    // RemoveLeadingZeroes();
    if (IsNumberInBase(pNum, pBase) == false) {
      printf("%s is an illegal base %d number\n", pNum, pBase);
      continue;
    }
    // Convert number to decimal
    decValue = strtoull(pNum, pBase);
    //decValue = strtoull("10000", 2);
    //decValue = 1000000000000000;
    //printf("Decimal value: %lld\n", decValue);
    // input is decValue
    // Result is put in cNum
    Convert();
    printf("%s base %d = %s base %d\n", pNum, pBase, cNum, cBase);
  }
}

int main() {
  BaseConvert bcObj;
  bcObj.Run();
  return 0;
}
