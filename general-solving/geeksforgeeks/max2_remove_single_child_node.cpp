/***************************************************************************************************
* Title : Removing single child nodes from Binary search tree
* Author: Atiq Rahman
* Date  : 2015-06-01
* Notes : Interview question 1, also known as removing half nodes from geeksforgeek can be related with this.
* Status: Tested against several testcases
* ref   : http://www.geeksforgeeks.org/given-a-binary-tree-how-do-you-remove-all-the-half-nodes/
* meta  : tag-ds-tree, tag-coding-practice
***************************************************************************************************/

#include <vector>
#include <iostream>
#include <algorithm>
#include <iomanip>    // setw
#include <deque>    // dequeue
#include <string>     // to_string

void handleIO();

/* Tree Node Structure:
     consists of left, right and data
     and a constructor for easy object creation
*/
typedef struct Node_Type {
  int data;
  Node_Type* left;
  Node_Type* right;
  Node_Type(int val) : left(NULL), right(NULL), data(val) { }
} Node;

int main() {
  handleIO();
  return 0;
}

void handleIO() {
  Node* create_binary_tree_from_data(void);
  Node* remove_single_child_nodes(Node* node);
  void printPretty(Node *root, int level, int indentSpace, std::ostream& out);
  void binary_tree_postorder(Node* p, int indent = 0);

  // Create a Binary Tree Manually
  Node* bt_root = create_binary_tree_from_data();
  // binary_tree_postorder(bt_root);
  std::cout << "Binary tree created," << std::endl;
  printPretty(bt_root, 1, 2, std::cout);

  // Remove nodes that have single child
  remove_single_child_nodes(bt_root);

  // Print the Binary Tree
  std::cout << std::endl << "After removing single child nodes binary tree looks like," << std::endl;
  printPretty(bt_root, 1, 2, std::cout);
}


//===============================================================================================================//
//                      Method: Binary Tree Creation
//===============================================================================================================//
Node* create_binary_tree_from_data(void) {
  /* Test case 1*/
  // Create root node and assign 1
  Node* cur = new Node(2);
  // save the root
  Node* root = cur;

  // Create root node and assign 1
  cur->left = new Node(7);
  cur = cur->left;


  // navigate to left
  cur->right = new Node(6);
  cur = cur->right;

  /*  4
  / \
  5   6   */
  cur->left = new Node(1);
  cur->right = new Node(3);

  // insert 3 as right subtree
  cur = root;

  cur->right = new Node(5);
  cur = cur->right;

  cur->right = new Node(6);
  cur = cur->right;

  cur->right = new Node(9);
  cur = cur->right;

  cur->right = new Node(4);
  cur = cur->right;

  cur->left = new Node(10);
  cur->right = new Node(11);


  /* Test case 2
  // Create root node and assign 1
  Node* root = new Node(1);
  Node* cur = root;

  // Create root node and assign 1
  Node* temp = new Node(2);
  cur->left = temp;

  // navigate to left
  cur = cur->left;
  temp = new Node(3);
  cur->left = temp;

  // navigate to left again
  cur = cur->left;
  temp = new Node(4);
  cur->left = temp;

  /*  4
     / \
    5   6   
  cur = cur->left;
  cur->left = new Node(5);
  cur->right = new Node(6);

  // insert 3 as right subtree
  cur = root;
  temp = new Node(7);
  cur->right = temp; */

  return root;
}

//===============================================================================================================//
//                      Method Single Child Node Removal from Binary Tree
//===============================================================================================================//
// this is what I was asked to do
Node* remove_single_child_nodes(Node* node) {
  // leaf node
  if (node->left == NULL && node->right == NULL)
    return node;
  
  // has both children
  if (node->left && node->right) {
    node->left = remove_single_child_nodes(node->left);
    node->right = remove_single_child_nodes(node->right);
    return node;
  }

  // has only left child
  // could write if (node->right) but it's better to specificly check for NULL instead of non-zero value
  if (node->right == NULL) {
    Node* temp = node->left;
    delete node;
    return remove_single_child_nodes(temp);
  }

  // has only right child, if control comes here that means it
  // if (node->right)
  Node* temp = node->right;
  delete node;
  return remove_single_child_nodes(temp);
}

//===============================================================================================================//
//                      Method: pretty print of Binary Tree
//===============================================================================================================//
// ref: http://articles.leetcode.com/2010/09/how-to-pretty-print-binary-tree.html
// Find the maximum height of the binary tree
int maxHeight(Node *p) {
  if (!p) return 0;
  int leftHeight = maxHeight(p->left);
  int rightHeight = maxHeight(p->right);
  return (leftHeight > rightHeight) ? leftHeight + 1 : rightHeight + 1;
}

