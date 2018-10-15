/***************************************************************************************************
* Title : Divide Two Integers
* URL   : https://leetcode.com/problems/divide-two-integers
* Date  : 2018-08-01 (update)
* Author: Atiq Rahman
* Comp  : O(n)
* Status: TLE
* Notes : 
*   Second version: turns out to be complicated as well reinvented the first verion's algo actually
*   it's basically Grade School Division for Binary Numbers figured out some worst case examples,
*  when input n = int.MaxValue, complexity is O(N). Hence, TLE.
* ToDo- an optimized implementation
* ref   : Implement division with bit-wise operator
*  https://stackoverflow.com/q/5284898
*  https://web.stanford.edu/class/ee486/doc/chap5.pdf section 5.1.2
* meta  : tag-leetcode-medium, tag-math, tag-binary-search
***************************************************************************************************/
public class Solution {
  // Second version
  public int Divide(int dividend, int divisor) {
    if (divisor==1 || divisor==-1)
      return divisor==1?dividend : dividend==int.MinValue?int.MaxValue:-dividend;
    if (dividend==int.MinValue)
      return int.MaxValue;
    bool isNegative = false;
    if (dividend<0 && divisor<0) {
      dividend *= -1;
      divisor *= -1;
    }
    else if (dividend<0) {
      dividend *= -1;
      isNegative = true;
    }
    else if (divisor<0) {
      divisor *= -1;
      isNegative = true;
    }
    
    int result = 0;
    int numerator = dividend;
    while (numerator > 0) {
      int temp = 1;
      // number that we subtract each time from numerator
      int newDenom = divisor;

      while (newDenom <= numerator) {
        newDenom = newDenom<<1;
        temp = temp<<1;
      }
      newDenom = newDenom>>1;
      temp = temp>>1;

      result += temp;
      numerator -= newDenom;
    }
    return isNegative? -result: result;
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
