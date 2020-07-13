/***************************************************************************
* Title : Clique
* URL   : https://www.hackerrank.com/challenges/clique/problem
* Date  : 2018-01
* Author: Atiq Rahman
* Comp  : O(.)
* Status: Accepted
* Notes : Second version using binary search
*   I have adapted the equation from,
*    https://en.wikipedia.org/wiki/Tur%C3%A1n_graph
*
*   First version is at,
*   https://github.com/atiq-cs/Problem-Solving/blob/7317f697a7/general-solving/
*    hackerrank/algo/graph-theory/015_clique.cpp
*   (correct address by removing CRLF and additional chars)
*
* github solutions refs
* https://github.com/haotian-wu/Hackerrank_solutions/blob/master/
*  GraphTheory/clique.cpp
* https://github.com/zjsxzy/HackerRank/blob/master/Algorithms/Graph%20Theory/
*  Clique/main.cpp
* Dicussion has some good hints,
*   https://www.hackerrank.com/challenges/clique/forum
* meta  : tag-graph, tag-clique, tag-company-cruise-automation, tag-coding-test
***************************************************************************/
#include <cmath>
#include <vector>
#include <iostream>
using namespace std;

int getCliqueSize(int n, int k) {
  int c_quotient = ceil((float)n / (float)k);
  int f_quotient = floor((float)n / (float)k);
  int e = (n*n - (n%k) * c_quotient * c_quotient - (k - n % k) * f_quotient *
    f_quotient) / 2;
  return e;
}

int main() {
  int T;
  cin >> T;

  while (T--) {
    int N, M;
    cin >> N >> M;
    int lo = 1, hi = N + 1, ret = -1;
    while (lo + 1 < hi) {
      int mid = lo + (hi - lo) / 2;
      if (getCliqueSize(N, mid) < M)
        lo = mid;
      else
        hi = mid;
    }
    cout << hi << endl;
  }
  return 0;
}
