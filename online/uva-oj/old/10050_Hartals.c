/***************************************************************************************************
* Title : Hartals
* Notes : Be aware of variable naming chaos..
* meta  : tag-math, tag-algo-dp
***************************************************************************************************/
#include<stdio.h>

void main() {
  unsigned Sum_Hartals, Test_Case, Mult_Result, Range, Party_Number, Hartal_Difference[102],
    Register[4000], i, j, k;

  scanf("%u", &Test_Case);

  for (i = 0; i < Test_Case; i++) {
    scanf("%u %u", &Range, &Party_Number);
    Sum_Hartals = 0;

    for (j = 1; j <= Range; j++)
      Register[j] = 0;

    for (j = 0; j < Party_Number; j++) {
      scanf("%u", &Hartal_Difference[j]);
      Mult_Result = Hartal_Difference[j];

      for (k = 1; Mult_Result <= Range; k++) {
        Mult_Result = k * Hartal_Difference[j];
        if ((Mult_Result % 7) && (Mult_Result % 7) != 6)
          Register[Mult_Result] = 1;
      }
    }

    for (j = 1; j <= Range; j++)
      Sum_Hartals += Register[j];

    printf("%u\n", Sum_Hartals);
  }
}
