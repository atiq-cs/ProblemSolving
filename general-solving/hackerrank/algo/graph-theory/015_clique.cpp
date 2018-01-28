/***************************************************************************
* Title : Clique
* URL   : https://www.hackerrank.com/challenges/clique/problem
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(.)
* Status: TLE
* Notes : First version
*   I have adapted the equation from,
    https://en.wikipedia.org/wiki/Tur%C3%A1n_graph
*   to understand, self-explanatory code.
*
* github solutions refs
* https://github.com/haotian-wu/Hackerrank_solutions/blob/master/
*  GraphTheory/clique.cpp
* https://github.com/zjsxzy/HackerRank/blob/master/Algorithms/Graph%20Theory/
*  Clique/main.cpp
* Dicussion has some good hints,
*   https://www.hackerrank.com/challenges/clique/forum
* meta  : tag-graph-theory, tag-clique, tag-cruise-automation, tag-coding-test
***************************************************************************/
#include <cmath>
#include <vector>
#include <iostream>
using namespace std;

int getCliqueSize(int n, int m) {
  if (m >= (n * (n - 1) / 2))
    return n;
  int e = 0;
  int p_e = 0;
  int k = 1;
  // size 2 is min
  for (; e <= m; k++) {
    int c_quotient = ceil((float)n / (float)k);
    int f_quotient = floor((float)n / (float)k);
    p_e = e;
    e = (n*n - (n%k) * c_quotient * c_quotient - (k - n % k) * f_quotient * f_quotient) / 2;
  }
  return k - 1;
}

int main() {
  int T;
  cin >> T;
  while (T--) {
    int N, M;
    cin >> N >> M;
    cout << getCliqueSize(N, M) << endl;
  }
  return 0;
}
