/*
*  Problem Name:  Insert a node at the tail of a linked list
*  Problem No  :  https://www.hackerrank.com/challenges/insert-a-node-at-the-tail-of-a-linked-list
*   Domain      :   Data Structures/Linked Lists
*  Problem Type:  
*  Alogirthm  :   
*  Complexity  :  O(n)
*  Author    :  Atiqur Rahman
*  Status    :  Accepted
*  Notes    :  Logic is to traverse till the tail of linked list
*          Node pointer should point to the last non-null node
*          to make the insertion work
*/

Node* Insert(Node *head, int data)
{
  Node* root = head;

  while (root && root->next)
    root = root->next;

  if (root == NULL) {
    head = new Node({ data, NULL });
  }
  else
    root->next = new Node({ data, NULL });

  return head;
}

// Second approach, minor modification
Node* Insert(Node *head, int data)
{
  if (head == NULL)
    return new Node({ data, NULL });

  Node* root = head;
  while (root->next)
    root = root->next;
  root->next = new Node({ data, NULL });

  return head;
}
