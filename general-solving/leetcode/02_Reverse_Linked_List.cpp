/*******************************************************
*		Problem Name:			Reverse a Linked Recursively
*		Problem URL:			leetcode
*		Occassion:				Christmas Day
*		Date:					December 25, 2014
*		Template revision:		002, OOP
*
*		Algorithm:
*		Special Case:
*		Judge Status:
*		Author:					Saint Atique
*		Notes:					Naive Solution
*
*******************************************************/

#include <iostream>
using namespace std;

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
		cout << "deleted element " << i << endl;
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
	head->itemNext = NULL;
	head = gHead;
	gHead = NULL;
}

void myLinkedList::PrintReverse() {
	void RecPrintReverse(LL* head);
	LL* fastPointer = head;
	LL* slowPointer = head;

	if (head == NULL) {
		cout << "Linked list is empty. Please add items." << endl;
		return;
	}
	RecPrintReverse(head);
}

int main() {
	myLinkedList demoLL;
	demoLL.Create();
	demoLL.PrintReverse();
	demoLL.Reverse();
	demoLL.PrintReverse();
	return 0;
}

void RecPrintReverse(LL* head) {
	if (head == NULL)
		return;
	RecPrintReverse(head->itemNext);
	cout << "item " << head->itemValue << endl;
}


void RecReverse(LL* head) {
	if (head == NULL)
		return;
	if (head->itemNext == NULL) {
		if (gHead == NULL) {
			gHead = head;
			// cout << "head set to " << head->itemValue << endl;
		}
		return;
	}
	RecReverse(head->itemNext);
	head->itemNext->itemNext = head;
	// head->itemNext = NULL;		// can do this without recursion too
}
