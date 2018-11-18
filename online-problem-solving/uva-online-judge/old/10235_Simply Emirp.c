/***************************************************************************************************
* URL   : 10235
* Status: Accepted
* Notes : naive prime generation
* meta  : tag-number-theory, tag-primality
***************************************************************************************************/
#include<iostream>
#include<cmath>
using namespace std;


int main() {
  int i, n, sq, a, b;


  while (cin >> n) {
    sq = sqrt((double)n);

    for (i = 2; i <= sq; i++)
      if (!(n%i))
        break;

    if (i == sq + 1) {
      a = n;
      b = 0;

      while (a) {
        b = b * 10 + a % 10;
        a /= 10;
      }

      if (n != b) {
        sq = sqrt((double)b);

        for (i = 2; i <= sq; i++)
          if (!(b%i))
            break;
      }

      if (i == sq + 1 && n != b)
        cout << n << " is emirp." << endl;
      else
        cout << n << " is prime." << endl;
    }
    else
      cout << n << " is not prime." << endl;

  }

  return 0;
}
