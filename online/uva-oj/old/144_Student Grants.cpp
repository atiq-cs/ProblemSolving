/***************************************************************************************************
* ref   : for special cases and inputs,
*   https://uva.onlinejudge.org/board/search.php?keywords=144&start=15
* meta  : tag-implementation, tag-lang-c, tag-uva-easy
***************************************************************************************************/
#include <cstdio>
#include <vector>
#include <iostream>
using namespace std;

int main () {
  int n, k, i, cur, amount, ns, extra;

  while (scanf("%d %d", &n, &k) && (n || k)) {
    vector <int> student(n);
    vector <int> getID(n);

    for (i=0; i<n; i++) {
      student[i] = 0;
      getID[i] = i+1;
    }

    cur = 0;
    amount = 1;
    ns = n;

    while (true) {
      if (student[cur] + amount>= 40) {
        extra = student[cur] + amount - 40;
        printf("%3d", getID[cur]);
        student.erase(student.begin()+cur);
        getID.erase(getID.begin()+cur);

        ns --;
        cur--;

        while (extra && ns) {
          cur++;
          cur = cur % ns;

          if (student[cur] + extra>= 40) {
            extra = student[cur] + extra - 40;
            printf("%3d", getID[cur]);
            student.erase(student.begin()+cur);
            getID.erase(getID.begin()+cur);

            ns --;
            cur--;
          }
          else {
            student[cur] += extra;
            extra = 0;
          }
        }
      }
      else
        student[cur] += amount;

      if (ns == 0)
        break;

      cur = cur + 1;
      cur = cur % ns;

      amount++;
      if (amount == k+1)
        amount = 1;
    }

    putchar('\n');
  }
  
  return 0;
}
