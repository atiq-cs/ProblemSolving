/*
 *	Problem Title:	Problem Title
*	Problem URL:	Problem Link
 *	Problem Type:
 *	Alogirthm	:
 *	Coder		:	Atiqur Rahman
 *	Desc		:	template
 *
 *
 *
 *
 *
 *	Status		:	..
 */

#include <iostream>
#include <string>
#include <sstream>
#include <cmath>
//#define FILE_IO	TRUE

#ifdef FILE_IO
#include <fstream>
#endif
using namespace std;

class ClassName;
void handleIO();

int mainT() {
	handleIO();
	return 0;
}

void handleIO() {
#ifdef FILE_IO
	ofstream outFile("ProblemNo_out.txt");
	streambuf *psbuf = outFile.rdbuf(), *backup;
	backup = cout.rdbuf();     // back up cout's streambuf
	cout.rdbuf(psbuf);
#endif

	ClassName classObj;
	string varName;

	while (cin >> varName) {
		classObj.initClass();
	}
#ifdef FILE_IO
	cout.rdbuf(backup);
	outFile.close();
#endif
}

class ClassName {
private:
	string str;
	int num;
public:
	void initClass();
};

void ClassName::initClass() {
	num = 0;
}

/* example: how to set fixed pionts
memset(arrayName, 255, )
cout.setf (ios::fixed, ios::floatfield);
cout.setf(ios::showpoint);
cout<<setprecision(2)<<sum_c + eps<<endl;
*/
