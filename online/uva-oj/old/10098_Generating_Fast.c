/***************************************************************************************************
* Date  : 2007-07-23
* rel   : 146
* meta  : tag-next-permutation, tag-permutation, tag-uva-easy
***************************************************************************************************/
#include<iostream>
#include<algorithm>
using namespace std;

int main() {
  short n, len, i, j;
  char str[12], tmp;

  cin >> n;
  while (n--) {
    cin >> str;

    for (len = 0; str[len]; len++);

    for (i = 0; i<len - 1; i++)
      for (j = i + 1; j<len; j++)
        if (str[i]>str[j]) {
          tmp = str[i];
          str[i] = str[j];
          str[j] = tmp;
        }

    cout << str << endl;
    while (next_permutation(str, str + len))
      cout << str << endl;
    cout << endl;
  }
  return 0;
}
