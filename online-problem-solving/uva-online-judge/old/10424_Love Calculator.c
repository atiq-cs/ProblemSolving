/***************************************************************************************************
* URL   : 10424
* Notes : limits, string etc I guess
* meta  : tag-math, tag-uva-easy, tag-lang-c
***************************************************************************************************/
#include<stdio.h>


void main() {
  char myn[26], lvn[26];
  short len, i, pm, plv;
  float mdp, pc, mdv;

  while (gets(myn)) {
    len = strlen(myn);
    pm = 0;

    for (i = 0; i < len; i++)
      if (isupper(myn[i]))
        pm += (float)myn[i] - 64;
      else if (islower(myn[i]))
        pm += (float)myn[i] - 96;

    mdp = 0;
    while (pm) {
      mdp += pm % 10;
      pm /= 10;
    }

    pm = mdp;
    mdp = 0;
    while (pm) {
      mdp += pm % 10;
      pm /= 10;
    }

    gets(lvn);
    len = strlen(lvn);

    plv = 0;
    for (i = 0; i < len; i++)
      if (isupper(lvn[i]))
        plv += (float)lvn[i] - 64;
      else if (islower(lvn[i]))
        plv += (float)lvn[i] - 96;

    mdv = 0;
    while (plv) {
      mdv += plv % 10;
      plv /= 10;
    }

    plv = mdv;
    mdv = 0;
    while (plv) {
      mdv += plv % 10;
      plv /= 10;
    }

    if (mdp > mdv)
      pc = mdv * 100 / mdp;
    else
      pc = mdp * 100 / mdv;

    printf("%.2f %\n", pc);
  }
}
