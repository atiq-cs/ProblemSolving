/***************************************************************************
* Title : Find duplicates
* URL   : hackerrank.com/contests/filter-cse-it/challenges/find-duplicates
* Date  : 2018-04-06
* Author: Atiq Rahman
* Comp  : O(n), space O(k)
* Status: Accepted
* Notes : This problem asks to find count of duplicate numbers
*   Bloomberg version asks to print number of duplicate numbers
*   For example, if we have
*   1 4 5 1 2 7 9 2 3
*   then bloomberg version asks to print 2 as 2 duplicate numbers found (1 & 2)
* meta  : tag-easy, tag-company-bloomberg, tag-hash-table, tag-interview
***************************************************************************/
#include <iostream>
#include <vector>
#include <fstream>

#define MAX_LIMIT 1000

int countDuplicates(std::vector<int> numbers)
{
  // allocate and initialize to default value 0
  int freq[MAX_LIMIT] = { };
  // memset(freq, 0, sizeof(freq));

  int count = 0;
  // iteration loop on list of numbers
  for (auto num : numbers) {
    // using 0-baesd index so 1 less on index
    freq[num - 1]++;
    if (freq[num - 1] == 2)
      count++;
  }
  return count;
}

int main()
{
  std::ofstream fout("duplicate-1.txt");

  int numbers_size;
  std::cin >> numbers_size;
  std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

  std::vector<int> numbers(numbers_size);
  for (int numbers_i = 0; numbers_i < numbers_size; numbers_i++) {
    int numbers_item;
    std::cin >> numbers_item;
    std::cin.ignore(std::numeric_limits<std::streamsize>::max(), '\n');

    numbers[numbers_i] = numbers_item;
  }

  int res = countDuplicates(numbers);

  fout << res << "\n";

  fout.close();

  return 0;
}

/*
Example input,
8
1
2
2
3
4
3
4
5

*/
