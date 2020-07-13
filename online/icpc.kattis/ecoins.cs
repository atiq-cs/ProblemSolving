/***************************************************************************
* Title       : e-Coins
* URL         : https://open.kattis.com/problems/ecoins
* Occasion    : Swedish Championships 2001, 10x recruit test
* Date        : Sep 30 2017
* Complexity  : O(S*S*m)
* Author      : Atiq Rahman
* Status      : TLE (cpp conversion is accepted)
* Notes       : This problem defines a new type of coin called e-coin.
*               An e-coin's value is defined by its e-modulus which is computed
*               from its two counterparts:
*                1. conventional value (let's call it x)
*                2. infotechnnological value (call it y)
*                
*               If we use a few e-coins to make a target value first we have to
*               sum the counterparts individually.
*               Usually, i is the variable to make for each amount. And I use j
*               to point to different coins in the coins array. For each amount
*               we take the minimum between value at that point in min_dp array
*               or the value (adding 1) that comes from the previous value
*               (current_sum - coin[j]).
*               Now that we got x and y we use i and j to index them.
*               
*               A usual coin change problem would take O(S*m) complexity
*               However, this problem requires tracking of both x and y
*               separately. Therefore, minimum time I could do is O(S*S*m)
*               
*               Problem B of 10xRecruit Coding Challenge- 10xrecruit.kattis.com
* 
* A variation of Coin Change with e-coin Translation
*               This beautiful peace of code got TLE by the poor online judge
* Same        : https://uva.onlinejudge.org/external/103/p10306.pdf
* Ref         : https://www.topcoder.com/community/data-science/data-science-
*               tutorials/dynamic-programming-from-novice-to-advanced/
*               http://swapcoder.blogspot.com/2013/05/blog-post.html
*               states the same thing as I did
* meta        : tag-judge-kattis, tag-algo-dp
***************************************************************************/
using System;

public class ECoin {
  public int CValue;    // conventional value
  public int ITValue;   // InfoTechnological value
  public ECoin(int c, int i) { CValue = c; ITValue = i; }
}

class CoinChange {
  private int INF = int.MaxValue;
  private int[][] minCC;
  private ECoin[] eCoins;
  private int S;
  private int m;

  // initializations and allocations
  public CoinChange(int lm, int s) {
    S = s;
    m = lm;
    minCC = new int[S + 1][];
    for (int i = 0; i < S + 1; i++)
      minCC[i] = new int[S + 1];
    for (int i = 0; i <= S; i++)
      for (int j = 0; j <= S; j++)
        minCC[i][j] = INF;
    minCC[0][0] = 0;
    eCoins = new ECoin[m];
  }
  public string GetMinCoinsCount() {
    for (int i = 0; i <= S; i++)
      for (int j = 0; j <= S; j++)
        for (int k = 0; k < m; k++)
          UpdateMinCoinChange(i, j, k);
    
    int minRes = minCC[0][0] = INF;
    for (int i = 0; i <= S; i++)
      for (int j = 0; j <= S; j++)
        if (i * i + j * j == S * S && minCC[i][j] < minRes)
          minRes = minCC[i][j];
    return minRes==INF? "not possible" : minRes.ToString();
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
  public void TakeInput() {
    for (int i = 0; i < m; i++) {
      string[] tokens = Console.ReadLine().Split();
      eCoins[i] = new ECoin(int.Parse(tokens[0]), int.Parse(tokens[1]));
    }
  }
}

public class Solution {
  public static void Main() {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      int m = int.Parse(tokens[0]);
      int S = int.Parse(tokens[1]);
      CoinChange minCoinChangeDemo = new CoinChange(m, S);
      minCoinChangeDemo.TakeInput();
      // Ignore additional blank line.
      if (T != 0)
        Console.ReadLine();
      Console.WriteLine(minCoinChangeDemo.GetMinCoinsCount());
    }
  }
}
