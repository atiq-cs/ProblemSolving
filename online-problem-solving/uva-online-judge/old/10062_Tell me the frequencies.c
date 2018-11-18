/***************************************************************************************************
* URL   : 10062
* Status: Accepted
* Notes : 
* meta  : tag-string, tag-hash-table, tag-uva-easy
***************************************************************************************************/
#include<stdio.h>
#include<string.h>

void main() {
  int freq[128], i, j, highest_freq, len, tag1 = 0, tag2;
  char arr[1001];

  while (gets(arr)) {
    if (tag1 == 0)
      tag1 = 1;
    else
      printf("\n");
    len = strlen(arr);

    for (i = 0; i < 128; i++)
      freq[i] = 0;

    highest_freq = 0;
    for (i = 0; i < len; i++) {
      freq[arr[i]]++;
      if (highest_freq < freq[arr[i]])
        highest_freq = freq[arr[i]];
    }

    for (i = 1; i <= highest_freq; i++)
      for (j = 127; j >= 32; j--)
        if (freq[j] == i)
          printf("%d %d\n", j, i);
  }
}
