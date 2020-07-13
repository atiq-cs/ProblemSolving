/***************************************************************************************************
* Title : Count the factors
* Status: CE
* Notes : Used DP Prime factor generation
*   Using DP I generated all the prime numbers upto the square root of maximum limit(1000000), then
*   I used for loop to determine which are the prime factors of given number. The problem was that
*   the prime factor greater than square root I could not handle (In this perspective I would have
*   to use more efficient prime generator algorithm like bitwise sieve). I simply divided by every
*   prime factors the given number
*   if the result is prime and not 1 then I added 1.Thus comes result
* meta  : tag-number-theory, tag-primality
***************************************************************************************************/

#include<iostream>
#include<cmath>
using namespace std;

// There are only 168 prime numbers within 1000
const int limit = 1000, size = 172;
int pr[size] = { 2 };

int gen_prime_dp() {
  int i = 1, j, en;

  for (j = 3; i <= size; j += 2) {
    for (en = 0; en < i; en++)
      if (!(j%pr[en]))
        break;

    if (en == i)
      pr[i++] = j;
  }

  return i;
}

int main() {
  int i;
  int n, sq, no_factor;
  bool flag;

  while (cin >> n && n) {
    flag = true;
    sq = (int)sqrt(n);
    no_factor = 0;
    cout << n;

    for (i = 0; pr[i] <= sq;)
      if (!(n%pr[i])) {
        if (flag) {
          no_factor++;
          flag = false;
        }
        n /= pr[i];
      }
      else {
        i++;
        flag = true;
      }

    sq = (int) sqrt(n);
    for (flag = true, i = 0; pr[i] <= sq; i++)
      if (!(n%pr[i])) {
        flag = false;
        break;
      }


    if (flag && n != 1)
      no_factor++;
    cout << " : " << no_factor << endl;
 
  }

  return 0;
}
