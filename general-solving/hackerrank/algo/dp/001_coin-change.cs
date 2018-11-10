/***************************************************************************
* Title : The Coin Change Problem
* URL   : https://www.hackerrank.com/challenges/coin-change
* Date  : 2016-01-26
* Comp  : O(nm) Time
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
*   The goal is to find number of ways coins can sum up to n.
*   By trying the regular DP concept, I was able to
*   write the algo/solution that can compute number of ways
*   However, because the coin iteration loop was inner
*   it included solutions where order of coins mattered or
*   position of the coins mattered. To give an example,
*   consider 3 coins are given to make sum 4 like following,
*   
*   4 3
*   1 2 3
*   solutions are considered:
*   1 1 1 1
*   1 1 2
*   1 2 1
*   2 1 1
*   1 3
*   2 2
*   3 1
*   which gives us total ways = 7
*   
*   To include only the unique solutions all we need to do is put
*   the coin loop as outer
*   
*   Lessons:
*   sorting coins not necessary
*   
*   Initialization:
*   How many ways can we make 0?
*   1 (known and does not require further calculation)
*   How many ways can we make others?
*   Initialize with 0 and dynamically keep adding to find final value.
*   Therefore, initialization goes as follows,
*   Set count for making 0 to 1
*   And, all others to 0.
*   
*   some old draft text at bottom
*   
*   Refs:
*   This one uses 2D Array
*   https://en.wikipedia.org/wiki/Change-making_problem
*   Similarly,
*   http://www.algorithmist.com/index.php/Coin_Change
*   
* rel   : https://leetcode.com/problems/coin-change-2
* Ack   : Mak
* meta  : tag-algo-dp
***************************************************************************/
using System;

class CoinChange {
  int n;
  int m;
  int[] coins;
  public void Run() {
    // Take input
    string[] tokens = Console.ReadLine().Split(' ');
    n = Convert.ToInt32(tokens[0]);
    m = Convert.ToInt32(tokens[1]);

    coins = new int[m];
    tokens = Console.ReadLine().Split(' ');
    for (int i = 0; i < m; i++)
      coins[i] = Convert.ToInt32(tokens[i]);

    // Print Result
    Console.WriteLine(CountWays());
  }

  // compute number of ways
  long CountWays() {
    long[] w = new long[n+1];
    w[0] = 1;
    // set 0 from index 1 to n+1
    // https://msdn.microsoft.com/en-us/library/system.array.clear.aspx
    Array.Clear(w, 1, n);

    for (int i = 0; i < m; i++)
      for (int j = 1; j <= n; j++) {
        if (j >= coins[i])
          w[j] += w[j - coins[i]];
      }
    return w[n];
  }
}

class HK_Solution {
  static void Main(String[] args) {
    CoinChange Demo = new CoinChange();
    Demo.Run();
  }
}

/* Draft - 2016-12-21
1, 2, 3

cw[1] = 1
cw[2] = 1
cw[3] = 1

how many ways can we make 0?
1

how many ways can we make 1?
cw[1] + 1 coin = 1


how many ways can we make 2?
for each coin c_i
 cw[2] += c_i

how many ways can we make n?
for each coin c_i
 cw[n] += cw[n-c_i]

consider example,
{1, 2, 3} 
cw[0] = 1
cw[1] += cw[0] = 1
cw[2] += cw[1] = 1
cw[2] += cw[0] = 2
cw[3] += cw[2] = 2
cw[3] += cw[1] = 3
cw[3] += cw[0] = 4

{1, 1, 1}
{1, 2}
{3}

add 1
{1, 1}
{2}
add 2
{1}

3 3
1 2 3

tries the first coin,
1
3-1=2
cw[3] += cw[2]

first we try to make 1
cw[1] = 1

we try to make 2
cw[2] +=  cw[2-1] = cw[1] = 1
cw[2] +=  cw[2-2] = cw[0] = 2

we try to make 3
cw[3] +=  cw[3-1] = cw[2] = 2
cw[3] +=  cw[3-2] = cw[1] = 3

some how use

we wanna allow use of the same coin but not 
we wanna allow {1, 2} but not {2, 1}

or 1, 1, 2 but not 1, 2, 1
can use hashset for each number, complexity of comparison 

this set operations getting complex hashset won't work cuz we might have
duplicate values
*/
