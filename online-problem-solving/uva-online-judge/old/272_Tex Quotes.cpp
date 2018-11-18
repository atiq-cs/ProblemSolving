/***************************************************************************************************
* Title : 
* URL   : 272
* Status: Accepted
* Notes : 
* meta  : tag-string, tag-lang-c
***************************************************************************************************/
#include <iostream>
using namespace std;

int main() {
  char c;
  bool f = false;

  while ((c = getchar()) != EOF) {
    if (!f && c == '"') {
      cout.put('`');
      cout.put('`');
      f = true;
    }
    else if (f && c == '\"') {
      cout.put('\'');
      cout.put('\'');
      f = false;
    }
    else
      cout.put(c);
  }
  return 0;
}
