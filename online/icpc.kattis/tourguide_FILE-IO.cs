/***************************************************************************
* Title       : Problem C
* URL         : https://open.kattis.com/problems/tourguide
* Occasion    : Croatian Open Competition in Informatics 2009/2010, contest #4
* Date        : Sept 29 2017
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       :
*   This example is for showing FILE IO using StreamReader and StreamWriter
*   For original solution please look at 'icpc.kattis/tourguide.cs'
*
* Ref         :
*   msdn - StreamWriter Class
*   https://msdn.microsoft.com/en-us/library/system.io.streamwriter.aspx
*   msdn - StreamReader Class
*   https://msdn.microsoft.com/en-us/library/system.io.streamreader.aspx
*
* meta        : tag-csharp, tag-FILE-Input-Output
***************************************************************************/
using System;

public class Point {
  public double x;
  public double y;
  public Point(double lx, double ly) { x = lx; y = ly; }
}

public class Props {
  public Point P;
  public double s;
  public double angle;
  public Props(double lx, double ly, double ls, double la) { P = new Point(lx,ly); s = ls; angle = la;  }
}

class PermuteTSP {
  private int n;
  private double SpeedOfTourGuide;
  private Props[] SCProps;  // senior member properties
  private Point TP;         // Current Point Tour Guide is visiting
  int[] order_nums;         // elements: 1..n

  // initializations and allocations
  public PermuteTSP(int ln) {
    n = ln;
    SCProps = new Props[n];
    order_nums = new int[n];
    TP = new Point(0.0, 0.0);
  }

  private double GetTravelingTime() {
    double totalTime = 0.0;
    // double maxReturnTime = 0.0;
    double maxTotalTime = 0.0;
    for (int k = 0; k < n; k++) {
      int i = order_nums[k];
      double travelTime = GetTravelTime(i, totalTime);
      Console.WriteLine("intermediate time: " + travelTime + " x " + TP.x + " y " + TP.y);
      totalTime += travelTime;
      /* if (i>0)
        maxReturnTime -= travelTime;*/
      double returnTime = Math.Sqrt(TP.x * TP.x + TP.y * TP.y) /
        SCProps[i].s;
      maxTotalTime = Math.Max(maxTotalTime, totalTime+returnTime);
      // maxReturnTime = Math.Max(maxReturnTime, returnTime);
    }
    return maxTotalTime;
  }

  private double GetTravelTime(int i, double timePassed) {
    double a = SCProps[i].s * SCProps[i].s - SpeedOfTourGuide * SpeedOfTourGuide;
    double b = 2 * SCProps[i].s * ((SCProps[i].P.x - TP.x) *
      Math.Cos(SCProps[i].angle) + (SCProps[i].P.y - TP.y) *
      Math.Sin(SCProps[i].angle) + SCProps[i].s * timePassed);
    double c = (SCProps[i].P.x + SCProps[i].s * timePassed * Math.Cos(SCProps[i].angle) - TP.x) * (SCProps[i].P.x + SCProps[i].s * timePassed * Math.Cos(SCProps[i].angle) - TP.x) +
      (SCProps[i].P.y + SCProps[i].s * timePassed * Math.Sin(SCProps[i].angle) - TP.y) * (SCProps[i].P.y + SCProps[i].s * timePassed * Math.Sin(SCProps[i].angle) - TP.y);
    double time = (-b - Math.Sqrt(b*b - 4*a*c)) / (2 * a);
    /*if (time < 0)
      time = (-b + Math.Sqrt(b*b - 4*a*c)) / (2 * a);*/
    // update current point being visited by tour guide
    TP.x = SCProps[i].P.x + SCProps[i].s * (time+timePassed) * Math.Cos(SCProps[i].angle);
    TP.y = SCProps[i].P.y + SCProps[i].s * (time+timePassed) * Math.Sin(SCProps[i].angle);
    return time;
  }

  public int GetMinimumTime() {
    double minTime=double.MaxValue;
    do {
      // outFile.WriteLine(string.Join("", order_nums));
      minTime = Math.Min(minTime, GetTravelingTime());
      Console.WriteLine("total time: " + minTime);
      TP.x = 0.0; TP.y = 0.0;
    }
    while (Solution.NextPermutation(order_nums) == 0);
    return (int)Math.Round(minTime);
  }

  // Take problem specific input
  public void TakeInput(System.IO.StreamReader inFile, System.IO.StreamWriter outFile) {
    SpeedOfTourGuide = double.Parse(inFile.ReadLine());    
    for (int i = 0; i < n; i++) {
      order_nums[i] = i;
      string[] tokens = inFile.ReadLine().Split();
      SCProps[i] = new Props(double.Parse(tokens[0]), double.Parse(tokens[1]),
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
    System.IO.StreamReader inFile = new System.IO.StreamReader("tourguide_in.txt");
    System.IO.StreamWriter outFile = new System.IO.StreamWriter("tourguide_out.txt");

    int n = 0;
    while ((n = int.Parse(inFile.ReadLine())) != 0) {
      PermuteTSP permTSPDemo = new PermuteTSP(n);
      permTSPDemo.TakeInput(inFile, outFile);
      outFile.WriteLine(permTSPDemo.GetMinimumTime());
    }
    inFile.Close();
    outFile.Close();
  }
}
