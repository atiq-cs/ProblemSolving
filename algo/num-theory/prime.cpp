/***************************************************************************
* Title : Prime number algos
* URL   :
* Date  :
* Comp  :
* Notes : Sieve of Eratosthenes (check Euler's Sieve)
*   Uses C++ assert
* meta  : tag-number-theory, tag-algo-core, tag-lang-cpp
***************************************************************************/

// Sieve
void generate_prime(long long n) {
  const int MAX_PRIME = 50000; // limit on size of n
  assert(n > 0 && n <= MAX_PRIME);

  // Construct bitset sieve of size MAX_PRIME + 1 containing all ones.
  // For convenience, we are not using positions 0 and 1 of sieve so
  // that bit i represents positive integer i.

  bitset < MAX_PRIME + 1 > sieve;
  sieve.set();

  // Apply the Sieve Method
  int prime = 2; // the next prime in sieve
  while (prime * prime <= n) {
    // cross out multiples of prime from sieve
    for (int mult = 2 * prime; mult <= n; mult += prime)
      sieve.reset(mult); // cross mult as non-prime

    // find next uncrossed number in sieve
    do
      prime++;
    while (!sieve.test(prime));

    prime_array[top++] = prime;
  }

  for (prime++; prime < n; prime++)
    if (sieve.test(prime))
      prime_array[top++] = prime;
}

// DP
void generate_prime_dp(long long n) {
  unsigned ind = 1, j;
  long long i;
  bool pf = 0;

  for (i = 3;; i++) {
    for (j = 0; j < ind && prime_array[j] <= sqrt(i); j++)
      if (!(i % prime_array[j])) {
        pf = 1;
        break;
      }

    if (!pf)
      prime_array[ind++] = i;
    else
      pf = 0;

    if (n < ind)
      break;
  }
}

// uva#10932
void Seive_generate_prime(int size) {
  memset(isPrime, 1, sizeof(bool) * size);

  int i, j;

  for (i = 3; i <= size; i += 2)
    if (isPrime[i] == true) {
      for (j = i * i; j > 0 && j <= size; j += 2 * i)
        isPrime[j] = false;

      prime[top++] = i;
    }
}
