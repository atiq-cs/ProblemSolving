/***************************************************************************
* Title : Almost Prime
* URL   : http://codeforces.com/problemset/problem/26/A
* Contst: Offline
* Date  : 2018-04-27
* Author: Atiq Rahman
* Comp  : Check Prime Generation Methods
* Status: Accepted
* Notes : ToDo: analyze complexity of Sieve
*
*   Applications of this problem:
*   Test Prime Number Generatation algorithm up to a small range (<=3000)
*   
*   With this problem following Prime Generation Algos tested,
*   - Dynamic Programming Approach for generating primes
*   - Sieve of Eratosthenes
*   
*   related: 'uva-online-judge/old/10699_Count the factors.cpp'
* meta  : tag-linked-list, tag-easy
***************************************************************************/
using System;
using System.Collections.Generic;

public class PrimeUtil {
  // The access level for class members and struct members, including nested
  // classes and structs, is private by default.
  // ref: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/
  // classes-and-structs/access-modifiers
  List<int> primes;
  System.Collections.BitArray isPrime;
  int n;

  // Divide each candidate number (starting from 6) by prime numbers to find
  // divisors. Keep dividing the number with the divisor/factor. Do it twice
  // and if the number comes down to one after those divisions we got an
  // almost prime
  public int FindAlmostPrimes()
  {
    int count = 0;

    for (int num = 6; num <= n; num++) {
      int firstPrimeDivisorIndex = GetPrimeFactor(num);
      if (firstPrimeDivisorIndex == -1)
        continue;
      // divide the number as long as it is divisible by factor
      int dNum = DivideDown(num, primes[firstPrimeDivisorIndex]);
      int secondPrimeDivisorIndex = GetPrimeFactor(dNum, firstPrimeDivisorIndex
        + 1);
      if (secondPrimeDivisorIndex == -1)
        continue;
      if (DivideDown(dNum, primes[secondPrimeDivisorIndex]) == 1)
        count++;
    }
    return count;
  }

  // start from the index after the previous prime factor's index
  private int GetPrimeFactor(int num, int startIndex=0) {
    if (num == 1)
      return -1;
    // find prime divisor/factor
    for (int i= startIndex; primes[i] <= num && i<primes.Count; i++)
      if (num % primes[i] == 0)
        return i;
    return -1;
  }

  private int DivideDown(int num, int factor) {
    while (num % factor == 0)
      num /= factor;
    return num;
  }

  // Dynamic Programming for generating primes
  // O(N*C)
  public void GeneratePrimesDP()
  {
    primes = new List<int>(new int[] { 2 });
    for (int j = 3; j <= n; j += 2) {
      int pi = 1;   // index inside the prime number collection
      for (; pi < primes.Count; pi++)
        if (j % primes[pi] == 0)
          break;
      if (pi == primes.Count)
        primes.Add(j);
    }
  }

  // Sieve ref: https://en.wikipedia.org/wiki/Sieve_of_Eratosthenes
  public void GeneratePrimesSieve()
  {
    isPrime = new System.Collections.BitArray(n + 1, true);
    for (int i = 3; i * i <= n; i+=2)
      if (isPrime.Get(i))
        for (int j = i * i; j <= n; j += i)
          isPrime.Set(j, false);

    primes = new List<int>(new int[] { 2 });
    for (int i = 3; i <= n; i+=2)
      if (isPrime.Get(i))
        primes.Add(i);
  }

  public void Input()
  {
    n = int.Parse(Console.ReadLine());
  }
}

public class CFSolution {
  public static void Main() {
    PrimeUtil primeDemo = new PrimeUtil();
    primeDemo.Input();
    primeDemo.GeneratePrimesSieve();
    Console.WriteLine(primeDemo.FindAlmostPrimes());
  }
}
/*
Draft,
two distinct prime divisors
6, 10, 12, 18

can I apply something like seive
1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
2, 3, 5, 7, 11, 13, 17

2 ->
4, 6, 10, 14, 22, 34, 38, 46

3 ->
15, 21, 33, 39, 57, 69, 87

5->
35

for (i=0; i < prime.Count; i++) {
  for (j=prime[i+1]; j<n; j*=prime[i]) {
    count++;
  }
}

i=0;
prime 2
j=3
*/
