/*
  Easy problem solving practice
  For special cases and inputs:
    http://acm.uva.es/board/search.php?st=0&sk=t&sd=d&sid=60a80e5b754776f8b6d505c39346e2d0&keywords=144&start=15
*/

#include <cstdio>
#include <vector>
#include <iostream>
using namespace std;

int main () {
  int n, k, i, cur, amount, ns, extra;
  //bool usingExtras;

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
    //  printf("cur: %d students collection: %d amount: %d\n", cur, student[cur], amount);
      if (student[cur] + amount>= 40) {
        extra = student[cur] + amount - 40;
//        printf("Student(%d) %d exits.\n", cur, getID[cur]);
//        printf("cur: %d exits %3d", cur, getID[cur]);
        printf("%3d", getID[cur]);
        student.erase(student.begin()+cur);
        getID.erase(getID.begin()+cur);
        ns --;
        cur--;
        while (extra && ns) {
        //  printf("in extra cur: %d students collection: %d amount: %d ns: %d\n", cur, student[cur], amount, ns);
          cur++;
          cur = cur % ns;
          if (student[cur] + extra>= 40) {
            extra = student[cur] + extra - 40;
//            printf("cur: %d exits %3d", cur, getID[cur]);
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
      else {
        student[cur] = student[cur] + amount;
      }

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
