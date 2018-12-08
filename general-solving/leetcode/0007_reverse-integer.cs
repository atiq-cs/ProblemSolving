/***************************************************************************************************
* Title : Reverse Integer
* URL   : https://leetcode.com/problems/reverse-integer/
* Date  : 2015-10-20
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Approach using string to reverse
*   and then handle the sign, this approach goes this way
*     public int Reverse(int x) {
*     bool isNeg = false;
*     if (x<0) { isNeg = true; x = -x; }
*
*   However, this has a problem only case to handle is to handle max negative number
* meta  : tag-leetcode-easy
***************************************************************************************************/

public class Solution
{
  public int Reverse(int x) {
    bool isNeg = false;
    bool maxNeg = false;

    if (x < 0)
    {
      isNeg = true;
      if (x == -2147483648)
      {   // strange x does not match with 0x80000000, probably needs an unsigned cast
        maxNeg = true;
        x++;
      }
      x = -x;
    }

    char[] chArr = x.ToString().ToCharArray();
    Array.Reverse(chArr);

    if (IsOverflow(chArr))
      return 0;

    string resultString = new string(chArr);

    if (isNeg)
    {
      if (maxNeg)
        return (-1 - int.Parse(resultString));

      return (0 - int.Parse(resultString));
    }
    return int.Parse(resultString);
  }

  bool IsOverflow(char[] chArr) {
    if (chArr.Length <= 9)
      return false;
    char[] limit = int.MaxValue.ToString().ToCharArray(); // "2147483647"
    for (int i = 0; i < chArr.Length; i++)
    {
      if (chArr[i] > limit[i])
        return true;
      if (chArr[i] < limit[i])
        return false;
    }
    return false;
  }
}

/*
Reverse integer using 
  123
The stack gives me
  321
    
When integer overflows when value is greater than 2147483647
This will be reproduced when we try to reverse a number that has > 7412
  
Following inputs are also present,
  2147483647
  7463847412
  -2147483648
  -123
  -10
  10
  100

Time: beats 83%

2's complement converter
http://www.exploringbinary.com/twos-complement-converter/
*/
public class Solution
{
  int revRes = 0;

  public int Reverse(int x) {
    revRes = 0;
    ReverseRec(x);
    //if (x>0 && revRes<0 || (x<0 && revRes>0))
    //  return 0;
    int pTen = 0;
    if (revRes < 0)
    {
      pTen = GetImmediatePTen(-revRes);
      if (x > 0 || (-x % 10 > 0 && revRes / pTen != x % 10))
        return 0;
    }
    else
    {
      pTen = GetImmediatePTen(revRes);
      if (x < 0 || (x % 10 > 0 && revRes / pTen != x % 10))
        return 0;
    }
    return revRes;
  }

  void ReverseRec(int n) {
    if (n == 0)
      return;
    revRes = revRes * 10 + n % 10;
    ReverseRec(n / 10);
  }

  int GetImmediatePTen(int n) {  // n <> 0
    if (n < 10)
      return 1;
    return 10 * GetImmediatePTen(n / 10);
  }
}
