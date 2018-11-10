/***************************************************************************************************
* Title : Kth Minimum
* URL   : https://www.hackerrank.com/contests/hourrank-24/challenges/kth-minimum
* Occasn: Codeforces Round #258 (Div. 2)
* Date  : 2017-11-01
* Comp  : O(n) 78ms, O(n), 11300 KB
* Author: Atiq Rahman
* Status: RunTime Error
* Notes : Naive: sort the array and find diff sequence to reverse
*   Approach O(n),
*   Finding the starting and ending index of the segment that is in reverse
*   order.
*
*   Input are distinct integers, not equal
*   Judge has large inputs as per challenge author: anveshi,
*   Constraints on a_i's were increased from 10^5 to 2 * 10^5 to kill the
*   solution having complexity O(n * log^2 n * log a) where a is the answer.
*   last submission ref:
*  https://www.hackerrank.com/contests/hourrank-24/challenges/kth-minimum/submissions/code/1308095340
*   (tried a simplified version of input)
*   
*   Things to change for 'demos/algo/OrderStat.cs'
*   type int to type long
*   int[] to List<long>
* meta  : tag-median, tag-order-stats
***************************************************************************************************/
using System;
using System.Collections.Generic;

class JenListMinSolution {
  private int n, m;
  private int[] ia, ib;
  private int x, k;
  List<long> jenList;

  private void GetMultList() {
    for (int i=0; i<Math.Min(n, m-x); i++)
      for (int j=i+x; j<m; j++)
        jenList.Add(ia[i] * (long)ib[j]);
  }

  public void TakeInput() {
    string[] tokens_n = Console.ReadLine().Split(' ');
    n = Convert.ToInt32(tokens_n[0]);
    m = Convert.ToInt32(tokens_n[1]);
    x = Convert.ToInt32(tokens_n[2]);
    k = Convert.ToInt32(tokens_n[3]);
    // these 3 lines are for increasing buffer limit or fast IO for large input
    byte[] inputBuffer = new byte[2000000];
    Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
    Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false,
      inputBuffer.Length));
    ia = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
    ib = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);

    jenList = new List<long>();
  }

  public long GetkthMinFromJenList() {
    GetMultList();
    return RandomizedSelet(0, jenList.Count-1, k);
  }
}

public class CFSolution {
  private static void Main() {
    JenListMinSolution jenListMinDemo = new JenListMinSolution();
    jenListMinDemo.TakeInput();
    Console.WriteLine(jenListMinDemo.GetkthMinFromJenList());
  }
}

/*
k-th Minimum sample input,
3 4 1 5
2 -3 1
3 1 -2 -1

output for the input,
3
*/
