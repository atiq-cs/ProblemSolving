/*****************************************************************
	Author Name	:	Saint Linux,
	Location		:	University of Dhaka,
	Problem Name:	Tree Recovery
	Algo				:	Recursion
	Description		:	Recursively placing root to right gives the output result
*****************************************************************/

#include <iostream>
#include <cstring>
using namespace std;

char preord[30], inord[30];
int root_pos;		// position of root in preorder string

int main () {

	void make_post(int start, int end);
	
	freopen("536.in", "r", stdin);

	while ((scanf("%s %s",preord, inord)) == 2) {
	//	initialize root position for every input
		root_pos = 0;
		make_post(0, strlen(inord)-1);
		puts(inord);
	}

	fclose(stdin);
	return 0;
}

int tmp,i;			// to save space declared globally

void make_post(int start, int end) {
	/*************************************************
	cout<<"debug string: "<<inord<<endl;
	cout<<"start: "<<start<<" end: "<<end<<endl;
	cout<<"pre root position:  "<<root_pos<<endl<<endl;
	getchar();
	*************************************************/

	if (start >= end) {			// Termination case
		if (start == end)		//  we should not increment when no tree is found left or right
			root_pos++;	
		return;
	}

	int pos;

	for (pos = start; preord[root_pos] != inord[pos]; pos++);	// get the root's position in inorder string
	root_pos++;

//	cout<<"pos: "<<pos<<endl;
	// move root to right to maintain order left, right, root for postorder output
	tmp = inord[pos];

	for (i=pos; i<end;i++)
		inord[i] = inord[i+1];

	inord[i] = tmp;

//	cout<<"inord: "<<inord<<endl;

//	modify left
	make_post(start, pos - 1);
//	cout<<"exit recursion left"<<endl;

//	modify right
	make_post(pos, end - 1);
//	cout<<"exit recursion right"<<endl;
}
