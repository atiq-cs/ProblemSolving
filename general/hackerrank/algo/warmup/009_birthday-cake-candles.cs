/***************************************************************************************************
* Title : Birthday Cake Candles
* URL   : https://www.hackerrank.com/challenges/birthday-cake-candles
* Date  : 2017-08-24
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes :
* meta  : tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
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
