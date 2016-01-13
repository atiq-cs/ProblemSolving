/***************************************************************************
* Problem Name: Min Stack
* Problem URL : https://leetcode.com/problems/min-stack/
* Date        : Jan 5 2015
* Complexity  : 
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Design a stack that supports push, pop, top, and retrieving
*                the minimum element in constant time.
* meta        : tag-data-structure, tag-stack
***************************************************************************/

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
