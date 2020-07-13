/***************************************************************************************************
* Title : Decode Ways
* URL   : https://leetcode.com/problems/decode-ways/
* Date  : 2015-10-23
* Comp  : O(n), O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : similar to Climbing Stairs except the tricky cases we have to consider
* 
*   simplified recursion ref,
*    https://leetcode.com/problems/decode-ways/discuss/233731/my-simple-java-solution
*   which means DP relation could be simplified, simplify later..
*   here's DP short,
*    https://leetcode.com/problems/decode-ways/discuss/232321/Compact-Java-Solution
*   ToDo: understand/improve
*   must explain thi algo and publish
*   
*   todo-blog-publish
*
* rel   : ltcode#639
* meta  : tag-algo-dp, tag-string, tag-fibonacci, tag-leetcode-medium
***************************************************************************************************/
public class Solution
{
  public int NumDecodings(string s) {
    int fibA = 0;
    int fibB = 1;
    for (int i=0; i<s.Length; i++) {
      // 0 not following 1/2 is invalid, otherwise 0 anywhere invalid
      if ((i==0 && s[i]=='0') || (i>0 && (s[i-1] != '1' && s[i-1] != '2') && s[i]=='0')) {
        fibB = 0;
        break;
      }

      if (i>0) {
        // check if next char is 0 then 10/20 has to be dealed
        if (i<s.Length-1 && (s[i]=='1' || s[i]=='2') && s[i+1]=='0')
          continue;     // in this case don't assign: fibA = fibB
        if (canFormPair(s[i-1], s[i])) {
          int temp = fibB;
          fibB += fibA;
          fibA = temp;
        }
        else
          fibA = fibB;
      }
      else
        fibA = fibB;
    }
    return s.Length==0?fibA:fibB;
  }
  
  bool canFormPair(char s, char t) {
    if (s>='3' || s=='0')
      return false;
    if (s=='2' && t>'6')
      return false;
    if ((s=='1' || s=='2') && t=='0')
      return false;
    return true;
  }
}

/*
  Sketches
  ----------------
  12 -> AB
  12 -> L

  Number of ways to decode 12 is 2
  1 -> 1
  2 -> 1
  .....
  10 -> 1

  11 -> 2
  19 -> 2
  20 -> 1   ; only for 20, there's not 2 0, as there's no representation for 0
  21 -> 2
  ...
  26 -> 2


  2626
  2,6,2,6
  2,6,26
  26, 2, 6
  26, 26

  getting 262221
  I get I see 62 can't be paired
  valid pairs
  00000
  00001
  00010
  00100

  262221
  total pairs we can make
  3 max
  for these pairs

  2,6,2,2,1
  2,6,2,21
  2,6,


  1,2
  12
  number of ways = 2

  1,2,3
  pairs possible 12, 23
  1, 2, 3
  1, 23
  12, 3
  number of ways = 3
  combination with pairs = 2

  say we have many numbers 3,1,2,23
  2 pairs with 5 numbers = 3
  3,1,2,2,3
  3, 1, 2, 23
  3, 12, 23
  3, 12, 2, 3
  3, 1, 22, 3
  1 pair with any number = 1
  default = 1
  total = 1+1+2

  // considering only valid inputs, that all pairs are valid
  if len == 1
    return 1
  if len == 2
    return 2
  /
    1, 2, 3
    1, 23
    12, 3
  /
  
  if len == 3
    return 3
  /
    2, 1, 2, 3
    2, 1, 23
    21, 2, 3
    2, 12, 3
    21, 23
  /
  if len ==4
    return 5
  4988647303


  DP
  ------
  Number of ways a number can be decoded = number of ways its counterparts can be decoded

  1212
  1,2,1,2
  12, 1, 2
  1,2, 12
  12, 12

  say I get a new character each time
  1
  nw = 1
  11
  nw = 2
  111 = {1,11}, {11,1}, {1,1,1}
  nw = 1 + nw_0 // add previous one, when current number can form number being set together with previous 1
  =3
  to verify this,
  131 = {1 , 3, 1}, {13, 1}

  3+2
  1111 = {1,1,1,1} {11, 1, 1}, {1, 11, 1}, {11, 11}, {1, 1, 11}

  113 = {1,13}, {11,3}, {1,1,3}

  1131= {1,13, 1}, {11,3, 1}, {1,1,3, 1}

  3 + 5 = 8
  11111

  "11111"
  11
  = 0 + 1, 1+1 = 2
  111
  1+2=3
  1111
  2+3 =5

  1115
  nw = 5
  11151
  nw = 5
  111511
  nw = 5 + 5 ?

  Special Inputs
  "2626666111156"
  ""
  "0"
  "01"
  "122322122220"
  "012232212222234"
  "1010"
  "100"
  "101"
  "110"
*/
