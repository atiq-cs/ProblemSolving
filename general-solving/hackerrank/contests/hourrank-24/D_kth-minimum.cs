/***************************************************************************
* Title       : Kth Minimum
* URL         : https://www.hackerrank.com/contests/hourrank-24/challenges/kth-minimum
* Occasion    : Codeforces Round #258 (Div. 2)
* Date        : Nov 1 2017
* Complexity  : O(n) 78ms, Space O(n), 11300 KB
* Author      : Atiq Rahman
* Status      : RunTime Error
* Notes       : Naive: sort the array and find diff sequence to reverse
*   Approach O(n),
*   Finding the starting and ending index of the segment that is in reverse
*   order.
*
*   Input: distinct integers, not equal
*   Judge has large inputs as per challenge author: anveshi,
*   Constraints on a_i's were increased from 10^5 to 2 * 10^5 to kill the
*   solution having complexity O(n * log^2 n * log a) where a is the answer.
*
* meta        : tag-median, tag-order-stats
***************************************************************************/
using System;
using System.Collections.Generic;
using System.IO;  // for OpenStandardInput; increasing input buffer limit

class JenListMinSolution {  // Reverse segment Solution Class
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

  private long RandomizedSelet(int p, int r, int i) {
    if (p == r)
      return jenList[p];
    int q = RandomizedPartition(p, r);
    int k_i = q - p + 1;
    if (i == k_i)
      return jenList[q];
    else if (i < k_i)
      return RandomizedSelet(p, q-1, i);
    else
      return RandomizedSelet(q + 1, r, i - k_i);
  }

  public long GetkthMinFromJenList() {
    GetMultList();
    return RandomizedSelet(0, jenList.Count-1, k);
  }

  private int RandomizedPartition(int p, int r) {
    Random rnd = new Random();
    int i = rnd.Next(p, r+1);
    Swap(i, r);
    return Partition(p, r);
  }

  // simple quick sort partition - C.L.R page 171
  private int Partition(int p, int r) {
    int i = p-1;
    long x = jenList[r];
    for (int j=p; j<r; j++) {
      /*
       * maintains invariant that all items are less than pivot are in the
       * block of i (or smaller elements till where i ends)
       */
      if (jenList[j] <= x) {
        i++;
        Swap(i, j);
      }
    }
    Swap(i+1, r);
    return i + 1;
  }

  private void Swap(int i, int j) {
    if (i != j) {
      long temp = jenList[i];
      jenList[i] = jenList[j];
      jenList[j] = temp;
    }
  }
}

public class CF_Solution {
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
