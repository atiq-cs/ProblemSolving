/***************************************************************************
*	Problem Name:	Reverse a Linked Lists Recursively, Prints 
*	Problem URL:	http://leetcode.com/2010/04/reversing-linked-list-iteratively-and.html
*	Occassion:		Snow day in StonyBrook second day of class cancelled for inclement weather
*	Date:			January 27, 2015
*
*	Data Structure:	Recursion, Linked Lists
*	Desc:			Implements following,
*						Prints a linked ilst in reverse order (using recursion)
*						Reverses a linked ilst (using recursion)
*	Author:			Atiqur Rahman
*	Notes:					
*
***************************************************************************/

#include <iostream>

class LL {
public:
	int itemValue;
	LL *itemNext;
};

// global head used by recursive reverser function
LL* gHead;

class myLinkedList {
public:
	myLinkedList();
	~myLinkedList();
	void Create();
	void Reverse();
	void PrintList();
	void PrintReverse();

protected:
	void addItem(int n);
	LL *head;
	LL *current;
};

// The constructor
myLinkedList::myLinkedList() {
	head = NULL;
	gHead = NULL;
	current = NULL;
}

// The destructor
myLinkedList::~myLinkedList() {
	LL *temp = NULL;
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

void myLinkedList::addItem(int n) {
	// first time
	if (head == NULL) {
		current = new LL;
		current->itemValue = n;
		current->itemNext = NULL;
		head = current;
	}
	// not first time
	else {
		current->itemNext = new LL;
		current = current->itemNext;
		current->itemValue = n;
		current->itemNext = NULL;
	}
}

void myLinkedList::Create() {
	addItem(1);
	addItem(2);
	addItem(3);
	addItem(4);
	addItem(5);
}

void myLinkedList::Reverse() {
	void RecReverse(LL* head);
	RecReverse(head);
    if (head) {
        head->itemNext = NULL;
        head = gHead;
    }
	gHead = NULL;
}

/*
	Displays the linked list in its order
*/
void myLinkedList::PrintList() {
	LL* current = head;
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
void myLinkedList::PrintReverse() {
	void RecPrintReverse(LL* head);
	LL* fastPointer = head;
	LL* slowPointer = head;

	if (head == NULL) {
		std::cout << "Linked list is empty. Please add items." << std::endl;
		return;
	}
	RecPrintReverse(head);
}

int main() {
	myLinkedList demoLL;
	demoLL.Create();
	std::cout << "Before performing recursive reverse we get," << std::endl;
	demoLL.PrintList();

	demoLL.Reverse();
	std::cout << std::endl << "After performing recursive reverse we get," << std::endl;
	demoLL.PrintList();

	std::cout << std::endl << "Recursive reverse print gives," << std::endl;
	demoLL.PrintReverse();
	return 0;
}

void RecPrintReverse(LL* head) {
	if (head == NULL)
		return;
	RecPrintReverse(head->itemNext);
	std::cout << "item " << head->itemValue << std::endl;
}


void RecReverse(LL* head) {
	if (head == NULL)
		return;
	if (head->itemNext == NULL) {
		if (gHead == NULL) {
			gHead = head;
			// std::cout << "head set to " << head->itemValue << std::endl;
		}
		return;
	}
	RecReverse(head->itemNext);
	head->itemNext->itemNext = head;
	// head->itemNext = NULL;		// can do this without recursion too
}
