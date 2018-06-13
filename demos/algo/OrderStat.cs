/***************************************************************************
* Title : Algorithms/Median and Order Statistics
* URL   : 
* Date  : 2018-06
* Author: Atiq Rahman
* Notes : RandomizedSelet modifies input array and put all items <= pivot to
*   left side. Therefore this method can also be used to return k largest items
***************************************************************************/
public class OrderStat {
  private int[] A;
  bool shouldGetIndex;

  private bool AreIndicesValid(int p, int r) {
    if (p >= r)
      return false;
    return p>=0;
  }

  // can return index instead of the item based on shouldGetIndex
  // preceded by AreIndicesValid() call
  private int RandomizedSelet(int p, int r, int k) {
    if (p == r)
      return shouldGetIndex ? p : A[p];
    // Index of q in original input array
    int q = RandomizedPartition(p, r);
    // relative rank of q based on current array
    int _q = q - p + 1;
    if (k == _q)
      return shouldGetIndex ? q : A[q];
    else if (k < _q)
      return RandomizedSelet(p, q-1, k);
    else
      return RandomizedSelet(q+1, r, k-_q);
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
    for (int j=p; j<r; j++)
      // maintains invariant that all items are less than pivot are in the
      // block of i (or smaller elements till where i ends)
      if (A[j] <= x)
        Swap(++i, j);
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
