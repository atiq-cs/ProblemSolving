/***************************************************************************
* Title : GCD Variation
* URL   : Amazon Autometa Kindle Author/Editing SDE2 amcat
* Date  : 2019-01-05
* Author: Atiq Rahman
* Comp  : O(n lg n) probably if it takes lg N to compute GCD for 2 numbers
* Status: Accepted
* Notes : Implement GCD for a bunch of given numbers
* meta  : tag-math, tag-recursion tag-company-amazon
***************************************************************************/

// Amazon's default documentation style
public class GCD {
  public int generalizedGCD(int num, int[] A) {
    int result = 0;
    for (int i = 1; i < A.Length; i++) {
      if (result == 1)
        return result;
      result = GCDRec(A[i - 1], A[i]);
    }
    return result;
  }

  private int GCDRec(int a, int b) {
    if (b == 0)
      return a;
    return GCDRec(b, a % b);
  }
}
