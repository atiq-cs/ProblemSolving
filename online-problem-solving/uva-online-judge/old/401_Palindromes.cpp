/***************************************************************************************************
* URL   : https://uva.onlinejudge.org/external/4/401.pdf
* Date  : 2007-03-18
* Notes : handle 3 types of strings
* meta  : tag-string-palindrome
***************************************************************************************************/
#include<iostream>
#include<cstring>
#include<cstdio>
using namespace std;

int main() {
  char str[22], chr[22] = "AEHILJMOSTUVWXYZ12358", rev[22] = "A3HIJLMO2TUVWXY51SEZ8";
  short length, i, j, k, m, p;

  while (gets(str)) {
    m = 0;
    p = 0;
    length = strlen(str);

    for (i = 0, j = length - 1; i<length / 2; i++, j--) {
      if (str[i] != str[j]) {
        p = 1; break;
      }
    }

    for (i = 0, j = length - 1; !i || i<length / 2; i++, j--) {
      for (k = 0; k<22; k++) {
        if (str[i] == chr[k])
          break;
      }

      if ((length - 1)) {
        if (k == 22) {
          m = 1;
          break;
        }
        else if (str[j] != rev[k]) {
          m = 1;
          break;
        }
      }
      else if (k == 22)
        m = 1;
    }

    cout << str << " -- is ";
    if (!p)
        cout << (m?"a regular palindrome.":"a mirrored palindrome.") << endl << endl;
    else {
      if (!m)
        cout << "a mirrored string." << endl << endl;
      else
        cout << "not a palindrome." << endl << endl;
    }
  }
  return 0;
}
