/***************************************************************************************************
* Title : Prime Cuts
* Notes : find out the prime factors and print
* meta  : tag-number-theory, tag-primality, tag-lang-c
***************************************************************************************************/

#include<stdio.h>
#include<math.h>

void main() {
  int N, C, increment, limit, check, count_prime, start, end, prime[169];

  while ((scanf("%d %d", &N, &C)) != EOF) {
    printf("%d %d:", N, C);
    count_prime = 0;

    for (check = 1; check <= N; check++) {
      limit = sqrt(check);

      for (increment = 2; increment <= limit; increment++)
        if (! (check % increment))
          break;

      if (increment == limit + 1)
        prime[count_prime++] = check;
    }

    C *= 2;
    if (count_prime % 2)
      C--;

    start = (count_prime - C) / 2;
    end = count_prime - start;

    if (count_prime <= C) {
      end = count_prime;
      start = 0;
    }

    for (increment = start; increment < end; increment++)
      printf(" %d", prime[increment]);

    puts("\n");
  }
}
