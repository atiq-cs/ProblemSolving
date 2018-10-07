/*
*  Problem Name:  Print the elements of a linked list
*  Problem No  :  https://www.hackerrank.com/challenges/reverse-a-linked-list
*   Domain      :   Data Structures/Linked Lists
*  Problem Type:  
*  Alogirthm  :   
*  Complexity  :  O(n)
*  Author    :  Atiq Rahman
*  Status    :  Accepted
*  Notes    :  
*/

void Print(Node *root)
{
  while (root) {
    std::cout << root->data << std::endl;
    root = root->next;
  }
}
