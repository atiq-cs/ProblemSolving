/***************************************************************************************************
* Title : Two Substrings
* URL   : http://codeforces.com/problemset/problem/550/A
* Date  : 2016-01-07
* Notes : Simple string problem but has to take care of some cases where a string should be
* considered overlapped or not Whether both AB, BA exist in those cases
* Comp  : O(N) proposed O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes : Time 62ms, takes 108ms when converted and passed as char array to the function
* meta  : tag-string
***************************************************************************************************/
using System;

class CFSolution
{
  private static void Main() {
    string str = Console.ReadLine();
    if (IsNonOverlappedString(str))
      Console.WriteLine("YES");
    else
      Console.WriteLine("NO");
  }

  private static bool IsNonOverlappedString(string s) {
    bool firstPartFound = false;
    bool secondPartFound = false;
    int overlapFound = 0;
    
    for (int i = 0; i < s.Length; i++) {
      // if A is found check if we have B next
      // ABAAB

      if (firstPartFound==false && s[i] == 'A') {
        if (i+1 < s.Length && s[i + 1] == 'B') {
          // takes care of multiple overlaps ABACABA
          if (i + 2 < s.Length && s[i + 2] == 'A')
          {
            overlapFound++; i++;
          }
          else
            firstPartFound = true;
          i++;
        }
      }
      else if (secondPartFound==false && s[i] == 'B') {
        if (i + 1 < s.Length && s[i+1] == 'A') {
          if (i + 2 < s.Length && s[i + 2] == 'B') {
            overlapFound++; i++;
          }
          else
            secondPartFound = true;
          i++;
        }
      }
    }
    if (firstPartFound && secondPartFound)
      return true;
    if (overlapFound > 1)
      return true;
    if (overlapFound>0 && (firstPartFound || secondPartFound))
      return true;
    return false;
  }
}
