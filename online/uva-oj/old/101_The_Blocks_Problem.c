/***************************************************************************************************
* Title : The Blocks Problem
* Notes : Implementation of linked list could be best solution, I am kinda simulating linked list
*   here
*   To avoid Presentation Error, there is no space before the single-digit numbers: check the below
*   output
* meta  : tag-ds-linked-list
***************************************************************************************************/
#include<stdio.h>
#include<stdlib.h>
#include<string.h>

char cmd[20],tmp[2],op,tp;
short i,No_Blocks,a,b,length,j,td,tm,block[25][25],freq[25],add[25],*p;


void transfer(int ta, int tb) {
  while (block[ta][i] >= 0)
  {
    block[tb][freq[tb]++] = block[ta][i];
    td = block[ta][i];
    add[td] = tb;
    block[ta][i] = -1;
    freq[ta]--;
    i++;
  }
}

void transferx(int x)
{
  for (j = i + 1; block[x][j] >= 0; j++) {
    tm = block[x][j];
    td = freq[tm]++;

    block[tm][td] = tm;
    add[tm] = tm;

    block[x][j] = -1;
    freq[x]--;
  }
}

int main() {
  short ta, tb;

  while (scanf("%hd", &No_Blocks) != EOF) {
    for (i = 0; i < No_Blocks; i++) {
      add[i] = i;
      freq[i] = 1;

      for (j = 0; j < No_Blocks; j++)
        if (j == 0)
          block[i][j] = i;
        else
          block[i][j] = -1;
      }

    getchar();

    while (gets(cmd) && cmd[0] != 'q') {
      tmp[0] = cmd[5];

      if (cmd[6] != ' ') {
        tmp[1] = cmd[6];
        op = cmd[9];
      }
      else {
        tmp[1] = NULL;
        op = cmd[8];
      }

      a = atoi(tmp);
      length = strlen(cmd);

      if (cmd[length - 2] != ' ') {
        tmp[0] = cmd[length - 2];
        tmp[1] = cmd[length - 1];
      }
      else {
        tmp[0] = cmd[length - 1];
        tmp[1] = NULL;
      }
      b = atoi(tmp);
      tp = cmd[0];

      if (tp == 'm' && op == 'n') {
        ta = add[a]; tb = add[b];
        if (ta != tb)
        {
          for (i = 0; block[ta][i] >= 0; i++)
            if (a == block[ta][i])
              break;
          transfer(ta);

          for (i = 0; block[tb][i] >= 0; i++)
            if (b == block[tb][i])
              break;
          transfer(tb);

          block[tb][freq[tb]++] = block[ta][--freq[ta]];
          add[a] = tb;
          block[ta][freq[ta]] = -1;
        }
      }
      else if (tp == 'm' && op == 'v') {
        ta = add[a]; tb = add[b];

        if (ta != tb) {
          for (i = 0; block[ta][i] >= 0; i++)
            if (a == block[ta][i])
              break;

          transfer(ta);
          block[tb][freq[tb]++] = block[ta][--freq[ta]];
          add[a] = tb;
          block[ta][freq[ta]] = -1;
        }
      }
      else if (tp == 'p' && op == 'n') {
        ta = add[a]; tb = add[b];

        if (ta != tb) {
          for (i = 0; block[tb][i] >= 0; i++)
            if (b == block[tb][i])
              break;

          transfer(tb);

          for (i = 0; block[ta][i] >= 0; i++)
            if (a == block[ta][i])
              break;
          transfer(ta, tb);
        }
      }
      else if (tp == 'p' && op == 'v') {
        ta = add[a];
        tb = add[b];

        if (ta != tb) {
          for (i = 0; block[ta][i] >= 0; i++)
            if (a == block[ta][i])
              break;
          transfer(ta, tb);
        }
      }
    }

    for (i = 0; i < No_Blocks; i++) {
      printf("%hd:", i);
      for (j = 0; j < freq[i]; j++)
        printf(" %hd", block[i][j]);

      printf("\n");
    }
  }

  return 0;
}
