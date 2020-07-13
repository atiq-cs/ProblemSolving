/***************************************************************************************************
* Title : Determines if given string has some properties
* URL   : https://www.hackerrank.com/challenges/funny-string
* Date  : 2015-07-24
* Comp  : O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Does string reverse etc..
* meta  : tag-string
***************************************************************************************************/
using System;

class HKSolution {
  static void Main(String[] args) {
    string line;
    int nTestCases = Int32.Parse(Console.ReadLine());
    while (nTestCases-- >0) {
      line = Console.ReadLine();
      if (!String.IsNullOrEmpty(line)) {
        if (isFunny(line))
          Console.WriteLine("Funny");
        else
          Console.WriteLine("Not Funny");
      }
    }
  }

  static bool isFunny(string str) {
    char[] first = str.ToCharArray();
    // get reverse of the string
    char[] second = str.ToCharArray(); Array.Reverse(second);

    for (int i = 1; i < first.Length; i++)
      if (Math.Abs(first[i] - first[i - 1]) != Math.Abs(second[i] - second[i - 1]))
        return false;
    return true;
  }
}
