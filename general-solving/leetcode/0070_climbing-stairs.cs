/***************************************************************************
* Problem Name: Climbing Stairs
* Problem URL : https://leetcode.com/problems/climbing-stairs/
* Date        : Oct 23 2015
* Complexity  : O(n) Time, O(1) space
* Author      : Atiq Rahman
* Status      : Accepted (beat 85%)
* Notes       : Will modify solution to use O(n) space when there will be
*   large number of queries
* Rel         : https://www.hackerrank.com/challenges/ctci-fibonacci-numbers
* meta        : tag-dynamic-programming, tag-easy
***************************************************************************/
public class Solution {
  public int ClimbStairs(int n) {
    int fibA = 0, fibB = 1;
    for (int i=0; i<n; i++) {
        int temp = fibB; fibB += fibA; fibA = temp;
    }
    return n<1?fibA:fibB;
  }
}

/*  Mental sketch:
    n = 1 {1}
    nw = 1

    n = 2 {1, 2}, {2}
    nw = 2

    n = 3 {1, 2, 3}, {2, 3}, {1, 3}
    nw = 3

    n = 4  {1, 2, 3, 4}, {2, 3, 4}, {2, 4}, {1, 3, 4}, {1, 2, 4}
    nw = 5

    n = 5  {1, 2, 3, 4, 5}, {1, 3, 4, 5}, {1, 3, 5}, {2, 3, 4, 5}, {2, 4, 5}, {2, 3, 5}, {1, 2, 4, 5}, {1, 2, 3, 5}
    nw = 8
*/
