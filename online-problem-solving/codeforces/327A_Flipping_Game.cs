/***************************************************************************
* Title : Flipping Game
* URL   : http://codeforces.com/problemset/problem/327/A
* Occasn: Codeforces Round #191 (Div. 2)
* Date  : 2017-09-02
* Author: Atiq Rahman
* Comp  : O(n) 122ms, Space O(n)
* Status: Accepted
* Notes : According problem description, we are allowed to do single move:
*   choose i and j, in-between these all indices (inclusive) are flipped.
*   The goal of the game is that after exactly one move to obtain the maximum
*   number of ones.
*   
*   This problem might had also been presented in JS meetup,
*   Contest Editorial: http://codeforces.com/blog/entry/8274 provides
*    hints on two approaches: O(n^3) and O(n)
*   Unbeknownst to me, I have implemented the second appraoch.
*   
*   Also appeared in JS meetup in 2018, Q1
*    https://www.careercup.com/question?id=6262507668766720
* rel   : https://leetcode.com/problems/insert-interval
* meta  : tag-algo-dp
***************************************************************************/
using System;
using System.Collections.Generic;

public class BinaryBlock {
  // These List objects can be replaced with a List of KeyValuePair
  private List<bool> block_list;
  private List<int> freq;
  private int one_count;
  public BinaryBlock() {
    block_list = new List<bool>();
    freq = new List<int>();
    one_count = 0;
  }
  /*
  * Take input in a sequence of bits. We have the frequency of each bit in
  * another array named 'freq'.
  */
  public void TakeInput() {
    int n = int.Parse(Console.ReadLine());
    string[] tokens = Console.ReadLine().Split();

    bool bit, prev_bit=false;
    for (int i = 0; i < n; i++) {
      bit = uint.Parse(tokens[i]) == 1 ? true : false;
      if (bit)
        one_count++;
      // found a new bit block
      if (i == 0 || bit != prev_bit) {
        block_list.Add(bit);
        freq.Add(1);
      }
      else
        freq[freq.Count - 1]++;
      prev_bit = bit;
    }
  }

  /*
   * Baseline:
   *  Find the max of freq of bit 0.
   * Improvement 1:
   *  Take into consideration that number of 1 can be less in between two 0s.
   * DP Solution:
   *  Incrementally calculate based on preivously mentioned solutions
   */
  public int GetMaxNumOnes() {
    int max = 0;
    for (int i = 0; i < block_list.Count; i++) {
      if (i>1 && block_list[i-2] == false && block_list[i-1] == true && block_list[i] == false)
        if (freq[i - 2] > freq[i - 1])
          freq[i] += freq[i - 2] - freq[i - 1];

      if (block_list[i] == false)
        max = Math.Max(max, freq[i]);
    }
    if (max == 0) one_count--;
    return max+one_count;
  }
}

class CFSolution {
  static void Main(String[] args) {
    BinaryBlock Demo = new BinaryBlock();
    Demo.TakeInput();
    Console.WriteLine(Demo.GetMaxNumOnes());
  }
}

/* Alternative costly thoughts:
We are losing solutions when using wrong conditions. We could accumulate from
previous sum and could go toward better result..

Let's think simple DP,
Say, s[i] contains the max that can be done by flipping 

s[1][1] = bit[0]
s[1][2] = s[1][1] + s[2][2]
s[1][i] = s[1][i] + s[i][]
s[1][n] = ?

0 0 0

can,
 s[1][i] can be 
  s[1][i-1] + 1   if bit[i] can be made from 0 to 1 or it is a 1

for i=1 to n,
 s[1][n] = max(s[1][n], s[1][i] + s[i+1][n]);

it should take an n*n loop to find upto,
then just take the max..

s[1][1] = bits[1]? 0:1;
s[1][2] = 
s[i][j] = max all s[i][k] + s[k][j];

we need to find,
s[1][n]

for this we need all following values,
s[1][2]
s[1][3]
s[1][4]
...
s[1][n-1]

and..
s[2][n]
s[3][n]
s[4][n]
......
s[n][n]


s[1][1] = toggle of bit[0]
s[1][2] = s[1][1] + ?


0 0 0 0
0 1 0 0 1

[1][1] = 1
[1][2] = [1][1] + 1
[1][3] = [1][2] because previous bit is 0
*/
