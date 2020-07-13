/***************************************************************************
* Title : Find duplicates
* URL   : hackerrank.com/contests/filter-cse-it/challenges/find-duplicates
* Contst: filter-cse-it
* Date  : 2018-04-06
* Author: Atiq Rahman
* Comp  : O(n), space O(k)
* Status: Accepted
* Notes : This problem asks to print each duplicate number
*   Bloomberg version asks to print number of duplicate numbers
*   For example, if we have
*   1 4 5 1 2 7 9 2 3
*   then bloomberg version asks to print 2 as 2 duplicate numbers found (1 & 2)
*   For this problem, however, we need to print both of these numbers
*   1, 2
* meta  : tag-easy, tag-company-bloomberg, tag-hash-table
***************************************************************************/
using System;
using System.Collections.Generic;

public class LinearAlgo {
  private int[] nums;
  private int n;

  public bool FindDuplicates() {
    Dictionary<int, int> freq = new Dictionary<int, int>();
    bool isDupFound = false;

    foreach (int num in nums) {
      if (freq.ContainsKey(num))
        freq[num]++;
      else
        freq.Add(num, 1);
      if (freq[num] == 2) { 
        Console.WriteLine(num);
        isDupFound = true;
      }
    }
    return isDupFound;
  }

  public void TakeInput() {
    Console.ReadLine();                           // skip n
    string[] tokens = Console.ReadLine().Split();
    nums = Array.ConvertAll(tokens, int.Parse);
  }
}

public class HK_Solution {
  public static void Main() {
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      LinearAlgo demo = new LinearAlgo();
      demo.TakeInput();
      if (demo.FindDuplicates() == false)
        Console.WriteLine("-1");
    }
  }
}


/* A large input,
 1
50
89384
30887
92778
36916
47794
38336
85387
60493
16650
41422
2363
90028
68691
20060
97764
13927
80541
83427
89173
55737
5212
95369
2568
56430
65783
21531
22863
65124
74068
3136
13930
79803
34023
23059
33070
98168
61394
18457
75012
78043
76230
77374
84422
44920
13785
98538
75199
94325
98316
64371

Output: -1
*/
