/*
*    Problem Name: Detect Cycle
*    Problem#   : https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle
*    Date       : Sept 12, 2015
*    Domain     : Data Structures/Linked Lists
*    Type       :    
*    Alogirthm  :   
*    Complexity : O(n)
*    Author     : Atiq Rahman
*    Status     : Accepted
*    Notes      : brief coding *
*/

// Complete this function, assume Node structure
int HasCycle(Node* head)
{
    if (head == NULL)
        return 0;
    Node* slowPointer = head;
    Node* fastPointer = head;
    do {
        slowPointer = slowPointer->next;
        fastPointer = fastPointer->next;
        if (fastPointer == NULL)
            return 0;
        fastPointer = fastPointer->next;
    } while (slowPointer && fastPointer && slowPointer != fastPointer);
    return slowPointer == fastPointer;
}
