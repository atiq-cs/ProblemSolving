/*
* Name: vector implementation demo
* URL : 
* Date: 2007-03-18
* Note: sample dynamically growable list implementation
*   grows double each time it hits the capacity
*   size() method is declared constant to support caling it from 'const vector&'
*
*   push_back is simple supporting growing
*   insert method inserts in provided 0 based index position instead of using 
*   an iterator
*   note how delete operator is called for the array
*   does not implement handful of methods that STL vector supports
* meta: tag-cpp, tag-bloomberg
*/
#include<iostream>

template <class T>
class vector {
private:
  size_t capacity;
  size_t isize;
  T* items;

public:
  vector():
    items(NULL),
    isize(0)
  {
  }
  
  void push_back(const T& item) {
    if (full())
      grow();
    items[isize++] = item;
  }
  
  void insert(size_t pos, const T& item) {
    if (full())
      grow();
    move(pos);
    items[pos] = item;
    isize++;
  }
  
  void move(size_t pos) {
    for (size_t i=isize; i>pos; i--)
      items[i] = items[i-1];
  }
  
  constexpr bool full() {
    return items == NULL || isize == capacity;
  }
  
  void grow() {
    // handle memory exceptions
    if (items == NULL) {
      capacity = 8;
      items = new T[capacity];
      return;
    }
    capacity <<= 1;
    T* new_items = new T[capacity];
    for (size_t i=0; i<capacity/2; i++)
    new_items[i] = items[i];
    delete[] items;
    items = new_items;
  }

  T& operator[] (size_t i) {
    // exception if empty
    return items[i];
  }

  vector(const vector& copy):
    isize(copy.isize),
    capacity(copy.capacity),
    items(new T[isize])
  {
    std::cout << "copy cons called" << std::endl;
    for (size_t i = 0; i < isize; i++)
      items[i] = copy.items[i];
  }

  vector& operator= (const vector& other) {
    std::cout << "assignment overload called" << std::endl;
    clear();
    for (size_t i = 0; i < other.size(); i++)
      push_back(other.items[i]);
    return *this;
  }

  size_t size() const { return isize; }

  void clear() { isize = 0; delete[] items; items = NULL; }

  ~vector() {
    if (items)
      delete[] items;
  }
};

// main function to drive the demo
int main() {
  vector<int> nums;
  nums.push_back(1);
  nums.push_back(3);
  nums.insert(1, 2);

  for (size_t i=0; i<nums.size(); i++)
    std::cout << "num " << (i+1) << " = " << nums[i] << std::endl;

  vector<int> nums2 = nums;
  for (size_t i = 0; i<nums2.size(); i++)
    std::cout << "num " << (i + 1) << " = " << nums2[i] << std::endl;

  vector<int> nums3;
  nums3.push_back(5);
  nums3 = nums;
  for (size_t i = 0; i<nums3.size(); i++)
    std::cout << "num " << (i + 1) << " = " << nums3[i] << std::endl;

  return 0;
}
