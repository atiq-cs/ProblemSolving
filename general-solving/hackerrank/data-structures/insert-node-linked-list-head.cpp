/***************************************************************************************************
* Title : Insert a node at the head of a linked list
* URL   : https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list
* Comp  : O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Concise
* meta  : tag-ds-linked-list
***************************************************************************************************/

Node* Insert(Node *head, int data) {
  Node* root = new Node({ data, NULL });
  root->next = head;
  return root;
}
