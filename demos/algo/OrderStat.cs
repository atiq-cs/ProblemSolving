/***************************************************************************
* Title : Algorithms/Median and Order Statistics
* URL   : 
* Date  : 2018-06
* Author: Atiq Rahman
* Notes : Tested with leetcode
***************************************************************************/
public class OrderStat {
  private int[] A;
  bool shouldGetIndex;

  // can return index instead of the item based on shouldGetIndex
  private int RandomizedSelet(int p, int r, int i) {
    if (p == r)
      return shouldGetIndex ? p : A[p];
    int q = RandomizedPartition(p, r);
    int k_i = q - p + 1;
    if (i == k_i)
      return shouldGetIndex ? q : A[q];
    else if (i < k_i)
      return RandomizedSelet(p, q-1, i);
    else
      return RandomizedSelet(q + 1, r, i - k_i);
  }

  private int RandomizedPartition(int p, int r) {
    Random rnd = new Random();
    int i = rnd.Next(p, r+1);
    Swap(i, r);
    return Partition(p, r);
  }

  // simple quick sort partition - C.L.R.S, p171
  private int Partition(int p, int r) {
    int i = p-1;
    long x = A[r];
    for (int j=p; j<r; j++) {
      /*
       * maintains invariant that all items are less than pivot are in the
       * block of i (or smaller elements till where i ends)
       */
      if (A[j] <= x) {
        i++;
        Swap(i, j);
      }
    }
    Swap(i+1, r);
    return i + 1;
  }

  private void Swap(int i, int j) {
    if (i != j) {
      int temp = A[i];
      A[i] = A[j];
      A[j] = temp;
    }
  }
}
