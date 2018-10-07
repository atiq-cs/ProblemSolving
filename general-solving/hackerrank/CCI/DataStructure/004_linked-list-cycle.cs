/***************************************************************************
* Title       : Linked Lists: Detect a Cycle
* URL         : https://www.hackerrank.com/challenges/ctci-linked-list-cycle
* Date        : Sep 7 2017
* Complexity  : O(n), Space O(1)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : Linear checking of cycle on a linked list
* Same        : hackerrank/data-structures/detect-whether-a-linked-list-
*               contains-a-cycle.cpp
* meta        : tag-linked-list, tag-easy
***************************************************************************/

bool has_cycle(Node* head) {
  if (head == NULL)
    return false;
  Node* slowPointer = head;
  Node* fastPointer = head;
  do {
    slowPointer = slowPointer->next;
    fastPointer = fastPointer->next;
    if (fastPointer == NULL)
      return false;
    fastPointer = fastPointer->next;
  } while (slowPointer && fastPointer && slowPointer != fastPointer);
  return slowPointer == fastPointer;
}
