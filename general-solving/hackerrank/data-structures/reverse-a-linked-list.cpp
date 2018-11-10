/***************************************************************************************************
* Title : Solve me second
* URL   : https://www.hackerrank.com/challenges/reverse-a-linked-list
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Points
*   - Reverse a linked list and return pointer to the head
    - The input list will have at least one element
* meta  : tag-ds-linked-list
***************************************************************************************************/

/*
      struct Node
      {
       int data;
       struct Node *next;
      }
*/

Node* Reverse(Node *head)
{
  // starting from head all the nodes next pointer has to be changed
  if (head == NULL || head->next == NULL)
    return head;

  // for head next should be set to NULL
  Node* cur_node = head->next;
  Node* pre_node = head;

  while (cur_node != NULL) {
    Node* temp = cur_node->next;
    cur_node->next = pre_node;
    pre_node = cur_node;
    cur_node = temp;
  }

  head->next = NULL;
  return pre_node;
}
