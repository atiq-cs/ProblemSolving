/***************************************************************************************************
* Title : Super long sums
* Status: Accepted
* Notes : Consider cases like?
*   4
*   4 5
*   5 5
*   3 2
*   2 3
*  Such test-cases are not possible since in problem statement it is clearly stated,
*  "Each of the two given integers is not less than 1, and the length of their sum does not exceed
*  M."
*  shouldn't it be Wrong Answer?
* meta  : tag-math
***************************************************************************************************/
#include<stdio.h>

int main() {
  int i, j, n, m, sum, a[1000000][2];

  scanf("%d", &n);
  for (i = 0; i < n; i++) {
    scanf("%d", &m);
    for (j = 0; j < m; j++)
      scanf("%d %d", &a[j][0], &a[j][1]);

    for (j = m - 1; j >= 0; j--) {
      sum = a[j][0] + a[j][1];

      if (sum >= 10) {
        a[j][0] = sum - 10;
        a[j-1][0]++;
      }
      else
        a[j][0] = sum;
    }
    for (j = 0; j < m; j++)
      printf("%d", a[j][0]);
    printf("\n");

    if (i < n - 1)
      printf("\n");
  }

  return 0;
}
