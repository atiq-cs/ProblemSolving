/***************************************************************************
* Title : Palindrome Number
* URL   : https://leetcode.com/problems/palindrome-number
* Date  : 2017-12
* Author: Atiq Rahman
* Comp  : O(n), n = number of digits
* Status: Accepted
* Notes : Get each digit from left and right
*   
*   Example, 543
*   545
* meta  : tag-string-palindrome, tag-leetcode-easy
***************************************************************************/
public class Solution
{
  public bool IsPalindrome(int x) {
    if (x < 0)
      return false;
    // find how many digits
    int dc = getDigitCount(x);
    int mask = (int) Math.Pow(10, dc);
    int n = x;
    while (n != 0) {
      int m = n % 10;   // modulus
      int r = n / mask;
      if (m != r)
        return false;

      n -= r * mask;
      n /= 10;
      mask /= 100;
    }
    return true;
  }

  private int getDigitCount(int n) {
    int count = -1;
    for (; n != 0; count++)
      n /= 10;
    return count;
  }
}

// debug codes
// line 60
// Console.WriteLine("count {0} mask {1}", dc, mask);
// line 64
// Console.WriteLine("m {0} r {1}", m, r);