/***************************************************************************
*   Problem Name:   Reverse Linked List
*   Problem URL :   https://leetcode.com/problems/reverse-linked-list/

*   Date        :   July 29, 2015
*   Desc        :   Iteratively traverse the linked list and keeps reversing the next pointers
*                   consider when changing the next pointer the next chain is lost, so use a temporary
*                   variable to keep previous node before losing chain...
*
*   Complexity  :   O(n)
*   Author      :   Atiq Rahman
*   Status      :   Accepted (0.172s)
*   Notes       :   Technical - Understanding of reference assignment, ref: 
*      http://stackoverflow.com/q/1219664
*     This, however, is not possible for strings(immutable)
*      http://stackoverflow.com/q/9792776
*   
A class is a reference type. When an object of the class is created, the
variable to which the object is assigned holds only a reference to that memory.
When the object reference is assigned to a new variable, the new variable
refers to the original object. Changes made through one variable are reflected
in the other variable because they both refer to the same data.

A struct is a value type. When a struct is created, the variable to which the
struct is assigned holds the struct's actual data. When the struct is assigned
to a new variable, it is copied. The new variable and the original variable
therefore contain two separate copies of the same data. Changes made to one
copy do not affect the other copy.
draft at bottom
ref: https://msdn.microsoft.com/en-us/library/vstudio/ms173109.aspx
***************************************************************************/
public class Solution {
  // iterative solution
  ListNode ReverseList(ListNode head) {
    ListNode current = head;
    ListNode prev = null;

    while (current != null) {
      // save current's next because we are gonna move this pointer/refreence forward
      ListNode temp = current.next;
      // reverse current's next pointer
      current.next = prev;
      // move forward previous pointer
      prev = current;
      // move forward current's next pointer
      current.next = prev;  
    }
	  return prev;
  }
}

/* Consider following example,
 3 -> 4 -> 5

Node previous = null;

first iteration
head = 3
 current = 3
 head = 4 (next of 3)
 3 's next set to null
 previous = 3

second iteration
 current = 4
 head = 5
 4's next set to 3
 previous = 4
 
3rd iteration
 current = 5
 head = null
 current's next set to 4
 previous = 5
*/
