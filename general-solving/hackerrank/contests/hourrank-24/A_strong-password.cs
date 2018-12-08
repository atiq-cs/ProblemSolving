/***************************************************************************
* Title : Strong Password
* URL   : hackerrank.com/contests/hourrank-24/challenges/strong-password
* Date  : 2018-01-27
* Author: Atiq Rahman
* Comp  : O(N)
* Status: Accepted
* Notes : Draft computation,
*   number of remaining chars - number required chars by condition
*
*   Max(numRemaining, numConditionalChars)
*   Ab1
*   numRemaining = 3
*   numConditionalChars = 1

*   Abcd!1
*   numRemaining = 0
*   numConditionalChars = 0
*
* meta  : tag-string, tag-easy, tag-implementation
***************************************************************************/
using System;

class HK_Solution {
  // get how many of required four conditions are not satisfied by the chars in
  // the string yet
  private static int getNumRequiredConditionalChars(string password) {
    bool[] conds = new bool[4];
    foreach (char ch in password) {
      // is upper
      if (char.IsUpper(ch)) {
        // these checks can be omitted if optimization is required
        if (conds[0] == false)
          conds[0] = true;
      }
      // is lower
      else if (char.IsLower(ch)) {
        if (conds[1] == false)
          conds[1] = true;
      }
      // is digit
      else if (char.IsDigit(ch)) {
        if (conds[2] == false)
          conds[2] = true;
      }
      // is special
      else if (conds[3] == false) {
        string special_chars = "!@#$%^&*()-+";
        foreach (char sp in special_chars) {
          if (ch == sp) {
            conds[3] = true;
            break;
          }
        }
      }
    }
    int conditionNotMetCount = 0;
    foreach( bool cond in conds)
      if (cond == false)
        conditionNotMetCount++;
    return conditionNotMetCount;
  }

  private static int minimumNumber(int n, string password) {
    int remainingLength = Math.Max(6 - password.Length, 0);
    int numRequiredConditionalChars = getNumRequiredConditionalChars(password);
    return Math.Max(remainingLength, numRequiredConditionalChars);
  }

  static void Main(String[] args) {
    int n = Convert.ToInt32(Console.ReadLine());
    string password = Console.ReadLine();
    int answer = minimumNumber(n, password);
    Console.WriteLine(answer);
  }
}
