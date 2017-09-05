/***************************************************************************
* Title       : Birthday Cake Candles
* URL         : https://www.hackerrank.com/challenges/birthday-cake-candles
* Occasion    : Codeforces Round #191 (Div. 2)
* Date        : Aug 24 2017
* Domain      : algorithms/warmup
* Complexity  : O(n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Contest Editorial
* meta        : tag-easy
***************************************************************************/
using System;

class Solution {
  static int birthdayCakeCandles(int n, int[] ar) {
    int maxHeight = 0;
    int freq = 0;
    for (int i=0; i<ar.Length; i++) {
      if (maxHeight < ar[i]) {
        maxHeight = ar[i];
        freq = 1;
      }
      else if (maxHeight == ar[i])
        freq++;
    }
    return freq;
  }

  static void Main(String[] args) {
    int n = Convert.ToInt32(Console.ReadLine());
    string[] ar_temp = Console.ReadLine().Split(' ');
    int[] ar = Array.ConvertAll(ar_temp,Int32.Parse);
    int result = birthdayCakeCandles(n, ar);
    Console.WriteLine(result);
  }
}
