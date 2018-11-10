/***************************************************************************************************
* Title : Removing single child nodes from Binary search tree
* Author: Atiq Rahman
* Date  : 2015-06-05
* Notes : Second level interview question 1
*   Question, the Vertical sum in a given Binary tree, i.e. sum of nodes in the same vertical
*
*   1
*   / \
*   2   3
*   / \ / \
*   4  5 6  7
*
*   First line: 4 = 4
*   Second line: 2 = 2
*   Third Line: 1,5,6 = 12
*   Fourth Line: 3 = 3
*   Fifth Line: 7 = 7
*
*   output 4,2,12,3,7
* ref   : http://www.geeksforgeeks.org/vertical-sum-in-a-given-binary-tree/
* Status: Tested against several testcases
* meta  : tag-ds-tree
***************************************************************************************************/
#include <vector>
#include <iostream>
#include <algorithm>
#include <iomanip>    // setw
#include <deque>    // dequeue
#include <string>     // to_string
#include <map>

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
  std::vector<int> find_vertical_sum(Node* node);
  void printPretty(Node *root, int level, int indentSpace, std::ostream& out);

  // Create a Binary Tree Manually
  Node* bt_root = create_binary_tree_from_data();
  // binary_tree_postorder(bt_root);
  std::cout << "Binary tree created," << std::endl;
  printPretty(bt_root, 1, 2, std::cout);

  // Print the Binary Tree
  std::cout << std::endl << "Computed vertical sums are," << std::endl;
  // Remove nodes that have single child
  for (auto sum : find_vertical_sum(bt_root))
    std::cout << " " << sum;
  std::cout << std::endl;
}


//===============================================================================================================//
//                      Method: Binary Tree Creation
//===============================================================================================================//
Node* create_binary_tree_from_data(void) {
  /* Test case 1
     1
    / \
     2   3
    / \  /\
   4  5 6  7
  
  // Create root node and assign 1
  Node* cur = new Node(1);
  // save the root
  Node* root = cur;

  // Create root node and assign 1
  cur->left = new Node(2);
  cur->right = new Node(3);

  // navigate to left, 2
  cur = cur->left;
  // add 4,5 as children
  cur->left = new Node(4);
  cur->right = new Node(5);

  // navigate to root's right child, 3
  cur = root->right;
  cur->left = new Node(6);
  cur->right = new Node(7); */

  /* Test case 2
          1
        /   \
      2       3
     / \      /\
    4   5     6  7
   / \ / \   /\  /\
  8  910 1112 131415
  */

  // Create root node and assign 1
  Node* cur = new Node(1);
  // save the root
  Node* root = cur;

  // Create root node and assign 1
  cur->left = new Node(2);
  cur->right = new Node(3);

  // navigate to left, 2
  cur = cur->left;
  // add 4,5 as children
  cur->left = new Node(4);
  // add 8 and 9 as children
  cur->left->left = new Node(8);
  cur->left->right = new Node(9);

  cur->right = new Node(5);
  // add 10 and 11 as children
  cur->right->left = new Node(10);
  cur->right->right = new Node(11);

  // navigate to root's right child, 3
  cur = root->right;
  cur->left = new Node(6);
  // add 12 and 13 as children of 6
  cur->left->left = new Node(12);
  cur->left->right = new Node(13);
  cur->right = new Node(7);
  // add 14 and 15 as children of 7
  cur->right->left = new Node(14);
  cur->right->right = new Node(15);
  return root;
}

//===============================================================================================================//
//                      Method Find vertical sum, second one is the solution
//===============================================================================================================//
// global definitions for easy access to result
// basic target is to solve the vertical sum problem using recursion, not making the map access faster
// an unordered map will perform better when depth of the tree is more
// http://stackoverflow.com/questions/5908581/is-hash-map-part-of-the-stl
// http://stackoverflow.com/questions/2189189/map-vs-hash-map-in-c
// 
std::map<int, int> vert_sum;
std::vector<int> find_vertical_sum(Node* node) {
  void vertical_sum_rec(Node* node, int index);

  vertical_sum_rec(node, 0);

  std::vector<int> result;
  // this is still not supported
  //for (auto it:vert_sum) {
  for (auto it = vert_sum.cbegin(); it != vert_sum.cend(); ++it)
    result.push_back(it->second);

  return result;
}

// the recursive function that solves the problem
void vertical_sum_rec(Node* node, int index) {
  if (node == NULL)
    return;

  try {
    vert_sum[index] += node->data;
  }
  catch (std::out_of_range e) {
    vert_sum[index] = node->data;
  }

  if (node->left != NULL) {
    vertical_sum_rec(node->left, index - 1);
  }

  if (node->right != NULL) {
    vertical_sum_rec(node->right, index + 1);
  }
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
    out << ((i == 0) ? std::setw(startLen) : std::setw(nodeSpaceLen)) << "" << ((*iter && (*iter)->left) ? std::setfill('_') \
      : std::setfill(' '));
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
