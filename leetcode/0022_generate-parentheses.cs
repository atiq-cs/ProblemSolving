/***************************************************************************
* Title : Generate Parentheses
* URL   : https://leetcode.com/problems/generate-parentheses
* Date  : 2017-12-23
* Author: Atiq Rahman
* Comp  : might be related to binomial expression
* Status: Accepted
* Notes : Braces/parenthesis are interchangeable terms here. I have used the
*   chars ( and { equivalently in examples in this one as well.
*   Because I consider the position of closing brace to the first opening brace
*   in reverse order result is produced in reverse order.
*   
*   We can make it equivalent to leetcode's result by changing the loop starting
*   from i=n-1 or changing the cal,
*     parenthesesStringList.Add(*)
*     
*   Draft texts of developing the solution is at the bottom of the source file.
*
* rel   : https://leetcode.com/problems/valid-parentheses
*   https://leetcode.com/problems/valid-parenthesis-string
*   https://leetcode.com/problems/remove-invalid-parentheses
*   https://leetcode.com/problems/longest-valid-parentheses
* meta  : tag-ds-stack, tag-balance-expression, tag-parenthesis
***************************************************************************/
public class Solution {
  // top down dp
  public IList<string> GenerateParenthesis(int n) {
    if (n==0)
      return new List<string> { "" };

    IList<string> parenthesisStringList = new List<string>();
    for (int i=0; i<n; i++) {
      IList<string> leftParenthesesStringList = GenerateParenthesis(i);
      IList<string> rightParenthesesStringList = GenerateParenthesis(n-i-1);

      foreach(string leftParenthesesString in leftParenthesesStringList)
        foreach(string rightParenthesesString in rightParenthesesStringList)
          parenthesisStringList.Add('(' + leftParenthesesString + ')' + 
            rightParenthesesString);

    }
    return parenthesisStringList;
  }
}

/*
Draft during initial development,
 The problem presents overlapping sub-problems. To solve the whole problem we
 can solve the smaller parts and combine the result from them.

  n = 0
   ""
  n = 1
   {}
  n = 2
   {}{}
   {{}}

  n =3
   i=0
   {}{{}}
   {}{}{}
   i=1
   {{}}{}
   i=2
   {{{}}}
   {{}{}}

  Comparing with result,
  For, n=3 it looks like,
  ["(((())))",
  "((()()))",
  "((())())",
  "((()))()",
  "(()(()))",
  "(()()())",
  "(()())()",
  "(())(())",
  "(())()()",
  "()((()))",
  "()(()())",
  "()(())()",
  "()()(())",
  "()()()()"]

Darft during implementation

// n=1
IList<string> preParenthesesStringList = GenerateParenthesis(n-1);
IList<string> parenthesesStringList = new List<string>();
foreach(string parenthesesString in preParenthesesStringList)
  parenthesesStringList.Add('(' + parenthesesString + ')' );

// n=2
// i=0 {}{}   f(1) + f(1)
// i=1 {{}}   { f(1) + } + f(0)
IList<string> preParenthesesStringList = GenerateParenthesis(n-1);
IList<string> parenthesesStringList = new List<string>();
foreach(string parenthesesString in preParenthesesStringList)
  parenthesesStringList.Add('(' + parenthesesString + ')' );

// n =3
// {}{{}}   { + f(0) + } * f(2)
// {}{}{}
// {{}}{}   { + f(1) + } * f(1)
// {{{}}}   { + f(2) + } * f(0)
// {{}{}}
*/
