/***************************************************************************
* Title : Construct Binary Tree from Preorder Traversal
* URL   : N/A
* Date  : 2017-11-21
* Author: Atiq Rahman
* Comp  : O(n), space O(n)
* Notes : First version,
*   1. Build the Binary Tree
*   2. Perform inorder traversal on the built tree
*   
*   Input is ensured to be of a perfect binary tree
* meta  : tag-interview, tag-binary-tree, tag-company-uber
***************************************************************************/
using System;

class TreeNode {
  public int value { get; set; }
  public TreeNode left { get; set; }
  public TreeNode right { get; set; }

  public TreeNode(int value) {
    this.value = value;
    left = right = null;
  }
}

class BinaryTree {
  int n;
  TreeNode root;

  public BinaryTree() {
    n = -1;
    root = null;
  }

  public void InorderTraversal(TreeNode root) {
    if (root == null)
      return;
    InorderTraversal(root.left);
    Console.Write(" {0}", root.value);
    InorderTraversal(root.right);
  }

  public void ShowInorderTraversal(){
    if (n == -1)
      return ;
    Console.WriteLine("In order traversal of the tree is,");
    InorderTraversal(root);
    Console.WriteLine();
  }
  
  public void ConstructFromPreorderTraversal() {
    Console.WriteLine("Please enter number of nodes in the binary tree:");
    n = Convert.ToInt32(Console.ReadLine());
    if (IsPowerOfTwo(n + 1) == false) {
      Console.WriteLine("Invalid size for perfect binary tree!");
      n = -1;
      return ;
    }
    Console.WriteLine("Preorder traversal input of the tree:");
    string[] a_temp = Console.ReadLine().Split(' ');
    int[] A = Array.ConvertAll(a_temp,Int32.Parse);
    if (A.Length != n) {
      Console.WriteLine("Invalid size for perfect binary tree!");
      n = -1;
      return;
    }
    root = ConstructBinaryTree(A, 0, A.Length-1);
  }

  /* Parameters:
   *   Reference to the Array
   *   Starting index
   *   Ending Index
   */
  private TreeNode ConstructBinaryTree(int[] A, int low, int high) {
    if (low > high)
      return null;
    int mid = (low + high) / 2;
    TreeNode root = new TreeNode(A[low]);
    root.left = ConstructBinaryTree(A, low + 1, mid);
    root.right = ConstructBinaryTree(A, mid+1, high);
    return root;
  }

  // use bitwise technique to determine power of 2
  private bool IsPowerOfTwo(int n) {
    if (n != 0 && ((n - 1) & n) == 0)
      return true;
    return false;
  }
}

class Solution {
  static void Main(String[] args) {
    BinaryTree binTree = new BinaryTree();
    binTree.ConstructFromPreorderTraversal();
    binTree.ShowInorderTraversal();
  }
}
