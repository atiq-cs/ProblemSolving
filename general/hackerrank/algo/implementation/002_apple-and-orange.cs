/***************************************************************************************************
* Title : Apple and Orange
* URL   : https://www.hackerrank.com/challenges/apple-and-orange
* Date  : 2017-09-19
* Comp  : O(n+m)
* Author: Atiq Rahman
* Status: Accepted
* Notes :
* meta  : tag-math, tag-implementation, tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
  static void Main(String[] args) {
    string[] tokens_s = Console.ReadLine().Split(' ');
    int s = Convert.ToInt32(tokens_s[0]);
    int t = Convert.ToInt32(tokens_s[1]);
    tokens_s = Console.ReadLine().Split(' ');
    int a = Convert.ToInt32(tokens_s[0]);
    int b = Convert.ToInt32(tokens_s[1]);
    Console.ReadLine();
    //int m = Convert.ToInt32(tokens_m[0]);
    //int n = Convert.ToInt32(tokens_m[1]);
    tokens_s = Console.ReadLine().Split(' ');
    int[] apple = Array.ConvertAll(tokens_s,Int32.Parse);
    tokens_s = Console.ReadLine().Split(' ');
    int[] orange = Array.ConvertAll(tokens_s,Int32.Parse);
    
    // computation here
    int apple_count = 0, orange_count = 0;
    foreach( int d in apple)   // check apples
      if (a + d >= s && a + d <= t) // check inside the range
        apple_count++;
    foreach( int d in orange)  // check oranges
      if (b + d >= s && b + d <= t)
        orange_count++;
    Console.WriteLine(apple_count + "\r\n" + orange_count);    
  }
}
