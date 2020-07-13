/***************************************************************************************************
* Title : Appleman and Toastman
* URL   : https://codeforces.com/problemset/problem/461/A
* Occasn: Competitive programming, with Lewin Gan; 8VC Venture Cup 2016 - Final Round (Div. 1 Ed)
*   Contest#4 Group#ylgaGzHfaj
* Date  : 2018-11-13
* Comp  : O(n lg n), O(n)
* Status: Accepted
* Notes : Find maximum score possible
*   Optimal strategy is to get n (all) numbers first; then, take (n-1) numbers and the smallest
*   number in two different groups Gotta cast to bigger type. Example is at bottom.
*   
*   Before applying multiplication to handle large results:
*   Must cast to long in this line to handle large numbers,
*     sum += (i+2) * (long) A[i];
*   (this got caught by some large input test-case)
* meta  : tag-algo-greedy, tag-algo-sort, tag-easy
***************************************************************************************************/
using System;

public class Series {
  int[] A;

  public void TakeInput() {
    int.Parse(Console.ReadLine());
    A = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
  }

  public long GetSum() {
    Array.Sort(A);
    long sum = 0;
    for (int i=0; i < A.Length; i++)
      sum += (i+2) * (long) A[i];
    return sum - A[A.Length-1];
  }
}

public class CFSolution {
  private static void Main() {
    Series demo = new Series();
    demo.TakeInput();
    Console.WriteLine(demo.GetSum());
  }
}

/*Draft,
3 1 5
+9 = 5 + 3 + 1
+8 = 5 + 3 & +1 separately
+5 = 5 & +3 separately

5*3 + 3 * 3 + 1 * 2
= 15 + 9 + 2
= 26

5 * 4 + 3 * 3 + 1*2 - 5 = 26

1 2 3 4 5
then,
5..1
5..2 + 1
5..3 + 2
5..4 + 3
5 + 4

5 * 5 + 4 * 5 + 3*4 + 2*3 + 1*2

try for 2,
3 4
4 * 3 + 3 * 2  = 21
if (n==2) sum -= a[n-2]
return 21-4
*/
