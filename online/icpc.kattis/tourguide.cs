/***************************************************************************
* Title       : Tour Guide
* URL         : https://open.kattis.com/problems/tourguide
* Occasion    : Nordic Collegiate Programming Contest 2006
* Date        : 2017-10-06
* Complexity  : O(n! * n) - generating permutations O(n!)
*               - O(n) for each permutation
* Status      : Accepted
* Notes       : A relaxed version of Traveling Salesman Problem
*               Due to small number of input it is possible to generate
*               permutations and try all the orders to find minimum travelling time
*               
*               This is my frist attempt in learning TSP. First hint comes from
*               nordic contest site solution sketch,
*               https://ncpc.idi.ntnu.no/ncpc2006/ncpc2006solutions.pdf
*               
*               Only hint I took from there is that generating permutation is
*               right track. I derived geometric equations myself. I ended up
*               doing a mistake where I did not account for the time that has
*               passed since tour guide started travelling should be account
*               for to get correct time to travel next point and the point's
*               co-ordindates. I have included the ref below which helped me
*               figure out this mistake.
*               
*               A sample solution from Judge that was kinda similar to mine
*               helped me a lot to find a mistake
*               https://ideone.com/9QWCqA
*               
*               Problem C of 10xRecruit Coding Challenge- 10xrecruit.kattis.com
* Same        : http://poj.org/problem?id=3029
*               http://noj.io/problem/p/1127
* meta        : tag-permutation, tag-oj-kattis, tag-tsp, tag-geometry, tag-math
***************************************************************************/
using System;

public class Point {
  public double x;
  public double y;
  public Point(double lx, double ly) { x = lx; y = ly; }
}

// Senior
public class Props {
  public Point Location;
  public double Speed;
  public double Theta;
  public Props(double x, double y, double s, double angle) {
    Location = new Point(x,y); Speed = s; Theta = angle;
  }
}

class PermuteTSP {
  private int n;
  private double SpeedOfTourGuide;
  private Props[] Senior;  // senior member properties
  private Point TP;         // Current Point Tour Guide is visiting
  int[] Order;         // elements: 1..n

  // initializations and allocations
  public PermuteTSP(int ln) {
    n = ln;
    Senior = new Props[n];
    Order = new int[n];
    TP = new Point(0.0, 0.0);
  }

  /*
   * Purpose: Compute travel time from current point to next point
   * and update current point to next point.
   * 
   * Input:
   *  index of Senior
   *  Tour Guide's visiting point
   *  Time passed so far
   *  
   * Output:
   *  Travelling time from previous point to new point
   *  Updates the visiting point
  */
  private double GetTravelTime(int i, double timePassed) {
    double a = SpeedOfTourGuide * SpeedOfTourGuide - Senior[i].Speed *
      Senior[i].Speed;
    double b = -2.0 * Senior[i].Speed * ((Senior[i].Location.x - TP.x) *
      Math.Cos(Senior[i].Theta) + (Senior[i].Location.y - TP.y) *
      Math.Sin(Senior[i].Theta) + Senior[i].Speed * timePassed);

    double c = -((Senior[i].Location.x + Senior[i].Speed * timePassed *
      Math.Cos(Senior[i].Theta) - TP.x) * (Senior[i].Location.x + Senior[i].
      Speed * timePassed * Math.Cos(Senior[i].Theta) - TP.x) + (Senior[i]
      .Location.y + Senior[i].Speed * timePassed * Math.Sin(Senior[i].Theta) -
      TP.y) * (Senior[i].Location.y + Senior[i].Speed * timePassed * Math.Sin(
        Senior[i].Theta) - TP.y));

    double time = (-b + Math.Sqrt(b*b - 4*a*c)) / (2 * a);
    // Update Tour Guide's visting point.
    TP.x = Senior[i].Location.x + Senior[i].Speed * (time+timePassed) * Math.
      Cos(Senior[i].Theta);
    TP.y = Senior[i].Location.y + Senior[i].Speed * (time+timePassed) * Math.
      Sin(Senior[i].Theta);

    return time;
  }

  /* Input:
   *  order_nums
   *  Senior
   *  
   * Output:
   *  Total travelling time following the given order of traversal  
  */
  private double GetTravelingTime() {
    double totalTime = 0.0;
    double maxTotalTime = 0.0;
    for (int k = 0; k < n; k++) {
      int i = Order[k];
      double travelTime = GetTravelTime(i, totalTime);
      totalTime += travelTime;
      double returnTime = Math.Sqrt(TP.x * TP.x + TP.y * TP.y) / Senior[i].Speed;
      // getting max this way is adapted from 
      maxTotalTime = Math.Max(maxTotalTime, totalTime+returnTime);
    }
    return maxTotalTime;
  }

  public int GetMinimumTime() {
    double minTime=double.MaxValue;
    do {
      minTime = Math.Min(minTime, GetTravelingTime());
      TP.x = 0.0; TP.y = 0.0;
    }
    while (Solution.NextPermutation(Order) == 0);
    return (int)Math.Round(minTime);  // rounding required
  }

  // Take problem specific input
  public void TakeInput() {
    SpeedOfTourGuide = double.Parse(Console.ReadLine());    
    for (int i = 0; i < n; i++) {
      Order[i] = i;
      string[] tokens = Console.ReadLine().Split();
      Senior[i] = new Props(double.Parse(tokens[0]), double.Parse(tokens[1]),
        double.Parse(tokens[2]), double.Parse(tokens[3]));
    }
  }
}

public class Solution {
  public static int NextPermutation(int[] nums) {
    // iterate in reverse, find the index before which item is less
    int i = nums.Length - 1;
    while (i > 0 && nums[i - 1] >= nums[i])
      i--;
    // find the item that is immediately greater than nums[i-1] and swap
    if (i>0) {
      int j = nums.Length - 1;
      while (nums[i - 1] >= nums[j])  //>= so we choose the last one
        j--;  // so that after swapping small number comes at the later index
      int temp = nums[j]; nums[j] = nums[i - 1]; nums[i - 1] = temp;
    }   // afterwards, when we reverse the string order is maintained
    if (i == 0)   // only for this spoj problem
      return -1;
    for (int j=i, k=nums.Length-1; j<k;j++,k--)
      /* if (nums[j]>nums[k]) */ {  // swap condition not required
        int temp = nums[j]; nums[j] = nums[k]; nums[k] = temp;
      }
    return 0;
  }

  public static void Main() {
    int n = 0;
    // Taking input N here so we know how much to allocate during construction
    while ((n = int.Parse(Console.ReadLine())) != 0) {
      PermuteTSP permTSPDemo = new PermuteTSP(n);
      permTSPDemo.TakeInput();
      Console.WriteLine(permTSPDemo.GetMinimumTime());
    }
  }
}

/*
Good Input
5
58.263506
-119.653077 51.696056 19.692974 5.239156
176.851733 -128.084566 20.518903 0.768107
171.687484 -44.554947 19.628289 2.421394
-109.806999 -149.335672 22.160938 1.215649
-10.318014 -69.537658 15.194672 1.503082

1
2.0
0.0 0.0 1.0 0.0

1
50.0
-100.000000 0.000000 25.000000 0.000000

*/
