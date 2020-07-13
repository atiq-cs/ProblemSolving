/***************************************************************************************************
* Title : Roman Roulette
* URL   : https://uva.onlinejudge.org/external/1/p130.pdf
* Status: Accepted
* Author: Atiq Rahman
* Notes : Simplicity is wise here..
* ref   : https://www.spoj.com/problems/CLSLDR/
* meta  : tag-implementation
***************************************************************************************************/
#include <cstdio>
#include <vector>
using namespace std;

vector<int> person(100);

// input: 130_in.txt
int main() {
  int josephus_execute(int n, int k, int initPos);
  int survivor, n, k, init;

  while (scanf("%d %d", &n, &k) && (n || k)) {
    for (init = 0; init < n; init++) {
      survivor = josephus_execute(n, k, init);
      if (survivor == 1) {
        printf("%d\n", init + 1);
        break;
      }
    }
  }
  return 0;
}

// josephus style execution simulation
int josephus_execute(int n, int k, int initPos) {
  int i, no_S, curPos, buryPos;

  person.clear();
  for (i = 0; i < n; i++)
    person.push_back(i + 1);

  no_S = n;
  curPos = (initPos + k - 1) % no_S;

  for (i = 0; i < n - 1; i++) {
    person.erase(person.begin() + curPos);
    no_S--;

    buryPos = (curPos + k - 1) % no_S;

    person.insert(person.begin() + curPos, person[buryPos]);
    if (buryPos >= curPos)
      buryPos++;
    person.erase(person.begin() + buryPos);
    curPos = buryPos % no_S;
  }
  return person[0];
}
