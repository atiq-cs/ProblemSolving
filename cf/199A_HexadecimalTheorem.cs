/***************************************************************************
* Title : Hexadecimal's theorem
* URL   : http://codeforces.com/problemset/problem/199/A
* Contst: Codeforces Round #125 (Div. 2)
* Date  : 2018-05-26
* Author: Atiq Rahman
* Comp  : O(m), O(1), m = # of Fibo in n
* Status: Accepted
* Notes : f4 = f3 + f2, to give 3 numbers we write in following way,
*   f4 = f3 + f1 + f0
*   test-case for 0 and 1 figured out after getting wrong answer.
* meta  : tag-fibonacci, tag-algo-dp, tag-easy
***************************************************************************/
using System;

public class FiboUtil {
  public void ShowMatchingFiboTriplet(int n) {
    int fibA = 0;   // 0
    int fibB = 1;   // 1
    int fibC = 1;   // 2
    int fibD = 2;   // 3
    int fibE = 3;   // 4
    for (int i = 3; fibE < n; i++) {
      int temp = fibE; fibE += fibD; fibA = fibB; fibB = fibC;
      fibC = fibD; fibD = temp;
    }
    Console.WriteLine("{0} {1} {2}", fibA, n<2?fibA:fibB, n==0?fibA:n==1?fibB:
      n==2?fibC:fibD);
  }
}

public class CFSolution {
  public static void Main() {
    FiboUtil demo = new FiboUtil();
    int n = int.Parse(Console.ReadLine());
    demo.ShowMatchingFiboTriplet(n);
  }
}

/*
Output conditions combined from,

if (n == 0)       // 0 0 0
  Console.WriteLine("{0} {1} {2}", fibA, fibA, fibA);
else if (n == 1)  // 0 0 1
  Console.WriteLine("{0} {1} {2}", fibA, fibA, fibB);
else if (n == 2)  // 0 1 1
  Console.WriteLine("{0} {1} {2}", fibA, fibB, fibC);
else
  Console.WriteLine("{0} {1} {2}", fibA, fibB, fibD);
*/
