/***************************************************************************************************
* Title : 
* URL   : 497
* Comp  : O (n^2)
* Notes : todo, move LIS to algo-core
* rel   : 481
* meta  : tag-dp-lis
***************************************************************************************************/
#include <iostream>
#include <cstdlib>
using namespace std;

int pre[10000],m[10000];

void print(int index) {
  if (index == -1)
    return;
  print(pre[index]);
  cout << m[index] << endl;
}

int main() {
  int i, j;
  int a[10000];
  char num[20];

  int tmp = 0, n = 0, t;
  scanf("%d\n", &t);

  while (t--) {
    if (tmp)
      cout << endl;
    tmp++;

    i = 0;
    while (gets(num)) {
      if (num[0] == 0)
        break;
      m[i] = atoi(num);
      i++;
    }

    n = i;
    for (i = 0; i < n; i++) {
      a[i] = 1;
      pre[i] = -1;
    }

    for (i = 0; i < n; i++)
      for (j = i + 1; j < n; j++)
        if ((m[i] < m[j]) && (a[j] < a[i] + 1)) {
          a[j] = a[i] + 1;
          pre[j] = i;
        }


    for (j = 0, i = 1; i < n; i++)
      if (a[i] > a[j])
        j = i;


    cout << "Max hits: " << a[j] << endl;

    print(j);
  }

  return 0;
}
