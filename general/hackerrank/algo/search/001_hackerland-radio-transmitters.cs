/***************************************************************************
* Title : Hackerland Radio Transmitters
* URL   : https://www.hackerrank.com/challenges/hackerland-radio-transmitters
* Date  : 2017-10-25
* Author: Atiq Rahman
* Comp  : O(n)
* Status: Accepted
* Notes : My initial approach was to set the transmitter on the co-ordinate
*   x[i]+k. However, there might not be a house in that co-ordinate. Hence, the
*   modification to find houses with good co-ordinate to set the transmitter.
*   
*   Search I implement on this solution is a linear search on sorted data.
*
* meta  : tag-easy, tag-search
***************************************************************************/
using System;

class Solution {
  static void Main(String[] args) {
    string[] tokens_n = Console.ReadLine().Split(' ');
    int n = Convert.ToInt32(tokens_n[0]);
    int k = Convert.ToInt32(tokens_n[1]);
    string[] x_temp = Console.ReadLine().Split(' ');
    int[] x = Array.ConvertAll(x_temp,Int32.Parse);
    // sort houses according to value on x-axis
    Array.Sort(x);
    /*
     *  Assign first radio transmitter at x' = x_0 + k
     *  if (x' > x_1 )
     *    count++
     */
    int count = 0;
    int px = 0; // all x[i] > 0
    bool isTransmitterSet=false;
    for (int i=0; i<n; i++) {
      if (px < x[i]) {
        // setup new radio transmitter (stage 1)
        if (isTransmitterSet == false)
          px = (i>0)?(x[i-1] + k):-1;
        // end stage 2 or start stage 1 from current house
        if (px < x[i] || isTransmitterSet) {
          count++;
          px = x[i] + k;
          if (isTransmitterSet)
            isTransmitterSet = false;
          // stage 1 succeeded, mark it, start stage 2
          else if (isTransmitterSet==false)
            isTransmitterSet = true;
        }
      }
      Console.WriteLine(count);
    }
  }
}

/* Sample input,
7 2
9 5 4 2 6 15 12
4

sorted,
2 4 5 6 9 12 15
*/

/* previous version 2
if (isTransmitterSet && px<x[i]) {
  count++;
  px = x[i] + k;
  isTransmitterSet = false;
}
if (isTransmitterSet==false && px<x[i]) {
  // setup new radio transmitter (stage 1) at x[i] + k to cover current house and next few
  // find x[i] that is larger than 
  // still this can be true: px < x[i]
  // in that case recalculate based on current house equiv to stage 2
  px = (i>0)? (x[i - 1] + k):-1;
  if (px<x[i]) {
    count++;
    px = x[i] + k;
  }
  else
    isTransmitterSet = true;
}
*/


/* original version

if (isTransmitterSet && px < x[i]) {
  count++;
  px = x[i] + k;
  isTransmitterSet = false;
}
if (isTransmitterSet==false && px < x[i]) {
  // setup new radio transmitter (stage 1) at x[i] + k to cover current house and next few
  // find x[i] that is larger than 
  // still this can be true: px < x[i]
  // in that case recalculate based on current house equiv to stage 2
  px = (i>0)?(x[i-1] + k):-1;
  if (px < x[i]) {
    count++;
    px = x[i] + k;
  }
  else
    isTransmitterSet = true;
}
*/
