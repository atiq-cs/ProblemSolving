/***************************************************************************************************
* Date  : 2007-07-02
* meta  : tag-math, tag-big-integer, tag-lang-c
***************************************************************************************************/
#include<stdio.h>

int main() {
  int n, a, t, i, sq, st[1000], ind, h, md, ts;

  scanf("%d", &n);
  for (ts = 0; ts<n; ts++) {
    scanf("%d", &a);

    printf("Case #%d: %d is ", ts + 1, a);
    h = 1;
    ind = 1;
    st[0] = a;

    while (1) {
      for (i = 1; i<ind - 1; i++)
        if (st[i] == a) {
          h = 0;
          break;
        }

      if (!h)
        break;

      sq = st[ind - 1];
      t = 0;

      while (sq) {
        md = sq % 10;
        t += md * md;
        sq /= 10;
      }

      if (t == 1) {
        h = 1;
        break;
      }

      st[ind++] = t;
    }

    if (h)
      printf("a Happy number.\n");
    else
      printf("an Unhappy number.\n");
  }

  return 0;
}
