/***************************************************************************
* Title : The Cat in the Hat
* URL   : https://uva.onlinejudge.org/external/1/p107.pdf
* Date  : 
* Status: Accepted
* Comp  : O(NW) where NW is number of workers
* Notes : Solution derived from a hint from UVA Online Judge Board
*   https://ideone.com/rL1R8a#cmperr
*   look at the bottom for C implementation
* meta  : tag-math
***************************************************************************/
#include <iostream>
#include <cmath>

int main() {
  int Height, Number_Workers, root, Number_Not_Working, Sum_Height;
  double Ratio;

  while (std::cin >> Height >> Number_Workers && (Height || Number_Workers)) {
    if (Height >= Number_Workers) {
      if (Number_Workers == 1) {
        root = 1;
        Number_Not_Working = log(Height) / log(2) + 0.5;
      }
      else {
        Ratio = log((double)Height) / log((double)Number_Workers);

        for (root = 1; root <= Number_Workers; root++)
          if (fabs(pow((double)root, Ratio) - (double)root - 1.0) < 0.001)
            break;

        Number_Not_Working = (Number_Workers - 1) / (root - 1);
      }

      Sum_Height = root * (Height - Number_Workers) + Height;
      std::cout << Number_Not_Working << " " << Sum_Height << std::endl;
    }
  }

  return 0;
}

// C Version, tag-lang-c
#include<stdio.h>
#include<math.h>

int main() {
  int Height, Number_Workers, root, Number_Not_Working, Sum_Height;
  double Ratio;

  while (scanf("%d %d", &Height, &Number_Workers) {
    if (!Height && !Number_Workers)
      break;

    if (Height >= Number_Workers) {
      if (Number_Workers == 1) {
        root = 1;
        Number_Not_Working = log(Height) / log(2) + 0.5;
      }
      else {
        Ratio = log((double)Height) / log((double)Number_Workers);
        for (root = 1; root <= Number_Workers; root++)
          if (fabs(pow((double)root, Ratio) - (double)root - 1.0) < 0.001)
            break;
        Number_Not_Working = (Number_Workers - 1) / (root - 1);
      }

      Sum_Height = root * (Height - Number_Workers) + Height;
      printf("%d %d\n", Number_Not_Working, Sum_Height);
    }
  }

  return 0;
}
