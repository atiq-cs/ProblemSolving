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

*   
* meta  : tag-ds-binary-tree, tag-successor, tag-predecessor
***************************************************************************/
/// <summary>
/// Successor only, for cleaner code, easier understanding..
/// Just droped shouldFindPredecessor and relevant conditions
/// </summary>
public class BSTSuccessor {
  TreeNode currentNode;
  Stack<TreeNode> stack;

  public BSTSuccessor(TreeNode root) {
    currentNode = root;
    stack = null;
  }

  public bool HasNext() {
    if (stack == null) {
      stack = new Stack<TreeNode>();
      currentNode = currentNode == null ? null : TreeMinimum(currentNode);
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

  /// <summary>
  /// Returns top level parent for last node, not really correct.., should return null
  /// this is ToDo
  /// </summary>
  /// <returns></returns>
  private TreeNode FindSuccessor() {
    TreeNode current = currentNode;
    if (current.right != null)
      return TreeMinimum(current.right);

    if (stack.Count == 0)
      return null;

    TreeNode parent = stack.Pop();
    while (parent.right == current && stack.Count > 0) {
      current = parent;
      parent = stack.Pop();
    }
    return parent;
  }

  /// <summary>
  /// Only first time, root can be null for TreeMinimum call which is taken care of, in HasNext
  /// It works as 'TreeMaximum' when called with shouldFindPredecessor true, note again when it
  /// is true. Means for finding successor we need min from right subtree; hence we look at left
  /// nodes
  /// </summary>
  /// <param name="current"></param>
  /// <returns></returns>
  private TreeNode TreeMinimum(TreeNode current) {
    for (; current.left != null; current = current.left)
      stack.Push(current);
    return current;
  }
}


/// <summary>
/// Generic Implementation
/// </summary>
public class BSTIterator {
  TreeNode currentNode;
  Stack<TreeNode> stack;
  bool shouldFindPredecessor;

  public BSTSuccessor(TreeNode root, bool shouldFindPredecessor = false) {
    currentNode = root;
    stack = null;
    this.shouldFindPredecessor = shouldFindPredecessor;
  }

  public bool HasNext() {
    if (stack == null) {
      stack = new Stack<TreeNode>();
      currentNode = currentNode == null ? null : TreeMinimum(currentNode);
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

  /// <summary>
  /// Only first time, root can be null for TreeMinimum call which is taken care of, in HasNext
  /// It works a 'TreeMaximum' when called with shouldFindPredecessor false
  /// </summary>
  /// <param name="current"></param>
  /// <returns></returns>
  private TreeNode TreeMinimum(TreeNode current) {
    for (; (shouldFindPredecessor?current.right:current.left) != null; current
      = (shouldFindPredecessor ? current.right:current.left))
      stack.Push(current);
    return current;
  }
}
