/*
*    Problem Name: Insert a node at the head of a linked list
*    Problem#   : https://www.hackerrank.com/challenges/print-the-elements-of-a-linked-list
*    Domain     : Data Structures/Linked Lists
*    Type       :    
*    Alogirthm  :   
*    Complexity : O(1)
*    Author     : Atiqur Rahman
*    Status     : Accepted
*    Notes      : Concise
*/

Node* Insert(Node *head, int data) {
    Node* root = new Node({ data, NULL });
    root->next = head;
    return root;
}
