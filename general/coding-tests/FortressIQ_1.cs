/***************************************************************************************************
* Title : Max Difference in an array (p#1)
* Occasn: FortressIQ Senior C# Developer
* Date  : 2018-03-04
* Author: Atiq Rahman
* Comp  : O(N), constant space
* Status: Accepted
* Notes : Find the max difference as per specification,
*   Using Dynamic Programming approach we can solve this in O(N)
*   Idea is to keep a min variable for previous element and try to maintain a max variable which
*   contains max difference with current item while doing iteration through the entire array
* meta  : tag-algo-dp, tag-company-FortressIQ, tag-coding-test
***************************************************************************************************/
public class FortressIQ_Solution {
  static int maxDifference(int[] a) {
    // Initialization of variables
    int maxDiff = -1;
    int minPrevious = int.MaxValue;
  
    // Dynamic Programming Loop
    for (int i=0; i<a.Length; i++) {
      if (minPrevious < a[i])
        maxDiff = Math.Max(maxDiff, a[i]-minPrevious);
      minPrevious = Math.Min(minPrevious, a[i]);
    }
    return maxDiff;
  }
  
  static void Main(String[] args) {
    string fileName = System.Environment.GetEnvironmentVariable("OUTPUT_PATH");
    TextWriter tw = new StreamWriter(@fileName, true);

    int res;
    int a_size = 0;
    a_size = Convert.ToInt32(Console.ReadLine());
    int[] a = new int [a_size];
    int a_item;
    for(int a_i = 0; a_i < a_size; a_i++) {
      a_item = Convert.ToInt32(Console.ReadLine());
      a[a_i] = a_item;
    }

    res = maxDifference(a);
    tw.WriteLine(res);

    tw.Flush();
    tw.Close();
  }
}
