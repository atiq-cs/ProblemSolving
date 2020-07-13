/***************************************************************************************************
* Title : Number of Digit One
* URL   : https://leetcode.com/problems/number-of-digit-one/
* Date  : 2015-10-06
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* meta  : tag-combination-sum, tag-math, tag-leetcode-hard
***************************************************************************************************/

public class Solution {
  public int CountDigitOne(int n) {
    if (n < 1)               // negative input also expected to be output 0
      return 0;
    if (n <= 9)
      return 1;
    int msb = GetMSB(n);
    int num10 = GetMTen(n);  // get if immediate power of 10, number is 1000, 100 or 10 etc
    int numCounts = msb * CountDigitOne(num10 - 1);

    if (msb == 1)
      numCounts += n % num10 + 1;
    else if (msb > 1)
      numCounts += num10;
    return (numCounts + CountDigitOne(n % (msb * num10)));
  }

  int GetMSB(int n) {
    if (n < 10)
      return n;
    return GetMSB(n / 10);
  }

  int GetMTen(int n) {    // n <> 0
    if (n < 10)
      return 1;
    return 10 * GetMTen(n / 10);
  }
}

/*
from 0 to 9 - 1
1
11 ( count 1 for 11)
21
...
91
total = 9

10
11
12
13
...
19
total = 10

from 10 to 99 - 10 + 9 = 19

0 - 99
100 - 199 (add 100)
..
900 - 999
10 times same situation

from 0 to 999 - 100 + 10 * 19 = 290
1000 times add 1 for 1000-1999
from 0 to 9999 - 1000 + 1000 * 290

say for example I am given,
4321

for 4000,
0 - 999
1000 - 1999
2000 - 2999
3000 - 3999

which means
4 times (0-999)
as msb > 1, so this applies, 1000 times 1 added
  * also consider case when msb = 1
  when msb = 1 1000 will be replaced with n%1000+1

now we are left with 321,
3 times (0-99)
as msb >=1 add 100 times

now we are left with 21
2 times (0-9)
msb > 1, so add 10

therefore, relation holds like this,
  given number n,
  a + b + c
  say d is power of 10
  a = msb * getCount(10^d-1)
  if (msb >1) b = 10^d
  if msb == 1 b= n%(10^d)+1
  
consider input like 111
1000
1111
 
  
say I am given 4321 and 4
 
testing GetMTen 
if 5 is given,
  56
 
10 * foo(5)
*/
