/***************************************************************************************************
* Title : Print the elements of a linked list
* URL   : https://www.hackerrank.com/challenges/reverse-a-linked-list
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
* meta  : tag-ds-linked-list
***************************************************************************************************/

void Print(Node *root)
{
  while (root) {
    std::cout << root->data << std::endl;
    root = root->next;
  }
}
