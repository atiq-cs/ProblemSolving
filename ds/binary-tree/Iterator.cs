/***************************************************************************
* Title : Binary Search Tree Iterator
* URL   : 
* Date  : 2018-05
* Author: Atiq Rahman
* Comp  : O(lg N) worst case time, amortized O(1), space complexity similar
* Ref   : 'leetcode/173_binary-search-tree-iterator.cs'
* Notes : Generic implementation to handle both successors and predecessors
*   (inorder traversal)
*   TODO: post-order and pre-order
*   wanna simplify?
*   Just drop shouldFindPredecessor and pertinent conditionals
* meta  : tag-binary-tree, tag-successor, tag-predecessor
***************************************************************************/
public class BSTIterator {
  TreeNode currentNode;
  Stack<TreeNode> stack;
  bool shouldFindPredecessor;

  public BSTIterator(TreeNode root, bool shouldFindPredecessor = false) {
    currentNode = root;
    stack = null;
    this.shouldFindPredecessor = shouldFindPredecessor;
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
    if ((shouldFindPredecessor ? x.left : x.right) != null)
      return TreeMinimum(shouldFindPredecessor ? x.left : x.right);
    if (stack.Count == 0) { return null; }
    TreeNode y = stack.Pop();
    while ((shouldFindPredecessor?y.left:y.right) == x && stack.Count > 0) {
      x = y;
      y = stack.Pop();      
    }
    return y;
  }

  // Only first time, root can be null for TreeMinimum call which is taken care
  // of, in HasNext
  private TreeNode TreeMinimum(TreeNode current) {
    for (; (shouldFindPredecessor?current.right:current.left) != null; current
      = (shouldFindPredecessor ? current.right:current.left))
      stack.Push(current);
    return current;
  }
}
