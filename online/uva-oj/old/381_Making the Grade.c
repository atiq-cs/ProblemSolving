/***************************************************************************************************
* Title : Making the Grade
* Notes : be careful to match the output format and some calculations floating etc
* meta  : tag-implementation, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>
#include<math.h>


struct test {
  int mk[10], bns, abt;
  float avg, grd;
} std[31];


void main() {
  int n, s, t, i, j, k, min;
  short f;
  float mn, blw, sm, abv, sd, vgs;

  scanf("%d", &n);
  printf("MAKING THE GRADE OUTPUT\n");

  for (i = 0; i < n; i++) {
    scanf("%d", &s);
    scanf("%d", &t);

    for (j = 0; j < s; j++) {
      for (k = 0; k < t; k++)
        scanf("%d", &std[j].mk[k]);

      scanf("%d", &std[j].bns);
      scanf("%d", &std[j].abt);
    }

    vgs = 0;
    for (j = 0; j < s; j++) {
      sm = 0;
      f = 0;

      if (t > 2) {
        for (min = 0, k = 0; k < t; k++)
          if (std[j].mk[min] > std[j].mk[k]) {
            min = k;
            f = 1;
          }
          else if (std[j].mk[min] < std[j].mk[k])
            f = 1;

        if (f)
          std[j].mk[min] = 0;
      }

      for (k = 0; k < t; k++)
        sm += std[j].mk[k];

      if (f)
        std[j].avg = sm / (float)(t - 1);
      else
        std[j].avg = sm / (float)t;

      vgs += std[j].avg;
    }

    mn = vgs / (float)s;

    sd = 0;
    for (j = 0; j < s; j++)
      sd += (std[j].avg - mn)*(std[j].avg - mn);

    sd /= (float)s;
    sd = sqrt(sd);
    if (sd < 1) sd = 1;
    abv = sd + mn;
    blw = mn - sd;
    sm = 0;
    for (j = 0; j < s; j++) {
      std[j].bns /= 2;
      std[j].avg = std[j].avg + std[j].bns * 3;
      if (std[j].avg >= abv)
        std[j].grd = 4.0;
      else if (std[j].avg >= mn && std[j].avg < abv)
        std[j].grd = 3.0;
      else if (std[j].avg < mn && std[j].avg >= blw)
        std[j].grd = 2.0;
      else std[j].grd = 1.0;
      f = std[j].abt / 4;
      std[j].grd -= (float)f;

      if (!std[j].abt)
        std[j].grd++;
      if (std[j].grd < 0)
        std[j].grd = 0;
      else if (std[j].grd > 4)
        std[j].grd = 4;

      sm += std[j].grd;
    }

    vgs = sm / (float) s;
    printf("%0.1f\n", vgs);
  }

  printf("END OF OUTPUT\n");
}
