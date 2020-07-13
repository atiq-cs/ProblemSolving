/***************************************************************************
* Title       : Toilet Seat
* URL         : https://open.kattis.com/problems/toilet
* Occasion    : KTH Challenge 2012
* Date        : Sept 29 2017
* Complexity  : 
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : should consider all situations/configurations based on given,
*               - initial seat condition
*               - for all policies
* meta        : tag-kattis, tag-easy
***************************************************************************/
using System;

public class Solution {
  /*
   Input:
    Policy and the string
   Output:
    Gives adjustment count
   */
  private static int GetAdjustmentCount(string str, int policy) {
    int count = 0;
    char previousChar = char.ToLower(str[0]);
    for (int i=1; i<str.Length; i++) {
      char ch = char.ToLower(str[i]);
      switch (policy) {
        case 1:
          if (ch == 'd')
            count += 2;
          if (i == 1 && previousChar == 'd') {
            if (ch == 'd')
              count--;
            else
              count++;
          }
          break;
        case 2:
          if (ch == 'u')
            count += 2;
          if (i == 1 && previousChar == 'u') {
            if (ch == 'u')
              count--;
            else
              count++;
          }
          break;
        case 3:
          if (previousChar != ch)
            count++;
          break;
        default:
          // shouldn't be here
          break;
      }
      previousChar = ch;
    }
    return count;
  }

  public static void Main() {
    string line = Console.ReadLine();
    Console.WriteLine(GetAdjustmentCount(line, 1));
    Console.WriteLine(GetAdjustmentCount(line, 2));
    Console.WriteLine(GetAdjustmentCount(line, 3));
  }
}

/*
U
UU DD U D U

2 up 2 down 

nothing needs to be done for the people who want it up
for peole who want it down first they need to adjust because that's the way they want it
next they have to adjust when they leave..

pol 1,
3 * 2 = 6

pol 2,
first guy finds it up
but before he leave he adjusts it to down
1
next guy adjusts it up to use and then leave it down adjusting again..
2

next U 
2
nxtt U 2

1 + 2*3 =7

first 2 U - 0
for next D, 1 adjustment, puts it down; uses and leaves - 1
next D - 0

next U - 1
next D - 1
next U - 1

policy 3 calculation,
 
 UUUUU
 0
 7 = 8-1
 0

 ududud
 6

 ddd
 3
 0
 0

 ddu
 1
 2
 1

 dud
 3
 2
 2

 duu
 1
 4
 1

 udd
 4
 1
 1

 udu
 2
 3
 2

 uud
 2
 1
 1

 uuu
 0
 3
 0

 DDDDDDDDDDDD
 uuuuu   
*/
