/***************************************************************************
* Title : Sherlock and Array
* URL   : https://www.hackerrank.com/challenges/sherlock-and-array
* Date  : 2017-10-25
* Author: Atiq Rahman
* Comp  : O(n), space O(1)
*
* Status: Accepted
* Notes : Similar to building binary tree from sorted array or converting
*   sorted array to BST: '108_convert-sorted-array-to-binary-search-tree.cs'
*   mid calculation/selection part is modified to solve this problem.
* Ref   : general-solving/misc/find_balance_index.cpp
* meta  : tag-easy, tag-prefix-sum
***************************************************************************/
using System;
using System.Linq;

class PrefixSum {
  int n;
  int[] A;
  
  public string solve(){
    int total_sum = A.Sum();
    int current_sum = 0;
    /* adjusted for this problem to start from first index
     * when number of elements is 1 this will return "YES" */
    for (int i = 0; i < n; i++) {
      current_sum += A[i];
      int sum_left = current_sum - A[i];
      int sum_right = total_sum - current_sum;
      if (sum_left == sum_right)
        return "YES";
    }
    return "NO";
  }
  
  public void TakeInput() {
    n = Convert.ToInt32(Console.ReadLine());
    string[] a_temp = Console.ReadLine().Split(' ');
    A = Array.ConvertAll(a_temp,Int32.Parse);
  }
}

class Solution {
  static void Main(String[] args) {
    int T = Convert.ToInt32(Console.ReadLine());
    for(int i = 0; i < T; i++){
      PrefixSum prefixSum = new PrefixSum();
      prefixSum.TakeInput();
      Console.WriteLine(prefixSum.solve());
    }
  }
}

/*
Special 10 Test Cases
10
1
1
1
2
1
3
2
1 2
3
1 4 1
3
1 5 1
1
234
1
20000
3
6 23 6
1
1

YES
YES
YES
NO
YES
YES
YES
YES
YES
YES

6
3
1 2 3
4
1 2 3 3
3
1 1 1 2 3
1
1
2
1 1
3
1 5 5
*/
