/***************************************************************************************************
* Title : Serialize and Deserialize BST
* URL   : https://leetcode.com/problems/serialize-and-deserialize-bst/
* Date  : 2019-02-04
* Comp  : O(n), O(n)
* Status: Accepted
* Notes : First solution using string
*   It can be further optimized using a Bitconverter technique to mimic memcpy in C++ solution in
*   ref.
*   This is possible for preorder traversal. In inorder, it's hard to determine which one is root.
*   Should also be possible using post-order traversal.
* ref: idea is from medium.com link at bottom
*  And, that we can avoid adding representatins for null values using max, min is from this one
*  https://leetcode.com/problems/serialize-and-deserialize-bst/discuss/93167/Concise-C%2B%2B-19ms-solution-beating-99.4
*  BitConverter
*   https://docs.microsoft.com/en-us/dotnet/api/system.bitconverter.toint32
*  also the link at bottom
*  Mak's idea is to make it more functional by return size as well instead of declaring a global
*  pos variable
* meta  : tag-algo-sort, tag-algo-greedy, tag-ds-queue, tag-leetcode-medium
***************************************************************************************************/
using System;

// Solution using string
public class Codec {
  List<int> sNodes = null;    // serialized nodes
  string[] tokens;
  int pos;

  // Encodes a tree to a single string.
  public string serialize(TreeNode root) {
    sNodes = new List<int>();
    serializeBST(root);
    return string.Join(", ", sNodes);
  }

  /// <summary>
  /// Does a preorder traversal of the tree and adds nodes to node list
  /// </summary>
  /// <param name="node"></param>
  private void serializeBST(TreeNode node) {
    if (node == null)
      return;
    sNodes.Add(node.val);
    serializeBST(node.left);
    serializeBST(node.right);
  }

  // Decodes your encoded data to tree.
  public TreeNode deserialize(string data) {
    tokens = data.Split(", ");    // returns length 1 with an empty string for input empty string..
    pos = 0;
    return string.IsNullOrEmpty(data) ? null : deserializeBST(int.MinValue, int.MaxValue);
  }

  /// <summary>
  /// 'pos' needs to be global or class member; a parameter version will get back to previous
  /// value when call stack traces back
  /// </summary>
  /// <param name="min">allowed min for the sub-tree</param>
  /// <param name="max">allowed max for the sub-tree</param>
  /// <returns> returns deserialized TreeNode </returns>
  private TreeNode deserializeBST(int min, int max) {
    if (pos >= tokens.Length)
      return null;
    int value = int.Parse(tokens[pos]);
    if (value < min || value > max)
      return null;
    var node = new TreeNode(value);
    pos++;
    node.left = deserializeBST(min, value);
    node.right = deserializeBST(value, max);
    return node;
  }
}

/*
Tree Visualizer representation for null,

BST example,
 [5, 3, 6, 2, 4, null, null, 1]

Just a binary tree,
 [1, 2, 3, 4, 5, null, null, 6]

got this example from,
 https://medium.com/@dimko1/serialize-and-deserialize-binary-tree-e9811ead85ed
*/
