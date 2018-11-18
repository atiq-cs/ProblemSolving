/***************************************************************************************************
* Title : Greedy Gift Givers
* Notes : 
*   Given some people with their amount to distribute among friends evenly after keeping aside some
*   money; we are to determine how much more everyone gives than receives.
* meta  : tag-string, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>
#include<string.h>

int main() {
  int np, i, j, k, amount, ppbal[13], nopp, ebal, nw = 0;
  char ppname[10][13], whoname[13];

  while (scanf("%d", &np) != EOF) {
    if (nw)
      putchar('\n');
    else
      nw = 1;

    for (i = 0; i < np; i++) {
      scanf("%s", ppname[i]);
      ppbal[i] = 0;
    }

    for (i = 0; i < np; i++) {
      scanf("%s %d %d", whoname, &amount, &nopp);

      for (k = 0; k < np; k++)
        if (!strcmp(ppname[k], whoname))
          break;;

      if (nopp) {
        ppbal[k] += amount % nopp - amount;
        ebal = amount / nopp;
        for (j = 0; j < nopp; j++) {
          scanf("%s", whoname);

          for (k = 0; k < np; k++)
            if (!strcmp(ppname[k], whoname))
              break;;

          ppbal[k] += ebal;
        }
      }
    }

    for (i = 0; i < np; i++)
      printf("%s %d\n", ppname[i], ppbal[i]);
  }
  return 0;
}
