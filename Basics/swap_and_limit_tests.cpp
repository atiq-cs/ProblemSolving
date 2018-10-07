/*
*  Problem Title:   Swap demonstration (Data structure and int limit tests)
*  Author    :  Atiq Rahman
*  Email    :  atiqcs 'at' outlook 'dot' com
*  Date    :  2015-05-21
*  Desc    :  All things swap (testing overflow with approaches)
*          Approach 1: using temporary variable
*          Approach 2: using X-OR
*          Approach 3: using Subtraction and addition
*          Approach 4: using multiplication and division
*
*          Test environment: Visual Studio 2013
*/

#include <iostream>

/* using temporary variable,
  the simple and best method
  better depend on compiler for optimization on this
  */
void swap_method1(int &x, int &y) {
  int tmp = x;
  x = y;
  y = tmp;
}

/* Swap implementation using X-OR
  Problem: if called with same variable as both parameters first X-OR result becomes zero
  Detail explanation here:
http://stackoverflow.com/questions/30419394/why-does-this-swap-using-simple-addition-and-subtraction-wont-overflow/
*/
void swap_method2(int &x, int &y) {
  if (x != y) {
    x ^= y;
    y ^= x;
    x ^= y;
  }
}

/* using using Subtraction and addition
  does not really overflow
*/
void swap_method3(int &x, int &y) {
  x += y;
  y = x - y;
  x -= y;
}

/* using multiplication and division
  be aware that multiplication result might be 0
*/
void swap_method4(int &x, int &y) {
  if (x != y) {
    x *= y;
    if (y == 0)
      return;
    y = x / y;
    if (y == 0)
      return;
    x /= y;
  }
}

/* We demonstrate the functions we wrote above for swap */
int main() {
  int a = 10;  int b = 15;

  std::cout << std::endl << "Size of integer in this system is: " << sizeof(int) << " bytes" << std::endl;
  std::cout << "Before swap " << "a = " << a << ", b=" << b << std::endl;
  std::swap(a, b);
  std::cout << "After applying standard library swap method " << "a = " << a << ", b=" << b << std::endl;
  swap_method1(a, b);
  std::cout << "After applying our  swap method 1 " << "a = " << a << ", b=" << b << std::endl;
  swap_method2(a, b);
  std::cout << "After applying our  swap method 2 " << "a = " << a << ", b=" << b << std::endl;
  swap_method3(a, b);
  std::cout << "After applying our  swap method 3 " << "a = " << a << ", b=" << b << std::endl;
  swap_method4(a, b);
  std::cout << "After applying our  swap method 4 " << "a = " << a << ", b=" << b << std::endl;

  /*Testing with maximum limit, adding a small number with it that will only use the sign bit when added*/
  a = 0x7FFFFFFF;    // a is 2^31-1
  b = 15;
  std::cout << std::endl << "Testing integer overflow:" << std::endl;
  std::cout << "Before swap " << "a = " << a << ", b=" << b << std::endl;
  std::swap(a, b);
  std::cout << "After applying standard library swap method " << "a = " << a << ", b=" << b << std::endl;
  swap_method1(a, b);
  std::cout << "After applying our  swap method 1 " << "a = " << a << ", b=" << b << std::endl;
  swap_method2(a, b);
  std::cout << "After applying our  swap method 2 " << "a = " << a << ", b=" << b << std::endl;
  swap_method3(a, b);
  std::cout << "After applying our  swap method 3 " << "a = " << a << ", b=" << b << std::endl;
  swap_method4(a, b);
  std::cout << "After applying our  swap method 4 " << "a = " << a << ", b=" << b << std::endl;

  /*
    From this test on Visual Studio we can conclude that as we are using the sign bit integer overflow does not
    occur. However, as the sign bit is used the representation becomes what we get from 2's complement
    of the number

    The maxium sum of these two can be only 2^33-1 upto which overflow won't occur

    To show the number properly we just need to cast it into )unsigned int)
  */
  a = 0x7FFFFFFF; //b = 0x80000000; // a is 2^31-1
  b = a+1;        // b is 2^31
  std::cout << std::endl << "Testing integer overflow with sign bit:" << std::endl;
  // std::cout << "Before swap " << "a = " << a << ", b=-" << get_twos_complement(b) << std::endl;
  std::cout << "Before swap " << "a = " << a << ", b=" << (unsigned int) b << std::endl;
  std::swap(a, b);
  std::cout << "After applying standard library swap method " << "a = " << (unsigned int)a << ", b=" << b << std::endl;
  swap_method1(a, b);
  std::cout << "After applying our  swap method 1 " << "a = " << a << ", b=" << (unsigned int)b << std::endl;
  swap_method2(a, b);
  std::cout << "After applying our  swap method 2 " << "a = " << (unsigned int)a << ", b=" << b << std::endl;
  swap_method3(a, b);
  std::cout << "After applying our  swap method 3 " << "a = " << a << ", b=" << (unsigned int)b << std::endl;
  swap_method4(a, b);
  std::cout << "After applying our  swap method 4 " << "a = " << (unsigned int)a << ", b=" << b << std::endl;

  /* this cannot be handled by 32 bits or 4 bytes if summed together
        But surprisingly these also works
        method using multiplication and division fails b becomes 0
  */
  a = 0x7FFFFFFF;    // a is 2^31-1
  b = 0x80000001;    // b is 2^31+1
  std::cout << std::endl << "Testing integer overflow with sign bit:" << std::endl;
  std::cout << "Before swap " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  std::swap(a, b);
  std::cout << "After applying standard library swap method " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  swap_method1(a, b);
  std::cout << "After applying our  swap method 1 " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  swap_method2(a, b);
  std::cout << "After applying our  swap method 2 " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  swap_method3(a, b);
  std::cout << "After applying our  swap method 3 " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  swap_method4(a, b);
  std::cout << "After applying our  swap method 4 " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;

  /* Won't overflow, these are simply two integer numbers -1 and -2, after addition result is -3 */
  a = 0xFFFFFFFF;    // a is 2^32-1 = 4294967295
  b = 0xFFFFFFFE;    // b is 2^32-2 = 4294967294
  std::cout << std::endl << "Testing integer overflow, sum has 1 bit outside limit" << std::endl;
  std::cout << "Before swap " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  std::swap(a, b);
  std::cout << "After applying standard library swap method " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  swap_method1(a, b);
  std::cout << "After applying our  swap method 1 " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  swap_method2(a, b);
  std::cout << "After applying our  swap method 2 " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  swap_method3(a, b);
  std::cout << "After applying our  swap method 3 " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;
  swap_method4(a, b);
  std::cout << "After applying our  swap method 4 " << "a = " << (unsigned int)a << ", b=" << (unsigned int)b << std::endl;

  return 0;
}
