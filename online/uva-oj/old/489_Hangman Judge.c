/***************************************************************************************************
* Title : Hangman Judge
* URL   : 489
* Occasn: First year assignment
* Comp  : O (n lg n)
* Notes : String matching
*   Unique wrong guesses, unique right guess, instant detection of win or loss in any moments
* ref   : http://acm.uva.es/board/viewtopic.php?f=5&t=2377&p=22463&hilit=489&sid=3a5fc4177ea199c599888561a0c31a84#p22463
* meta  : tag-string
***************************************************************************************************/
#include <cstdio>
#include <cstring>
using namespace std;


int main() {
  char puzzle[1000], guess[1000];
  bool fmatch, used[130], fwin, flose;

  int i, j, lose, matches, roundNo;

  while (scanf("%d", &roundNo) && roundNo != -1) {
    scanf("%s %s", puzzle, guess);

    lose = 0;
    matches = 0;
    fwin = flose = false;
    memset(used, 0, 123);

    for (i = 0; i < strlen(guess); i++) {
      if (used[guess[i]] == false) {
        used[guess[i]] = true;
        fmatch = false;
        for (j = 0; j < strlen(puzzle); j++) {
          if (guess[i] == puzzle[j]) {
            fmatch = true;
            matches++;
            if (flose == false && matches == strlen(puzzle)) {
              fwin = true;
              break;
            }
          }
        }

        if (fmatch == false) {
          lose++;
          if (lose == 7) {
            flose = true;
            break;
          }
        }
      }

      if (fwin || flose)
        break;
    }

    printf("Round %d\n", roundNo);

    if (lose > 6 && flose)
      printf("You lose.\n");
    else if (matches >= strlen(puzzle))
      printf("You win.\n");
    else
      printf("You chickened out.\n");
  }

  return 0;
}
