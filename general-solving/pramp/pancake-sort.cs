/***************************************************************************
* Title : Pancake Sort
* URL   : https://www.pramp.com/challenge/3QnxW6xoPLTNl5jX5LM1
* Date  : 2018-04-23
* Author: Atiq Rahman
* Comp  : O(N^2)
* Status: Accepted
* Notes : Implement flip; use flip to implement pancakeSort method
*   ref: https://en.wikipedia.org/wiki/Pancake_sorting
* 
*   Initial version done during interview with Elenor on 23rd (solved on 24th)
*   after interview with Masum on pramp
* meta  : tag-algo-sort, tag-judge-pramp, tag-easy
***************************************************************************/
using System;

class Solution {
  public static int GetMaxIndex(int[] A, int limit) {
    int maxIndex = 0;
    for (int i=1; i<limit; i++)
    if (A[maxIndex] < A[i])
      maxIndex = i;
    return maxIndex;
  }
  
  public static int[] PancakeSort(int[] arr)
  {
    for (int k=arr.Length; k > 1; k--) {
    int maxIndex = GetMaxIndex(arr, k);
    if (maxIndex < k - 1) {
      flip(arr, maxIndex+1);
      flip(arr, k);
    }
    }
    return arr;
  }
    
  public static int[] flip(int[] arr, int k)
  {
    // reverse first k items
    for (int i=0,j=k-1; i<j; i++, j--) {
    int temp = arr[i];
    arr[i] = arr[j];
    arr[j] = temp;
    }
    return arr;
  }
}

/*
Draft:
two flips each time

Considering Example 1,
[3, 2, 1]
k = 3
index of max = 0
 flip(0,3)
which gives us
 [1, 2, 3]
k = 2
index of max = 1
in correct position (when position is k-1) so do nothing
k = 1
index of max = 0
in correct position so do nothing

Considering Example 2,
[1, 5, 4, 3, 2]
k = 5
max's index = 1
flip(0, 2) gives us
[5, 1, 4, 3, 2]
flip(0, k) gives us
[2, 3, 4, 1, 5]
k = 4
now max's index = 2
flip(0,3) gives us,
[4, 3, 2 1, 5]
flip(0, k)
[1, 2, 3, 4, 5]
k = 3
next max's position = 2
k = 1; exit
*/
