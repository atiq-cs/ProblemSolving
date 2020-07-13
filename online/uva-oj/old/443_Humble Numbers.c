/***************************************************************************************************
* Title : Humble Numbers
* Algo  : DP, Same as Ugly Numbers, Precompute and output for queries
* rel: 'uva-online-judge/136_Ugly_Numbers.cpp'
* meta  : tag-algo-dp
***************************************************************************************************/

#include <iostream>

int main() {
  unsigned i, j, humble[5842];
  humble[0] = 1;

  for (i = 1; i < 5843; i++) {
    humble[i] = 2000000001;

    for (j = 0; j < i; j++) {
      if (humble[j] * 2 > humble[i - 1])
      {
        if (humble[j] * 2 < humble[i])
          humble[i] = humble[j] * 2;
      }
      else if (humble[j] * 3 > humble[i - 1])
      {
        if (humble[j] * 3 < humble[i])
          humble[i] = humble[j] * 3;
      }
      else if (humble[j] * 5 > humble[i - 1])
      {
        if (humble[j] * 5 < humble[i])
          humble[i] = humble[j] * 5;
      }
      else if (humble[j] * 7 > humble[i - 1])
      {
        if (humble[j] * 7 < humble[i])
          humble[i] = humble[j] * 7;
      }
    }
  }

  short n;
  while (std::cin >> n && n) {
    if (n % 10 == 1 && n % 100 != 11)
      std::cout << "The " << n << "st humble number is " << humble[n - 1] << ".\n";
    else if (n % 10 == 2 && n % 100 != 12)
      std::cout << "The " << n << "nd humble number is " << humble[n - 1] << ".\n";
    else if (n % 10 == 3 && n % 100 != 13)
      std::cout << "The " << n << "rd humble number is " << humble[n - 1] << ".\n";
    else std::cout << "The " << n << "th humble number is " << humble[n - 1] << ".\n";
  }

  return 0;
}
