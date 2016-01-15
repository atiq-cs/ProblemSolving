/***************************************************************************
* Problem Name: Rectangle Area
* Problem URL : https://www.hackerrank.com/challenges/rectangle-area
* Date        : Nov 2015
* Complexity  : 
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : simple inheritance, overrides single function
*               Where is virtual keyword?
* meta        : tag-inheritance
***************************************************************************/
class Rectangle {
protected:
    int width;
    int height;
public:
    void Display() { cout << width << " " << height << endl; }
};


class RectangleArea : public Rectangle {
public:
    void Input() { cin >> width >> height; }
    void Display() { cout << width*height << endl; }
};
