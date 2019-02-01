/***************************************************************************************************
* Title : Min Stack
* URL   : https://leetcode.com/problems/min-stack/
* Date  : 2015-01-05
* Comp  : O(1)
* Status: Accepted
* Notes : Design a stack that supports push, pop, top, and retrieving
*   the minimum element in constant time.
* meta  : tag-ds-stack, tag-leetcode-easy
***************************************************************************************************/
#include <stack>

class MinStack {
  stack<int> regular_stack;
  stack<int> min_stack;
  
public:
  void push(int x) {
    regular_stack.push(x);
    if (min_stack.empty() || x <= min_stack.top())
      min_stack.push(x);
  }

  void pop() {
    int item = regular_stack.top(); regular_stack.pop();
    if (min_stack.top() == item)
      min_stack.pop();
  }

  int top() {
    return regular_stack.top();
  }

  int getMin() {
    return min_stack.top();
  }
};
/*
Draft
4 5 1 2 3 7 3 4
4 1
does not touch the min stack as long as the item in popped is bigger
continues popping min item as long as the item

0 1 0
r -  0 1 0
min- 0 0
*/
