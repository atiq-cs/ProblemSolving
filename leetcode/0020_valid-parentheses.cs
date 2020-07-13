/***************************************************************************
* Title : Valid Parentheses
* URL   : https://leetcode.com/problems/valid-parentheses
* Date  : 2017-12-13
* Author: Atiq Rahman
* Comp  : O(n^m * (length(file content) + length(file name)) )
* Status: Accepted
* Notes : Source,
*   'general-solving/hackerrank/CCI/DataStructure/005_balanced-brackets.cs'
*   Run time analysis,
*    Push and pop operations on the Stack takes constant time, O(1).
*    Implemented algorithm iterates over each character of the string.
*    For each char, the algorithm checks if the character is an opening brace
*    in constant time. If it is then the char is pushed into the stack in
*    constant time. Otherwise, a char is popped from the Stack and compared.
*    While doing this if the Stack is found empty or char does not match then,
*    algorithm returns false. In best case, the algorithm returns false right
*    after observing the first char.
*    Therefore, for each char it takes constant time. Overall time complexity,
*    in worst case, is, O(n)
*    
*   Space complexity analysis, 
*    In worst case the stack might contain O(n) items. This worst case can be
*    produced by a string containing all left/opening braces.
*    
*   Ref: msdn - Data Structures & Algorithms complexity
*   https://code.msdn.microsoft.com/windowsapps/Data-Structures-Algorithms-d68f1418
*   
*   If we are allowed to modify original string we can keep removing valid
*   sequences. In the end, if string is empty then it's valid. Here's an
*   example, (()). First we removed (), the string becomes (). We remove that
*   and we end up with empty string.
*   ref: https://leetcode.com/problems/valid-parentheses/discuss/9528/
*   Short-Easy-to-Follow-8ms-Java-Solution
*
*   Additionally, there might be other ways to solve it using O(1) space.
*   However, most people solved it using stack which requires O(N) space.
* 
* meta  : tag-ds-stack, tag-parentheses, tag-leetcode-easy
***************************************************************************/
public class Solution {
  public bool IsValid(string s) {
    return IsBalanced(s);
  }
}
