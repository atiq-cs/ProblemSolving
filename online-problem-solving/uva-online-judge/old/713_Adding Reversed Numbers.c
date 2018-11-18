/***************************************************************************************************
* Title : Adding Reversed Numbers
* meta  : tag-big-integer, tag-string
***************************************************************************************************/
#include<iostream>
#include<cstring>
#include<cstdio>
using namespace std;

int main() {
  short n, i, ln1, ln2, j, maxln, a, b, add, carry, pos, f;
  char num1[202], num2[202], result[205];

  scanf("%hd", &n);
  for (i = 0; i < n; i++) {
    cin >> num1 >> num2;
    ln1 = strlen(num1) - 1;
    ln2 = strlen(num2) - 1;

    maxln = ln1 > ln2 ? ln1+1 : ln2+1;
    carry = 0; f = 0; pos = 0;

    for (j = 0; j < maxln; j++) {
      if (j <= ln1)
        a = num1[j] - '0';
      else
        a = 0;

      if (j <= ln2)
        b = num2[j] - '0';
      else
        b = 0;

      add = a + b + carry;
      if (add > 9) {
        carry = 1;
        add -= 10;
      }
      else
        carry = 0;

      if (add)
        f = 1;

      if (f)
        result[pos++] = add + '0';
    }

    if (carry)
      result[pos++] = carry + '0';

    result[pos] = NULL;
    cout << result << endl;
  }

  return 0;
}
