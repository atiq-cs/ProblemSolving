/***************************************************************************
* Problem Name: Find Merge Point of Two Lists
* Problem URL : https://www.hackerrank.com/challenges/find-the-merge-point-of-two-joined-linked-lists
* Date        : Jan 4 2016
* Complexity  : O(N)
* Author      : Atiq Rahman
* Status      : Accepted
* Desc        : Tortoise approach - linked list cycle detection
* Notes       : start with headA,
*               when we reach tail of headA try with headB
*               - if length of both linked lists are equal then it finds in a simple iteration
*               - if length does not not match, more than one iteration would be required
*               But converges in both cases
* meta        : tag-linked-list
***************************************************************************/

int FindMergeNode(Node *headA, Node *headB) {
    Node* currentA = headA;
    Node* currentB = headB;

    while (currentA != currentB) {
        currentA = currentA->next;
        currentB = currentB->next;
        if (!currentA)
            currentA = headB;
        if (!currentB)
            currentB = headA;
    }
    return currentA->data;
}
