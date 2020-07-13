/***************************************************************************
* Title : Ingenuous Cubrency
* URL   : https://uva.onlinejudge.org/external/111/11137.pdf
* Date  : 2018-02-19
* Author: Atiq Rahman
* Comp  : O(N * M)
* Status: Accepted
* Notes : Classic coin change DP
* meta  : tag-coin-change, tag-algo-dp
***************************************************************************/
#include <iostream>
#include <vector>

class DP {
private:
  const int LIMIT;
  std::vector<long long> numWays;
  std::vector<int> coins;

public:
  DP() : LIMIT(9999), numWays(LIMIT + 1, 0) {}

  void Precompute() {
    numWays[0] = 1;

    for (int j = 1; j*j*j < LIMIT; j++)
      coins.push_back(j*j*j);

    for (int i = 0; i < (int)coins.size(); i++)
      for (int j = coins[i]; j <= LIMIT; j++)
        numWays[j] += numWays[j - coins[i]];
  }

  long long GetNumWays(int i) {
    return numWays[i];
  }
};


int main() {
  int T;

  DP demo;
  demo.Precompute();
  while (std::cin >> T)
    std::cout << demo.GetNumWays(T) << std::endl;

  return 0;
}
