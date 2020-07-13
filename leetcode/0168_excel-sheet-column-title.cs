/***************************************************************************************************
* Title : Excel Sheet Column Title
* URL   : https://leetcode.com/problems/excel-sheet-column-title/
* Date  : 2015-10-07
* Comp  : lg (n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : For Nutanix problem description and cpp solution have a look at
*    '0168_excel-sheet-column-title_v02.cpp'
* meta  : tag-math, tag-leetcode-easy
***************************************************************************************************/
public class Solution
{
  StringBuilder result;

  public string ConvertToTitle(int n)
  {
    result = new StringBuilder();
    ConvertRec(n);
    return result.ToString();
  }

  void ConvertRec(int n)
  {
    if (n == 0)
      return;

    if (n % 26 == 0) {
      ConvertRec((n - 26) / 26);
      result.Append('Z');
    }
    else {
      ConvertRec(n / 26);
      result.Append((char)(n % 26 + 'A' - 1));
    }
  }
}

/*
* Mapping is as following
*  26 -> Z
*  27 -> AA
*  52 -> AZ
*  53 -> BA
*  
* If we try to map this problem with Base converseion
*  First n%26 - is the last 
* Line 27 - ensures that if n is multiple of 26 then
*  Z should be appended
* 26 - Z
  27 - AA
  677 - ZA

  comparing with decimal
  321

  677
  adds A
   next call with n = 26
    Adds 
  
     calls with 1
    adds A
  
  if 1 is given get A
  n%26+'A'-1
  if 26
  (n-1)%26
  when n = 26 we 

  we can say that the number is,
  n = L0 + L1 * 26 + L2 * 26 * 26 + ....

  by getting remainder by dividing by 26 we get the last digit,
  if we get 0 that means Z

  testcase
  18279
  475254
  11535647
  18250
  677

  AZ = 52 = 1*26 + 26
  52 % 26 = 0
  that means a Z
  then n = 2
*/
