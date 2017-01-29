/***************************************************************************
* Problem Name: Stacks: Balanced Brackets
* Problem URL : https://www.hackerrank.com/challenges/ctci-balanced-brackets
* Date        : Jan 28, 2016
* Complexity  : O(n log n) Time
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : 
*               Time complexity depends on implementation of stack
* meta        : tag-easy; tag-data-structure
***************************************************************************/
using System;
using System.Collections.Generic;

class Solution {
    static bool IsLeftBracket(char ch) {
        if (ch == '(' || ch == '{' || ch == '[')
            return true;
        return false;
    }
    
    static char MapRightBracket(char ch) {
        string left_br = "({[";
        string right_br = ")}]";
        for (int i=0; i<left_br.Length; i++)
            if (ch == right_br[i])
                return left_br[i];
        return '\0';
    }
    
    static bool IsBalanced(string str) {
        Stack<char> br_stack = new Stack<char>();
        
        for (int i=0; i < str.Length; i++) {
            if (IsLeftBracket(str[i]))
                br_stack.Push(str[i]);
            else {
                if (br_stack.Count == 0)
                    return false;
                char ch = br_stack.Pop();
                if (ch != MapRightBracket(str[i]))
                    return false;
            }
        }
        return br_stack.Count == 0;
    }
    
    static void Main(String[] args) {
        int t = Convert.ToInt32(Console.ReadLine());
        for(int a0 = 0; a0 < t; a0++){
            string expression = Console.ReadLine();
            if (IsBalanced(expression))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }
}
