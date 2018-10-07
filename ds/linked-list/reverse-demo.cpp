/***************************************************************************
* Title : Reverse a Linked Lists Recursively, Prints as well
* URL   :
* Date  : 2015-01-27
* Author: Atiq Rahman
* Ref   : https://articles.leetcode.com/reversing-linked-list-iteratively-and/
* Notes : Implements following,
*   Prints a linked ilst in reverse order (using recursion)
*   Reverses a linked ilst (using recursion)
*   Reverse and the recursive method are the ones we need for leetcode problem
*
*   would still require moving some properties inside methods such as head and
*   current.
*   Instead of pointers may be we can use smart pointers:
*    https://msdn.microsoft.com/en-us/library/hh279674.aspx
* rel   : https://leetcode.com/problems/reverse-linked-list
* meta  : tag-recursion, tag-linked-list
***************************************************************************/
#include <iostream>

class ListNode {
public:
  int itemValue;
  ListNode *itemNext;
};

class LinkedListDemo {
public:
  LinkedListDemo();
  ~LinkedListDemo();
  void Run();
  ListNode* Reverse();
  void PrintList(ListNode* current);
  void PrintReverse();

private:
  ListNode *gHead;

  void addItem(int n);
  ListNode *head;
  ListNode *current;
  void RecPrintReverse(ListNode* head);
  void RecReverse(ListNode* head);
};

// The constructor
LinkedListDemo::LinkedListDemo() {
  head = NULL;
  gHead = NULL;
  current = NULL;
}

// The destructor
LinkedListDemo::~LinkedListDemo() {
  ListNode *temp = NULL;
  current = head;
  int i = 0;
  while (current) {
    temp = current;
    i = current->itemValue;
    current = current->itemNext;
    delete temp;
    std::cout << "deleted element " << i << std::endl;
  }
}

void LinkedListDemo::addItem(int n) {
  // first time
  if (head == NULL) {
    current = new ListNode;
    current->itemValue = n;
    current->itemNext = NULL;
    head = current;
  }
  // not first time
  else {
    current->itemNext = new ListNode;
    current = current->itemNext;
    current->itemValue = n;
    current->itemNext = NULL;
  }
}

void LinkedListDemo::Run() {
  addItem(1);
  addItem(2);
  addItem(3);
  addItem(4);
  addItem(5);

  std::cout << "Before performing recursive reverse we get," << std::endl;
  PrintList(head);

  std::cout << std::endl << "After performing recursive reverse we get," << std::endl;
  PrintList(Reverse());

  std::cout << std::endl << "Recursive reverse print gives," << std::endl;
  PrintReverse();
}

ListNode* LinkedListDemo::Reverse() {
  RecReverse(head);
  if (head) {
    head->itemNext = NULL;
    head = gHead;
  }
  gHead = NULL;
  return head;
}

void LinkedListDemo::RecReverse(ListNode* head) {
  if (head == NULL)
    return;
  if (head->itemNext == NULL) {
    if (gHead == NULL)
      gHead = head;
    return;
  }
  RecReverse(head->itemNext);
  head->itemNext->itemNext = head;
  // head->itemNext = NULL;    // can do this without recursion too
}

/*
Displays the linked list in its order
*/
void LinkedListDemo::PrintList(ListNode* current) {
  std::cout << "Linked list: ";
  while (current) {
    std::cout << " " << current->itemValue;
    current = current->itemNext;
  }
  std::cout << std::endl;
}

/*
Displays the linked list in reverse order
*/
void LinkedListDemo::PrintReverse() {
  /* detect cyle if exists
  ListNode* fastPointer = head;
  ListNode* slowPointer = head;  */

  if (head == NULL) {
    std::cout << "Linked list is empty. Please add items." << std::endl;
    return;
  }
  RecPrintReverse(head);
}

void LinkedListDemo::RecPrintReverse(ListNode* head) {
  if (head == NULL)
    return;
  RecPrintReverse(head->itemNext);
  std::cout << "item " << head->itemValue << std::endl;
}


int main() {
  LinkedListDemo demo;
  demo.Run();
  return 0;
}
