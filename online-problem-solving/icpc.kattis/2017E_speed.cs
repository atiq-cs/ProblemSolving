/***************************************************************************
* Title : Need for Speed
* URL   : https://icpc.kattis.com/problems/speed
* Contst: 2017 ICPC World Final
* Date  : 2018-04-17
* Author: Atiq Rahman
* Comp  : O(n lg n)
* Status: Accepted
* Notes : Application of binary search to find fraction constant value
*   To find fractional solution it is important to include all values starting
*   from mid instead of doing an offset of integer value 1.
* 
*   Lower bound derivation,
*   Fact: s_i + c > 0
*   Therefore, c > -s_i
*   
*   Let's assume there are a few negative speeds in the set. To make all the
*   specified erratic speed in the set positive c needs to be,
*   Max( -s_i) where 0 <= i < n
*   
*   This also works if all speed in the set are positive.
*   Here's an example, 4, 8, 7, 10, 11
*    lower bound for this example would be, not equals to but approx -4
*   Max of negative of all these numbers is -4.
*   
*   Upper bound derivation,
*    d_0/(s_0+c) + d_1/(s_1+c) + d_2/(s_2+c) + d_3/(s_3+c) + ... ... ... ...
*    + d_n/(s_n+c) = t    ------- eq. 1
*   Simplifying eq 1 we find,
*    1000 * d / (s+c) = t_min
*    => s + c = 1000 * d / t_min
*    => c = 1000 * d / t_min - s
*    For upper bound, we assume d is max of all d provided, t = 1 (as t is integer)
*     and s = -1000
*    With this arrangment c can be as max as 10^6 + 1000
*   
*   I think upper bound derived by me is tighter than usual solutions or
*   solutions where 1e9 is taken as default. 1e9 works because binary search
*   converges fast.
* 
*   Found mistakes in my binary search and fixed them.
*   Acknowledgement: Derek Kisman (referred C# version included below)
*   Derek Kisman's C solution ref,
*  github.com/SnapDragon64/ACMFinalsSolutions/blob/master/finals2017/speedDK.cc
*  
*   It should be noted that kattis online judge proves to be good so far. MLE
*   or TLE I was getting was real. It was not due to use of a specific
*   programming language.
*
*   related: https://icpcarchive.ecs.baylor.edu/external/22/2294.pdf
* meta  : tag-binary-search, tag-icpc
***************************************************************************/
using System;

public class BinarySearchUtil {
  internal class JourneySegment {
    public double d;
    public double s;
    public JourneySegment(double d, double s) { this.d = d; this.s = s; }
  }

  private int n, t;
  // Upper bound for max speed = max dist / time where in worst case time = 1
  private double ubMaxDist = -1000;
  private double lbMinSpeed = -1000;
  JourneySegment[] Segments;
  private double EPS = 1e-9;

  // O(lg N)
  public double FindSpeedoMeterError(double low, double high)
  {
    if (high - low < EPS)
      return low;

    double mid = (high + low) / 2;
    double sum = GetTotalJourneyTime(mid);
    if (sum < t)
      return FindSpeedoMeterError(low, mid);
    return FindSpeedoMeterError(mid, high);
  }

  // O(N)
  private double GetTotalJourneyTime(double c) {
    double sum = 0.0;
    foreach (JourneySegment segment in Segments)
      sum += segment.d / (segment.s + c);
    return sum;
  }

  private void TakeInput() {
    string[] tokens = Console.ReadLine().Split();
    n = int.Parse(tokens[0]);
    t = int.Parse(tokens[1]);

    Segments = new JourneySegment[n];
    for (int i = 0; i < n; i++) {
      tokens = Console.ReadLine().Split();
      if (tokens.Length != 2) {
        Console.WriteLine("Error");
        break;
      }
      Segments[i] = new JourneySegment(int.Parse(tokens[0]), int.Parse(tokens[1]));
      ubMaxDist = Math.Max(ubMaxDist, Segments[i].d);
      lbMinSpeed = Math.Max(lbMinSpeed, -Segments[i].s);
    }
  }

  public void Run()
  {
    TakeInput();
    // Please refer to computation above
    double upperBound = n * ubMaxDist + 1000;
    Console.WriteLine(FindSpeedoMeterError(lbMinSpeed, upperBound));
  }
}

public class Kattis_Solution {
  public static void Main() {
    BinarySearchUtil demo = new BinarySearchUtil();
    demo.Run();
  }

  // Derek Kisman's ported solutin to C#, with modification on upperbound
  public static void DK_Main() {
    string[] tokens = Console.ReadLine().Split();
    int N = int.Parse(tokens[0]);
    int T = int.Parse(tokens[1]);
    double mn = -1e9, mx = 1e9;
    double[] D = new double[N];
    double[] S = new double[N];
    double maxSpeed = -1000;
    for (int i = 0; i < N; i++) {
      tokens = Console.ReadLine().Split();
      D[i] = int.Parse(tokens[0]);
      S[i] = int.Parse(tokens[1]);
      mn = Math.Max(mn, -S[i]);
      maxSpeed = Math.Max(maxSpeed, D[i]);
    }
    mx = Math.Min(1e9, N * maxSpeed + 1000);

    while (mx - mn > 1e-9) {
      double c = (mx + mn) / 2, t = 0.0;
      for (int i = 0; i < N; i++) t += D[i] / (S[i] + c);
      if (t > T) mn = c+1; else mx = c-1;
    }

    Console.WriteLine((mx + mn) / 2);
  }
}

/*
My previous iterative version,

public double FindSpeedoMeterError(double low, double high)
{
  double mid=0.0;
  while (high-low > EPS) {
    // mid is the candidate value of c
    // bypassing integer overlfow mechanism not required here since these are double
    mid = (high + low) / 2;
    double sum = GetTotalTime(mid);
    if (sum < t)
      high = mid;
    else
      low = mid;
  }
  return mid;
}
*/
