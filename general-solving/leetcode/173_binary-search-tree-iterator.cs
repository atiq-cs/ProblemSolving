/***************************************************************************
* Title : Binary Search Tree Iterator
* URL   : https://leetcode.com/problems/binary-search-tree-iterator
* Occas : InnoWorld Meetup 05-13
* Date  : 2018-05-15
* Author: Atiq Rahman
* Comp  : O(lg N) worst case time complexity, amortized time complexity should
*   is O(1), space complexity is similar
* Status: Accepted
* Notes : https://leetcode.com/problems/binary-search-tree-iterator/discuss/
*   130629/C++-Solution-O(1)-amortized-complexity-for-both-next()-and-hasNext()
*   pushes an extra item in the stack, which allows it to verify if there's an
*   next item by checking whether Stack is Empty or not.
* meta  : tag-leetcode-medium, tag-binary-tree
***************************************************************************/
public class BSTIterator {
  TreeNode currentNode;
  Stack<TreeNode> stack;
  
  public BSTIterator(TreeNode root) {
    currentNode = root;
    stack = null;
  }

  public bool HasNext() {
    if (stack == null) {
      stack = new Stack<TreeNode>();
      currentNode = currentNode == null ? null: TreeMinimum(currentNode);
    }
    else
      currentNode = FindSuccessor();
    return (currentNode != null);
  }

  // In this leetcode problem this call is followed by a HasNext() call,
  // HasNext takes care of null checking
  public int Next() {
    return currentNode.val;
  }
  
  private TreeNode FindSuccessor() {
    TreeNode x = currentNode;
    if (x.right != null)
      return TreeMinimum(x.right);
    if (stack.Count == 0) { return null; }
    TreeNode y = stack.Pop();
    while (y.right == x && stack.Count > 0) {
      x = y;
      y = stack.Pop();      
    }
    return y;
  }

  // Only first time, root can be null for TreeMinimum call which is taken care
  // of in HasNext
  private TreeNode TreeMinimum(TreeNode root) {
    TreeNode current = root;
    while (current.left != null) {
      stack.Push(current);
      current = current.left;
    }
    return current;
  }
}
