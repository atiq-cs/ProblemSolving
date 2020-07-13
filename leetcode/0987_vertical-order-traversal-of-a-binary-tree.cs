/***************************************************************************************************
* Title : Vertical Order Traversal of a Binary Tree
* URL   : https://leetcode.com/problems/vertical-order-traversal-of-a-binary-tree/
* Date  : 2019-02-07
* Comp  : O(n lg n), O(n)
* Status: Accepted
* Notes : Consider nodes as points on (x,y) co-ordinates, sort based on (x,y) and list the results
* 
*   got output limit exceeded in beginning for calling same funciton, assuming wrong polymorphism
*    called it like VerticalTraversal(root);
*    where intended overload hed following signature, 
*     VerticalTraversal(TreeNode node, int index=0)
*   
*   Initially done seperate list for positive and negative indices
*   BFS approach, which is here:
*    https://gist.github.com/atiq-cs/c95f1e61b520516719856079ed752f5e
*   this beats 100% of preivous submissions,
*   complexity for this: O( lg n * lg n * lg^2 n ) + O(n) where lg n = range of index values,
*    lg n = height. Hence, prob it is lg n
* rel   : leetcode premium vertical order traversal
*  https://leetcode.com/problems/binary-tree-vertical-order-traversal/
*  https://leetcode.com/articles/vertical-order-traversal-of-a-binary-tree/
* meta  : tag-graph-binary-tree, tag-csharp-lambda-exp, tag-leetcode-medium
***************************************************************************************************/
public class Solution {
  List<Node> columnNodes;

  internal class Node {
    public int val { get; set; }
    public int x { get; set; }
    public int y { get; set; }

    public Node(int val, int x, int y) {
      this.val = val;
      this.x = x;
      this.y = y;
    }
  }

  public IList<IList<int>> VerticalTraversal(TreeNode root) {
    columnNodes = new List<Node>();
    VerticalTraversal(root, 0, 0);
    columnNodes.Sort((a, b) => a.x == b.x ? a.y == b.y ? a.val - b.val : a.y - b.y : a.x - b.x);

    List<IList<int>> columnVals = new List<IList<int>>();
    Node prev = null;
    foreach (var node in columnNodes) {
      if (node.x != (prev?.x ?? int.MaxValue))
        columnVals.Add(new List<int>());
      columnVals[columnVals.Count - 1].Add(node.val);
      prev = node;
    }

    return columnVals;
  }

  public void VerticalTraversal(TreeNode node, int x, int y) {
    if (node == null)
      return;

    columnNodes.Add(new Node(node.val, x, y));

    VerticalTraversal(node.left, x - 1, y + 1);
    VerticalTraversal(node.right, x + 1, y + 1);
  }
}

/* some inputs,
[0,8,1,null,null,3,2,null,4,5,null,null,7,6]
 realized during implementation that it needs first level first and later levels later also needs
 a level indicator

[0,2,1,3,null,null,null,4,5,null,7,6,null,10,8,11,9]
I think my output without sorting on first verion should be considered correct as well

[0,7,1,null,10,2,null,11,null,3,14,13,null,null,4,null,null,null,null,12,5,null,null,6,9,8]
*/
