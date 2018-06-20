/***************************************************************************
* Title : Implement Queue using LinkedList
* URL   : https://leetcode.com/problems/implement-queue-using-stacks
* Date  : 2018--05-25
* Author: Atiq Rahman
* Comp  : O(1), O(1)
* Status: Accepted
* Notes : Using built in Linked List
*   This is a follow up from my part after an amazon interview 2018-05-25
*   
*   leetcode URL above has been used to test the implementation
*   Linked List Generic Class ref:
*   https://msdn.microsoft.com/en-us/library/he2s3bh7.aspx
* meta  : tag-linked-list, tag-leetcode-easy, tag-queue
***************************************************************************/
public class MyQueue {
  private var linkedList = new LinkedList<int>();

  // Push element x to the back of queue.
  public void Push(int x) {
    linkedList.AddLast(x);
  }

  // Removes the element from front of queue.
  public int Pop() {
    int item = linkedList.First();
    linkedList.RemoveFirst();
    return item;
  }

  // Get the front element.
  public int Peek() {
    return linkedList.First();
  }

  // Return whether the queue is empty.
  public bool Empty() {
    return linkedList.Count == 0;
  }
}
