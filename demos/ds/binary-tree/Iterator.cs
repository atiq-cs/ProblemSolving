/***************************************************************************
* Title : Binary Search Tree Iterator
* URL   : 
* Date  : 2018-05
* Author: Atiq Rahman
* Comp  : O(lg N) worst case time, amortized O(1), space complexity similar
* Ref   : 'leetcode/173_binary-search-tree-iterator.cs'
* Notes : tag-binary-tree, tag-successor, tag-predecessor
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
  // of, in HasNext
  private TreeNode TreeMinimum(TreeNode current) {
    for (;  current.left != null; current = current.left)
      stack.Push(current);
    return current;
  }
}
