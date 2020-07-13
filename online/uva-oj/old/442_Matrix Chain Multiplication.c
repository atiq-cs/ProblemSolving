/***************************************************************************************************
* Title : Matrix Chain Multiplication
* Status: Accepted
* Notes :
* meta  : tag-algo-mcm, tag-dp-mcm, tag-lang-c
***************************************************************************************************/
#include<stdio.h>


struct Matrix_info
{
  int row, col;
} Matrix[26], Modified_Matrix[1000];

void main() {
  int i, j, Length, Error_code, No_Matrix;
  unsigned long rs;
  char t, c, exp[1000];

  scanf("%d", &No_Matrix);
  scanf("%c", &t);

  for (i = 0; i < No_Matrix; i++) {
    scanf("%c", &t);
    scanf("%d %d", &Matrix[t - 65].row, &Matrix[t - 65].col);
    scanf("%c", &t);
  }

  while (gets(exp)) {
    Length = strlen(exp);
    j = 0; rs = 0; Error_code = 0;

    for (i = 0; i < Length; i++) {
      c = exp[i];

      if (isupper(c)) {
        c -= 65;
        Modified_Matrix[j++].row = Matrix[c].row;
        Modified_Matrix[j - 1].col = Matrix[c].col;
      }
      else if (c == ')') {
        if (Modified_Matrix[j - 2].col == Modified_Matrix[j - 1].row)
          rs += Modified_Matrix[j - 2].row * Modified_Matrix[j - 1].col *
          Modified_Matrix[j - 1].row;
        else {
          Error_code = 1;
          break;
        }

        j--;

        Modified_Matrix[j - 1].col = Modified_Matrix[j].col;
      }
    }

    if (Error_code)
      printf("error\n");
    else {
      if (j == 2)
        rs += Modified_Matrix[0].row * Modified_Matrix[0].col * Modified_Matrix[1].row;
      printf("%lu\n", rs);
    }
  }
}
