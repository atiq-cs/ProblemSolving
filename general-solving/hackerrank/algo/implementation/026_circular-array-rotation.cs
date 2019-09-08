/***************************************************************************************************
* Title : Circular Array Rotation
* URL   : https://www.hackerrank.com/challenges/circular-array-rotation
* Date  : 2016-12-20
* Notes : Linear swap
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : First, I tried without additional array but it does overwrite
*   some of the values. So, I allocated an additional array and
*   I did not bother with it since it is a warmup challenge
* meta  : tag-easy
***************************************************************************************************/
using System;

class HKSolution
{
  // perform circular rotation
  static void c_rotate(int[] a, int[] b, int n, int k) {
    for (int i=0; i<n; i++)
      b[(i+k)%n] = a[i];
      // or do this,
      // b[i] = a[(i-k)%n];
  }

  static void Main(String[] args) {
    string[] tokens_n = Console.ReadLine().Split(' ');
    int n = Convert.ToInt32(tokens_n[0]);
    int k = Convert.ToInt32(tokens_n[1]);
    int q = Convert.ToInt32(tokens_n[2]);
    string[] a_temp = Console.ReadLine().Split(' ');
    int[] a = Array.ConvertAll(a_temp,Int32.Parse);
    int[] b = new int[n];     // rotated array
    
    c_rotate(a, b, n, k);
    for(int a0 = 0; a0 < q; a0++) {
      int m = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine(b[m]);
    }
  }
}
