/*
    Problem     : https://www.hackerrank.com/challenges/reverse-a-linked-list/copy-from/12165393
    Description :
                  Reverses a linked list
                   Basic code
                    solved and saved for reference

    Complexity  : O(n)

    Status      :   Accepted
*/

/*
  Reverse a linked list and return pointer to the head
  The input list will have at least one element  
  Node is defined as 
  struct Node
  {
     int data;
     struct Node *next;
  }
*/

Node* Reverse(Node *head)
{
    // Complete this method
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
