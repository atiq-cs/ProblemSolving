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
*   http://stackoverflow.com/questions/1219664/c-sharp-reference-type-assignment-vs-value-type-assignment
*                   this is however not possible for strings:
*                   http://stackoverflow.com/questions/9792776/c-sharp-assign-by-reference
*   
A class is a reference type. When an object of the class is created, the variable to which the object is assigned
holds only a reference to that memory. When the object reference is assigned to a new variable, the new variable
refers to the original object. Changes made through one variable are reflected in the other variable because they
both refer to the same data.

A struct is a value type. When a struct is created, the variable to which the struct is assigned holds the
struct's actual data. When the struct is assigned to a new variable, it is copied. The new variable and the
original variable therefore contain two separate copies of the same data. Changes made to one copy do not
affect the other copy.
draft at bottom
ref: https://msdn.microsoft.com/en-us/library/vstudio/ms173109(v=vs.140).aspx
***************************************************************************/
public class Solution
{
    // iterative solution
    public ListNode ReverseList(ListNode head)
    {
        ListNode currentNode = head;
        ListNode previousNode = null;

        while (currentNode != null)
        {
            // save current's next because we are updating this
            ListNode tempNode = currentNode.next;
            // reverse current's next pointer
            currentNode.next = previousNode;
            // move forward previous
            previousNode = currentNode;
            // move forward current
            currentNode = tempNode;
        }
        // previousNode becomes the head at the end of the loop, all the time
        return previousNode;
    }
}

/* say I have 3 -> 4 -> 5

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
