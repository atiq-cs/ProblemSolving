/***************************************************************************
* Title : Delete Node in a BST
* URL   : https://leetcode.com/problems/delete-node-in-a-bst
* Date  : 2018-01-06
* Author: Atiq Rahman
* Comp  : O(h), h = lg n
* Status: Accepted
* Notes : Took a few attempts to get it right.
*   I considered following cases during implementation,
*   - z has no left child
*   - z has no right child
*   - z has both children
*   - z is root of the Tree
*   * y might have no children; y's right should point to z's right subtree
*   - node z containing value k is not found (applicable to this problem)
*   
*   After first few versions of implementation got TLE. Reason behind TLE is
*   wrong wiring of node's pointers which created cycle. Therefore, judge's
*   program would not terminate in time. There is no language specific time
*   limit inconsistency for this problem.
*   
*   I used solution of chuan-shuo-xuan-shou
*   https://leetcode.com/problems/delete-node-in-a-bst/discuss/93296 to verify
*   time constraint.
*   
*  TREE-SUCCESSOR (C.L.R.S p#292):
*   Simple version of TREE-SUCCESSOR(x); x.right is not NIL is demonstrated
*   below. Due to the simplified application TREE-SUCCESSOR could not be fully
*   tested with this leetcode problem.
*   
*   Transplant(T, u, v) [C.L.R.S p#296] is not implemented as a function due to
*   requirement of passing of additional parameters. For an independent
*   function it might require following parameters,
*   - parent of z
*   - z
*   - parent of successor y
*   - successor y
*   Additionally, based on conditions root of the Tree might need to be updated
*   
*   There are a few inputs in the input text file added as well. Variations of
*   the small input were useful. Large one is added for reference only.
* ref   : C.L.R.S 3rd ed, p#298
* rel : http://lintcode.com/en/problem/insert-node-in-a-binary-search-tree/
* meta  : tag-ds-bst, tag-successor, tag-ds-core
***************************************************************************/
public class Solution
{
  public TreeNode DeleteNode(TreeNode root, int key) {
    // find node z which should be deleted
    TreeNode pz = null; // parent of z
    TreeNode z = root;
    while (z != null && z.val != key) {
      pz = z;
      if (z.val > key)
        z = z.left;
      else
        z = z.right;
    }

    // either z could not be found or root is null
    if (z==null)
      return root;
    
    // right node of z should replace z
    if (z.left == null) {
      // z is root
      if (pz == null)
        root = z.right;
      else if (pz.left == z)
        pz.left = z.right;
      else
        pz.right = z.right;
    }
    // left node of z should replace z
    else if (z.right == null) {
      if (pz == null)
        root = z.left;
      else if (pz.left == z)
        pz.left = z.left;
      else
        pz.right = z.left;
    }
    // has both children replace z with it's successor y
    else {
      TreeNode py = null;
      TreeNode y = z.right;
      // Simple version of TREE-SUCCESSOR(x); x.right is not NIL
      // After this loop, y.left becomes NIL
      // if variable parent of y is NIL, then y is right node of z
      while (y.left != null) {
        py = y;
        y = y.left; 
      }

      // changed source code flow following C.L.R.S
      // y is not child of z, y's right node should replace y
      if (py != null) {
        // TRANSPLANT(T, y, y.right)  C.L.R.S p#298
        if (py.left == y)
          py.left = y.right;
        else
          py.right = y.right;
        // ** y's right should be assigned to z's right coz y is replacing z
        // Example
        // [5,3,7,2,4,6,8]
        //  5
        y.right = z.right;
      }

      // TRANSPLANT(T, z, y)
      // here, if z is root then y becomes new root
      if (pz == null)
        root = y;
      else if (pz.left == z)
        pz.left = y;
      else
        pz.right = y;

      y.left = z.left;
    }
    return root;
  }
}
