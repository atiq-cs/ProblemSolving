/***************************************************************************************************
* Title : Min Stack
* URL   : https://leetcode.com/problems/min-stack/
* Date  : 2018-04-01
* Occasn: leetcode meetup remote 229 Polaris Ave, Mtn View
* Comp  : O(1), O(1) amortized
* Status: Accepted
* Notes : Design a stack that supports push, pop, top, and retrieving the minimum element in
*   constant time. The cpp version '0155_min-stack.cpp' utilizes O(n) space. This one does better
*   than that, follows an approach from EPI
*   
*   With each item on the stack associate a min item. O(1) space considering for N operations it.
*   This problem does not seem to return Min when items are popped. And this problem does not
*   seem to care about it.
* ref   : EPI
* meta  : tag-ds-stack, tag-leetcode-easy
***************************************************************************************************/
/**
 * Your MinStack object will be instantiated and called as such:
 * MinStack obj = new MinStack();
 * obj.Push(x);
 * obj.Pop();
 * int param_3 = obj.Top();
 * int param_4 = obj.GetMin();
 */

public class MinStack {
  internal class Item {
    public int val { get; set; }
    public int min { get; set; }

    public Item(int v, int m) {
      val = v;
      min = m;
    }
  }

  private Stack<Item> stack;

  public MinStack() {
    stack = new Stack<Item>();
  }

  public void Push(int x) {
    stack.Push(new Item(x, (stack.Count > 0 && stack.Peek().min < x) ? stack.Peek().min : x));
  }

  public void Pop() {
    stack.Pop();
  }

  public int Top() {
    return stack.Peek().val;
  }

  public int GetMin() {
    return stack.Peek().min;
  }
}
