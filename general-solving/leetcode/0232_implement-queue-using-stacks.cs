/***************************************************************************
* Title : Implement Queue using Stacks
* URL   : https://leetcode.com/problems/implement-queue-using-stacks
* Date  : 2015-10
* Author: Atiq Rahman
* Comp  : O(1), O(1)
* Status: Accepted
* Notes : Amortized time complexity O(1)
*   push() is O(1) worst-case
*   pop() is O(1) amortized
*   
*   revised my solution based on idea:
*   https://leetcode.com/articles/implement-queue-using-stacks/
* meta  : tag-ds-stack, tag-ds-queue, tag-leetcode-easy
***************************************************************************/
public class MyQueue {
  Stack<int> s1 = new Stack<int>();
  Stack<int> s2 = new Stack<int>();
  int front;

  // Push element x to the back of queue.
  public void Push(int x) {
    if (s1.Count == 0)
      front = x;
    s1.Push(x);
  }

  // Removes the element from front of queue.
  public int Pop() {
    if (s2.Count == 0)
      while (s1.Count != 0) {
        s2.Push(s1.Peek());
        s1.Pop();
      }
    return s2.Pop();
  }

  // Get the front element.
  public int Peek() {
    if (s2.Count == 0)
      return front;
    return s2.Peek();
  }

  // Return whether the queue is empty.
  public bool Empty() {
    return s1.Count == 0 && s2.Count == 0;
  }
}
