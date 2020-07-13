/***************************************************************************************************
* Title : Lotto
* Status: Accepted
* Notes : Selecting combinations and printing them in order
* meta  : tag-permutation, tag-lang-c
***************************************************************************************************/
#include<stdio.h>

int main() {
  int i, n, arr[14], res[7], j, k, l, m, o, x, per = 1;

  while (scanf("%d", &n) && n) {
    for (i = 0; i < n; i++)
      scanf("%d", &arr[i]);

    if (per)
      per = 0;
    else
      putchar('\n');

    for (i = 0; i < n; i++) {
      res[0] = arr[i];
      for (j = i + 1; j < n; j++) {
        res[1] = arr[j];

        for (k = j + 1; k < n; k++) {
          res[2] = arr[k];
          for (l = k + 1; l < n; l++) {
            res[3] = arr[l];
            for (m = l + 1; m < n; m++) {
              res[4] = arr[m];
              for (o = m + 1; o < n; o++) {
                res[5] = arr[o];
                for (x = 0; x < 6; x++) {
                  if (x)
                    putchar(' ');
                  printf("%d", res[x]);
                }
                putchar('\n');
              }

            }
          }
        }
      }
    }
  }

  return 0;
}
