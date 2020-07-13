/***************************************************************************************************
* Title : Truck Tour
* URL   : https://www.hackerrank.com/challenges/truck-tour
* Date  : 2017-09-04
* Comp  : O(n), O(n)
* Author: Atiq Rahman
* Status: Accepted
* Notes : For understanding 2 things to consider,
*   1. Calculate the first point from where the truck will be able
*   to complete the circle
*   2. An integer which will be the smallest index of the petrol
*   pump from which we can start the tour.
*   It is not a Priority Queue problem.
*   
*   Input can be easily represented using result of subtraction of
*   fuel_amount - distance. We also call it residual fuel amount
*   It can be proved that a number (residual fuel amount) if
*   negative earlier all previous hops before this one would also
*   fail.
*   Therefore, if a sum is negative at some stage none of the
*   previous petrol pumps cannot be starting index.
*   
*   This problem can be stated as,
*   Find a rotation of a circular array such that all prefix sums
*   for that rotation are non-negative? (Given that sum of all its
*   elements is non negative).
*
* ref   : https://www.hackerrank.com/challenges/truck-tour/forum/comments
*   /199713
* meta  : tag-ds-queue
***************************************************************************************************/
using System;
using System.Collections.Generic;

public class TruckTour
{
  Queue<int> PPQueue;

  public void TakeInput() {
    PPQueue = new Queue<int>();
    int n = int.Parse(Console.ReadLine());

    while (n-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      PPQueue.Enqueue(int.Parse(tokens[0]) - int.Parse(tokens[1]));
    }
  }

  // get 0 based index of starting Petrol Pump
  public int GetStartingPumpIndex() {
    // start with an initial queue
    // start index is 0
    // keep popping items
    //  whenever it fails forward it to the next tage..
    int passCount = 0;
    int sFA = 0;          // sum fuel amount
    int ppStartIndex = 0;
    while (passCount < PPQueue.Count) {
      int rFA = PPQueue.Dequeue();   // residue of fuel amount
      sFA += rFA;
      if (sFA < 0) {
        sFA = 0;
        ppStartIndex += passCount + 1;
        passCount = 0;
      }
      else passCount++;
      PPQueue.Enqueue(rFA);
    }
    return ppStartIndex;
  }
}

class HKSolution {
  static void Main(String[] args) {
    TruckTour tour = new TruckTour();
    tour.TakeInput();
    Console.WriteLine(tour.GetStartingPumpIndex());
  }
}

/*
Wrong assumptions:
  Item with greater value in FuelAmount field will be returned first
  if amount is equal one with lower distance will be returned first
 
It is likely that there is a
similarity of the pattern where Queue can be applied. The queue part here can
be replaced with queue like iteration of the array.


Time complexity analysis:
  Probably can be solved in O(N^2)
  However, max limit of N is 10^5 which is concerning..

Assuming this is an easy problem as mentioned by people is discussion. I would rather give it a try with my N^2 idea.
I tried this and got 'TLE'
*/
