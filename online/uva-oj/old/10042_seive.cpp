/***************************************************************************************************
* Title : Smith Numbers
* URL   : 10042
* Date  : 2008-12-25
* Status: Accepted (0.730)
* Notes : Technique "If we divide a number with all its prime factors upto
*   square root of that number then if result still greater than one then the
*   result is also a prime number"
* meta  : tag-number-theory, tag-primality
***************************************************************************************************/
#include <cstdio>
#include <cmath>
#include <cstdlib>
#include <bitset>
#include <cassert>
using namespace std;

long long prime_array[100000] = {2}, top = 1;

unsigned sum_num_digits(long long n) {
  unsigned int sum = 0;
  while (n) {
    sum += n % 10;
    n = n / 10;

  }
  return sum;
}

int main() {
  unsigned i, sumf, sumN, t, T, fr, check_prime;
  long long en, n;

  // generate_prime (sieve) is at 'algo/num-theory/prime.cpp'
  generate_prime(50000);

  // second version of this function had:
  // generate_prime (dp) is at 'algo/num-theory/prime.cpp'
  // call with 40000 i.e., generate_prime(40000);

  scanf("%u", &T);

  for (t = 0; t < T; t++) {
    scanf("%lld", &n);

    for (n++;; n++) {
      sumN = sum_num_digits(n);
      sumf = 0;
      en = n;
      check_prime = 0;

      for (i = 0; prime_array[i] <= sqrt(n); i++) {
        fr = 0;
        while (en % prime_array[i] == 0) {
          fr++;
          en /= prime_array[i];
        }

        if (fr) {
          sumf += fr * sum_num_digits(prime_array[i]);
          check_prime += fr;
        }
      }

      if (en > 1) {
        check_prime++;
        sumf += sum_num_digits(en);
      }

      if (check_prime > 1 && sumf == sumN) {
        printf("%lld\n", n);
        break;
      }
    }
  }

  return 0;
}

// DP Prime Generation Version
#include <cstdio>
#include <cmath>
#include <cstdlib>
using namespace std;

long long prime_array[40000] = { 2 };

// main() is same as the latest one above; just check dp prime note
