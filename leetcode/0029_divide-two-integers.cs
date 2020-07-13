/***************************************************************************************************
* Title : Divide Two Integers
* URL   : https://leetcode.com/problems/divide-two-integers
* Date  : 2019-02-17 (update)
* Author: Atiq Rahman
* Comp  : O(n)
* Status: TLE
* Notes : 
*   Second version: turns out to be complicated as well reinvented the first verion's algo actually
*   it's basically Grade School Division for Binary Numbers figured out some worst case examples,
*  when input n = int.MaxValue, complexity is O(N). Hence, TLE.
*  
*  Once it was TLE, not because of the division algo but because it was running into an infinite
*  loop as numerator was always same value and denom was always 0.
*
* ToDo- an optimized implementation
* ref   : Implement division with bit-wise operator
*  https://stackoverflow.com/q/5284898
*  https://web.stanford.edu/class/ee486/doc/chap5.pdf section 5.1.2
*  https://www.cs.utah.edu/~rajeev/cs3810/slides/3810-08.pdf
* meta  : tag-math, tag-algo-bsearch, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  // Second version
  public int Divide(int dividend, int divisor) {
    if (divisor == 0) return int.MaxValue; //illegal!
    if (dividend == int.MinValue && divisor == -1) return int.MaxValue; //overflow!
    if (dividend == int.MinValue && divisor == int.MinValue) return 1; //equalence!
    if (dividend != int.MinValue && divisor == int.MinValue) return 0; //obviously!
    if (dividend == int.MinValue) //attention!
    {
      if (divisor > 0)
        return Divide(int.MinValue + divisor, divisor) - 1;
      else
        return Divide(int.MinValue - divisor, divisor) + 1;
    }

    int result = 0;
    int numerator = Math.Abs(dividend);
    while (numerator > 0) {
      int temp = 1;
      // number that we subtract each time from numerator
      int newDenom = Math.Abs(divisor);

      while (newDenom <= numerator) {
        newDenom = newDenom << 1;
        temp = temp << 1;
      }
      newDenom = newDenom >> 1;
      temp = temp >> 1;

      result += temp;
      numerator -= newDenom;
    }
    return (dividend < 0) ^ (divisor < 0) ? -result : result;
  }


  /* First version: turns out to be very complicated
   * Consider  binary division
   *  assume deno < dividend
   *  m = dividend
   * change applied
   */
  public int Divide(int dividend, int divisor) {
    int  m = dividend;
    int n = divisor;
    int sign = 1;
    if (m<=int.MinValue || n<=int.MinValue)
      return int.MaxValue; 
    
    if (m<0 && n<0) {
      m = -m; n = -n;
    }
    else if ((m<0 && n>0) || (m>0 && n<0)) {
      sign = -1;
      if (m<0)
        m = -m;
      else
        n = -n;
    }
    dividend = m;
    divisor = n;
    
    while (m>n && n<int.MaxValue)
      n = n<<1;
    if (m<n)
      n = n>>1;
    int result = 0;
    while(n >= divisor) {
      result = result<<1;
      if (m >= n ) {
        result++;
        m = m-n;
      }
      n = n>>1;
    }
    return result * sign;
  }
}

/* Draft notes,
Helpful inputs,
2147483647
2
2147483647
-1
-2147483648
1
-2147483648
-1
10
3
25
6
20
5
20
4
-20
4 
*/
