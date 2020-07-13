/***************************************************************************************************
* Title : Detect Cycle
* URL   : https://www.hackerrank.com/challenges/detect-whether-a-linked-list-contains-a-cycle
* Date  : 2015-09-12
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : runner method
* meta  : tag-ds-linked-list
***************************************************************************************************/

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
