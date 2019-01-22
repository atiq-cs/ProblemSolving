/***************************************************************************************************
* Title : Dreamoon and WiFi
* URL   : http://codeforces.com/problemset/problem/476/B
* Occasn: Codeforces Round #272 (Div. 2)
* Date  : 2017-09-13
* Comp  : O(2^q) 46ms, Space O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
*   comb is based on 'Basics/combination_binary.cs'
*   https://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo.
*   currentculture.aspx
*   https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-
*   numeric-format-strings
* meta  : tag-combinatorics, tag-math, tag-bit-manip, tag-probability, tag-easy
***************************************************************************************************/
using System;
using System.Globalization;

class ProbComb {
  int d;
  int d2;
  int q;
  double positive_count;

  // Take input strings and represent them in d, d2 and q
  public void TakeInput() {
    string s1 = Console.ReadLine();
    string s2 = Console.ReadLine();

    d = d2 = q = 0;
    positive_count = 0;
    foreach (char ch in s1)
      switch (ch) {
        case '+':
          d++; break;
        case '-':
          d--; break;
        default:
          break;
      }
    foreach (char ch in s2)
      switch (ch) {
        case '+':
          d2++; break;
        case '-':
          d2--; break;
        case '?':
          q++; break;
        default:
          break;
      }
  }

  public double GetProbability() {
    if (Math.Abs(d - d2) > q)
      return 0.0;
    Comb(d2, 0);
    double res = positive_count / (q==0?1:Math.Pow(2, q));
    return res;
  }

  public void Comb(int v, int k) {
    if (k == q) {
      if (v == d)
        positive_count++;
      return;
    }
    Comb(v + 1, k+1);
    Comb(v - 1, k+1);
  }
}

public class CFSolution {
  public static void Main() {
    ProbComb PC = new ProbComb();
    PC.TakeInput();
    // Default Culture is set to Russian in Codeforces I guess
    // Therefore, format specifier 'F12' produces ',' instead of '.'
    // Setting cutlure to "en-US" enables us to achieve expected behavior
    Console.WriteLine(PC.GetProbability().ToString("F12", CultureInfo.
      CreateSpecificCulture("en-US")));
  }
}

/*
No '?'
count p - n
where p is number of '+' and n is number of '-'

single '?' sign?
Substitute with + and = and count.,
say, d = p - n
d' = p' - n'
if |d-d'| > q (number of .. '?')
then 0
otherwise count,
1 gives,
 d'-1
 d'+1

2 gives,
 d'-1-1
 d'-1+1
 d'+1-1
 d'+1+1

3 gives,
 d'-1-1-1
 d'-1-1+1
 d'-1+1-1
 d'-1+1+1
 d'+1-1-1
 d'+1-1+1
 d'+1+1-1
 d'+1+1+1
 
A beautiful recursion for combination, can be based on my previous 'comb' code.

Developing Solution
--------------------
Sample inputs,
++++
+??+

+-++
?+?+

++-+-
+-+-+

++++++++++
+++??++?++

Combination recursive function draft,
initially I started with,
  void comb_rec(int n, int r)
  it looks like n is not required. only r suffices.
  Usually we need a way to share the array A or pass it to the function

* It is clear that each time we need to assign a value to A[r] and need to call
with (r+1)

*/
