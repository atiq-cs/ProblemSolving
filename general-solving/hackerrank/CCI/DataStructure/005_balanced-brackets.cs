/***************************************************************************************************
* Title : Stacks: Balanced Brackets
* URL   : https://www.hackerrank.com/challenges/ctci-balanced-brackets
* Date  : 2016-01-28
* Comp  : O(n log n) Time
* Author: Atiq Rahman
* Status: Accepted
* Notes : Time complexity depends on implementation of stack
*   more desc at 'leetcode/0020_valid-parentheses.cs'
* meta  : tag-ds-stack, tag-easy
***************************************************************************************************/
using System;
using System.Collections.Generic;

class HKSolution
{
  static bool IsLeftBracket(char ch)
  {
    if (ch == '(' || ch == '{' || ch == '[')
      return true;
    return false;
  }
  
  static char MapRightBracket(char ch)
  {
    string left_br = "({[";
    string right_br = ")}]";
    for (int i=0; i<left_br.Length; i++)
      if (ch == right_br[i])
        return left_br[i];
    return '\0';
  }
  
  static bool IsBalanced(string str)
  {
    Stack<char> br_stack = new Stack<char>();
    
    foreach (char br in str)  // br = bracket
      if (IsLeftBracket(br))
        br_stack.Push(br);
      // stack is empty or popped bracket does not match
      else if (br_stack.Count == 0 || br_stack.Pop() != MapRightBracket(br))
        return false;
    return br_stack.Count == 0;
  }
  
  static void Main(String[] args)
  {
    int t = Convert.ToInt32(Console.ReadLine());
    for(int a0 = 0; a0 < t; a0++) {
      string expression = Console.ReadLine();
      if (IsBalanced(expression))
        Console.WriteLine("YES");
      else
        Console.WriteLine("NO");
    }
  }
}
