/***************************************************************************************************
* Title : Equations
* URL   : 727
* Notes : Infix to Postfix Conversion
*   In this problem the ascending order of precedence of operators is: (- +), (* /) - and + have
*   same level of precedence as well as * and / have
*   Popping rules, even if precedence is same operator has to be popped to expression & of course
*   aintain left to right evaluation
* meta  : tag-ds-stack
***************************************************************************************************/
#include <cstdio>
#include <cctype>
#include <cstring>
#include <vector>
#include <stack>
using namespace std;

char oprlist[] = "-+*/";

bool greaterprecedence(char ch, char oprtr) {
  int i, a, b;
  if ((ch == '/' && oprtr == '*') || (ch == '+' && oprtr == '-'))
    return true;

  for (i=0; i<strlen(oprlist); i++)
    if (ch == oprlist[i]) {
      a = i;
      break;
    }

  if (i == strlen(oprlist))
    a = 0;

  for (i=0; i<strlen(oprlist); i++)
    if (oprtr == oprlist[i]) {
      b = i;
      break;
    }

  if (i == strlen(oprlist))
    b = 0;

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
        if (ExpStack.empty())
          ExpStack.push(ch);
        else {
          while(!ExpStack.empty()) {
            oprtr = ExpStack.top();
            if (!greaterprecedence(ch, oprtr)) {
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
