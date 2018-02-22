// Lambda expressions example
// Lambda expressions ref: https://msdn.microsoft.com/en-us/library/dd293608.aspx
// even_lambda.cpp
// compile with: cl /EHsc /nologo /W4 /MTd
// meta: tag-bloomberg

#include <algorithm>
#include <iostream>
#include <vector>
using namespace std;

int main() {
  // Create a vector object that contains 10 elements.
  vector<int> v;
  for (int i = 1; i < 10; ++i)
    v.push_back(i);

  // Count the number of even numbers in the vector by 
  // using the for_each function and a lambda.
  int evenCount = 0;
  for_each(v.begin(), v.end(), [&evenCount](int n) {
    cout << n;
    if (n % 2 == 0) {
      cout << " is even " << endl;
      ++evenCount;
    }
    else {
      cout << " is odd " << endl;
    }
  });

  // Print the count of even numbers to the console.
  cout << "There are " << evenCount
    << " even numbers in the vector." << endl;

  // lambda sort: left, right
  std::vector<int> nums = { 10, 9, 2 ,3, 7, 4 ,5, 6 };
  std::sort(nums.begin(), nums.end(), [](const int &left, const int &right) ->
    bool {
    if (left & 1 && right & 1) // both are odd
      return left < right;
    else if (left & 1) // left is odd
      return false;
    else if (right & 1) // right is odd
      return true;
    // both are even
    return left < right;
  }
  );

  std::cout << "Number list: " << listToString(nums) << std::endl;
}
