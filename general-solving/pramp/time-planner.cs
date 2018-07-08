/***************************************************************************
* Title : Time Planner
* URL   : https://www.pramp.com/challenge/3QnxW6xoPLTNl5jX5Lg1
* Date  : 2018-04-24
* Author: Atiq Rahman
* Comp  : O(N+M), Space O(1)
* Status: Accepted
* Notes : Given that the time slots in a person’s availability are disjointed,
*   i.e, time slots in a person’s availability don’t overlap. Further assume
*   that the slots are sorted by slots’ start time.
*   
*   Following the solution, I am only comparing end time. It works because
*   input is disjoint slots.
*   When I compare start time it does not work that way,
*    [1, 10]
*    [2, 3], [5, 7]
*   Because first one in A has a long interval but with a smaller starting time
*   I was trying to generate counter case for using the end time for
*   comparison such as,
*    [10, 50], [51, 60]
*    [40, 50]
*   But it is not a counter case. It still works.
*   
*   Ref: https://www.topcoder.com/community/data-science/data-science-tutorials
*    /line-sweep-algorithms/ (as Per Sreezin)
* meta  : tag-pramp, tag-easy
***************************************************************************/
using System;

class Solution {
  public static int[] MeetingPlanner(int[,] slotsMdA, int[,] slotsMdB, int dur) {
    // n and m are declared inside Convert Method
    int[][] slotsA = ConvertMultiDimensionalToJagged<int>(slotsMdA);
    int[][] slotsB = ConvertMultiDimensionalToJagged<int>(slotsMdB);
    
    // iA left pointer is for A
    int iA = 0;
    // iB left pointer is for B
    int iB = 0;
    while (iA < slotsA.Length && iB < slotsB.Length) {
      int startTime = Math.Max(slotsA[iA][0], slotsB[iB][0]);
      int endTime = Math.Min(slotsA[iA][1], slotsB[iB][1]);

      if (endTime - startTime >= dur)
        return new int[] {startTime, startTime + dur};
      if (slotsA[iA][1] > slotsB[iB][1])
        iB++;
      else
        iA++;
    }
    return new int[] {};
  }  
}
