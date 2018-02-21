/*******************************************************
*		Problem Name:			Equations
*		Problem ID:				727
*		Occassion:				Offline Solving
*
*		Algorithm:				Infix to Postfix Conversion
*		Special Case:			
*		Judge Status:			
*		Author:					Atiqur Rahman
*		Notes:					In this problem the ascending order of precedence
*								of operators is: (- +), (* /)
*								- and + have same level of precedence as well as * and / have

*								Popping rules: even if precedence is same operator has to be popped to expression & of course
*								maintain left to right evaluation
*								
*******************************************************/
//#include <iostream>
#include <cstdio>
#include <cctype>
#include <cstring>
//#include <new>
#include <vector>
#include <stack>
//#include <map>
//#include <algorithm>
//#include <iomanip>//for cout formatting
//#define	INF 2147483648
//#define EPS 1e-8
using namespace std;

char oprlist[] = "-+*/";

bool greaterprecedence(char ch, char oprtr) {
	int i, a, b;
	if ((ch == '/' && oprtr == '*') || (ch == '+' && oprtr == '-'))
		return true;
	//if ((ch == '+' && oprtr == '-') || (ch == '-' && oprtr == '+'))
	//	return false;

	for (i=0; i<strlen(oprlist); i++) {
		if (ch == oprlist[i]) {
			a = i;
			break;
		}
	}
	if (i == strlen(oprlist)) {
		//printf("Error 1 %c\n", ch);
		a = 0;
	}
	for (i=0; i<strlen(oprlist); i++) {
		if (oprtr == oprlist[i]) {
			b = i;
			break;
		}
	}
	if (i == strlen(oprlist)) {
		//printf("Error 2 %c\n", oprtr);
		b = 0;
	}

	return (b >= a);
}

bool isoprtr(char ch) {
	int i;

	for (i=0; i<strlen(oprlist); i++)
		if (ch == oprlist[i])
			break;
	if (i == strlen(oprlist))
		return false;
	return true;
}

int main() {
	freopen("727_in.txt", "r", stdin);
	freopen("727_out.txt", "w", stdout);

	bool wasnewline;
	stack<char> ExpStack;
	int explen;
	char expstr[100], ch, oprtr;

	scanf("%d", &explen);

	// initialization
	explen = 0;
	wasnewline = false;


	while ((ch=getchar()) != EOF ) {
		if (ch == '\n') {
			if (wasnewline == true) {
				while (!ExpStack.empty()) {
					expstr[explen++] = ExpStack.top();
					ExpStack.pop();
				}
				expstr[explen] = '\0';
				if (explen)
					printf("%s\n\n", expstr);
				// initialize new test case
				explen = 0;
				wasnewline = false;
			}
			else
				wasnewline = true;
		}
		else {
			wasnewline = false;
			if (isalnum(ch)) {
				// insert operands into string
				expstr[explen++] = ch;
			}
			else if (isoprtr(ch)) {
				// do operations for operator
				if (ExpStack.empty()) {
					//printf("Pushing char %c\n", ch);
					ExpStack.push(ch);
				}
				else {
					while(!ExpStack.empty()) {
						oprtr = ExpStack.top();
						if (!greaterprecedence(ch, oprtr)) {
							//printf("Pushing char on greater prec %c\n", ch);
							ExpStack.push(ch);
							break;
						}
						else if (oprtr == '(') {
							ExpStack.push(ch);
							break;
						}
						else
							expstr[explen++] = oprtr;
						ExpStack.pop();
					}
					if (ExpStack.empty())
						ExpStack.push(ch);
				}
			}
			else if (ch == '(')
				ExpStack.push(ch);
			else if (ch == ')') {
				while(!ExpStack.empty()) {
					oprtr = ExpStack.top();
					ExpStack.pop();
					if (oprtr == '(')
						break;
					else
						expstr[explen++] = oprtr;
				}
			}
		}
	}
	while (!expstack.empty()) {
		expstr[explen++] = expstack.top();
		expstack.pop();
	}

	expstr[explen] = '\0';
	if (explen)
		printf("%s\n", expstr);
	
	return 0;
}
