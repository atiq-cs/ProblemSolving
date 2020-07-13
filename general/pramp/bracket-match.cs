/***************************************************************************
* Title : Bracket Match
* URL   : https://www.pramp.com/challenge/xJZA01AxdlfpM2vZ2Wwa
* Date  : 2018-04-24
* Author: Atiq Rahman
* Comp  : O(N)
* Status: Accepted
* Notes : Write a function bracketMatch that takes a bracket string as an input
*   and returns the minimum number of brackets you’d need to add to the input
*   in order to make it correctly matched.
*
*   Solved during interview with Masum on pramp
* meta  : tag-easy, tag-parentheses, tag-pramp
***************************************************************************/
using System;

class Solution { 
  public static int BracketMatch(string exp) {
    const char leftBracket = '(';
    const char rightBracket = ')';
    int rightCount = 0;
    int leftCount = 0;
    
    foreach( char br in exp) {
      switch(br) {
      case leftBracket:
        leftCount++;
        break;
      case rightBracket:
        if (leftCount > 0)
        leftCount--;
        else
        rightCount++;
        break;
      default:    // ignore
        break;
      }
    }    
    return leftCount + rightCount;
  }
}

/* draft,
initial consideration to handle extra left brackets
(()
i=0
count++
count = 1
i = 1
count++
count = 2
count--
count = 1

Consideration to handle extra right brackets
())
i=0
count++
count = 1
i = 1
count--
count = 0
i = 2
count--
count = -1
Use absolute value

However, this fails when we input like,
 )(

Therefore new development
()()))
i=0
leftCount++
leftCount = 1
i = 1
leftCount--
leftCount = 0
i = 2
if (leftCount > 0)
  leftCount--
else {
  rightCount++;
}
i=3
leftCount++

leftCount = 1

if (leftCount > 0)
rightCount += leftCount;

return rightCount;
*/
