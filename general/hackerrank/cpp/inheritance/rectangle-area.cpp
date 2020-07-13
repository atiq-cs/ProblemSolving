/***************************************************************************
* Title : Rectangle Area
* URL   : https://www.hackerrank.com/challenges/rectangle-area
* Date  : 2015-11
* Comp  : 
* Author: Atiq Rahman
* Status: Accepted
* Notes : simple inheritance, overrides single function
*   Where is virtual keyword?
* meta  : tag-inheritance
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
