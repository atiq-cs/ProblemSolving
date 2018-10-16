/***************************************************************************
* Title       : e-Coins
* URL         : https://open.kattis.com/problems/ecoins
* Date        : Sep 30 2017
* Complexity  : O(S*S*m)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Look at cs file more info
* Same        : https://uva.onlinejudge.org/external/103/p10306.pdf
* Ref         : https://www.topcoder.com/community/data-science/data-science-
*               tutorials/dynamic-programming-from-novice-to-advanced/
*               http://swapcoder.blogspot.com/2013/05/blog-post.html
*               states the same things as I did
* meta        : tag-judge-kattis, tag-algo-dp
***************************************************************************/
#include<cstdio>

int INF = 0x7FFFFFFF;

class ECoin {
public:
  int CValue;    // conventional value
  int ITValue;   // InfoTechnological value
  // to avoid warning at constructor of class 'CoinChange'
  ECoin() { CValue = 0; ITValue = 0; }
  ECoin(int c, int i) { CValue = c; ITValue = i; }
};

class CoinChange {
private:
  int minCC[301][301];
  ECoin eCoins[41];
  int S;
  int m;

public:
  CoinChange(int lm, int s) {
    S = s;
    m = lm;
    for (int i = 0; i <= S; i++)
      for (int j = 0; j <= S; j++)
        minCC[i][j] = INF;
    minCC[0][0] = 0;
  }
  int GetMinCoinsCount() {
    for (int i = 0; i <= S; i++)
      for (int j = 0; j <= S; j++)
        for (int k = 0; k < m; k++)
          UpdateMinCoinChange(i, j, k);
    
    int minRes = minCC[0][0] = INF;
    for (int i = 0; i <= S; i++)
      for (int j = 0; j <= S; j++)
        if (i * i + j * j == S * S && minCC[i][j] < minRes)
          minRes = minCC[i][j];
    return minRes;
  }

  void UpdateMinCoinChange(int i, int j, int  k) {
    int prevCIndex = i - eCoins[k].CValue;
    int prevITIndex = j - eCoins[k].ITValue;
    if (i >= eCoins[k].CValue && j >= eCoins[k].ITValue && minCC[prevCIndex]
      [prevITIndex] != INF && minCC[i][j] > minCC[prevCIndex][prevITIndex]+1) {
      minCC[i][j] = minCC[prevCIndex][prevITIndex] + 1;
    }
  }

  // Take problem specific input
  void TakeInput() {
    for (int i = 0; i < m; i++) {
      int a, b;
      scanf("%d %d", &a, &b);
      eCoins[i] = ECoin(a, b);
    }
  }

};

int main() {
  int T;
  scanf("%d", &T);
    
  while (T-- > 0) {
    int m;
    int S;
    scanf("%d %d", &m, &S);
      
    CoinChange minCoinChangeDemo(m, S);
    minCoinChangeDemo.TakeInput();
    int res = minCoinChangeDemo.GetMinCoinsCount();
    if (res == INF)
    puts("not possible");
    else
      printf("%d\n", res);
  }
  return 0;
}
