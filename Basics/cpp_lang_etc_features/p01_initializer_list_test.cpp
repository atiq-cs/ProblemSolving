#include <iostream>
#include <initializer_list>
using namespace std;

int dmain() {
    initializer_list<int> il({ 97, 101, 103 });

    for (auto x : il) {
        cout << " " << x << endl;
    }

    initializer_list<int>::iterator iter = il.begin();

    // as suggest on page 867 this works
    cout << "subscript loop: " << endl;
    for (int i = 0; i < il.size(); i++) {
        cout << "On index " << i << " element is " << iter[i] << endl;
    }

    // but this does not work, gives a compile error saying no operator []
    /* for (int i = 0; i < il.size(); i++) {
    cout << "On index " << i << " element is " << il[i] << endl;
    } */


    return 0;
}