// Print the arm branches (eg, /  \ ) on a line
void printBranches(int branchLen, int nodeSpaceLen, int startLen, int nodesInThisLevel, const std::deque<Node*>& nodesQueue, \
  std::ostream& out) {
  std::deque<Node*>::const_iterator iter = nodesQueue.begin();
  for (int i = 0; i < nodesInThisLevel / 2; i++) {
    out << ((i == 0) ? std::setw(startLen - 1) : std::setw(nodeSpaceLen - 2)) << "" << ((*iter++) ? "/" : " ");
    out << std::setw(2 * branchLen + 2) << "" << ((*iter++) ? "\\" : " ");
  }
  out << std::endl;
}

// Print the branches and node (eg, ___10___ )
void printNodes(int branchLen, int nodeSpaceLen, int startLen, int nodesInThisLevel, const std::deque<Node*>& nodesQueue, \
  std::ostream& out) {
  std::deque<Node*>::const_iterator iter = nodesQueue.begin();
  for (int i = 0; i < nodesInThisLevel; i++, iter++) {
    out << ((i == 0) ? std::setw(startLen) : std::setw(nodeSpaceLen)) << "" << ((*iter && (*iter)->left) ? \
      std::setfill('_') : std::setfill(' '));
    out << std::setw(branchLen + 2) << ((*iter) ? std::to_string((*iter)->data) : "");
    out << ((*iter && (*iter)->right) ? std::setfill('_') : std::setfill(' ')) << std::setw(branchLen) << "" << \
      std::setfill(' ');
  }
  out << std::endl;
}

// Print the leaves only (just for the bottom row)
void printLeaves(int indentSpace, int level, int nodesInThisLevel, const std::deque<Node*>& nodesQueue, std::ostream& out) {
  std::deque<Node*>::const_iterator iter = nodesQueue.begin();
  for (int i = 0; i < nodesInThisLevel; i++, iter++) {
    out << ((i == 0) ? std::setw(indentSpace + 2) : std::setw(2 * level + 2)) << ((*iter) ? std::to_string((*iter)->data) : \
      "");
  }
  out << std::endl;
}

// Pretty formatting of a binary tree to the output stream
// @ param
// level  Control how wide you want the tree to sparse (eg, level 1 has the minimum space between nodes, while level 2 has a \
larger space between nodes)
// indentSpace  Change this to add some indent space to the left (eg, indentSpace of 0 means the lowest level of the left node \
will stick to the left margin)
void printPretty(Node *root, int level, int indentSpace, std::ostream& out) {
  int h = maxHeight(root);
  int nodesInThisLevel = 1;

  int branchLen = 2 * ((int)pow(2.0, h) - 1) - (3 - level)*(int)pow(2.0, h - 1);  // eq of the length of branch for each node \
  of each level
  int nodeSpaceLen = 2 + (level + 1)*(int)pow(2.0, h);  // distance between left neighbor node's right arm and right neighbor \
  node's left arm
  int startLen = branchLen + (3 - level) + indentSpace;  // starting space to the first node to print of each level (for the\
   left most node of each level only)

  std::deque<Node*> nodesQueue;
  nodesQueue.push_back(root);
  for (int r = 1; r < h; r++) {
    printBranches(branchLen, nodeSpaceLen, startLen, nodesInThisLevel, nodesQueue, out);
    branchLen = branchLen / 2 - 1;
    nodeSpaceLen = nodeSpaceLen / 2 + 1;
    startLen = branchLen + (3 - level) + indentSpace;
    printNodes(branchLen, nodeSpaceLen, startLen, nodesInThisLevel, nodesQueue, out);

    for (int i = 0; i < nodesInThisLevel; i++) {
      Node *currNode = nodesQueue.front();
      nodesQueue.pop_front();
      if (currNode) {
        nodesQueue.push_back(currNode->left);
        nodesQueue.push_back(currNode->right);
      }
      else {
        nodesQueue.push_back(NULL);
        nodesQueue.push_back(NULL);
      }
    }
    nodesInThisLevel *= 2;
  }
  printBranches(branchLen, nodeSpaceLen, startLen, nodesInThisLevel, nodesQueue, out);
  printLeaves(indentSpace, level, nodesInThisLevel, nodesQueue, out);
}
// implementation pretty print of binary tree ends here
