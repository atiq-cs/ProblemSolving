/***************************************************************************
* Title : Cell Complete based on neighbors
* URL   : Amazon Autometa Kindle Author/Editing SDE2 amcat
* Date  : 2019-01-05
* Author: Atiq Rahman
* Comp  : O(n lg n), O(X); n = size of input, X = size of output
* Status: Accepted
* Notes : Given a grid of 1 and 0s change all bits comparing adjacent from left
*   and right side.
*   If, left side is 1 and right side is 0 then the cell becoms 1.
*   (1 - 0) => 1
*   (0 - 1) => 1
*   (0 - 0) => 0
*   (1 - 1) => 0
*   This apparently is X-OR
* meta  : tag-bit-manip, tag-company-amazon
***************************************************************************/

// Amazon's crappy default documentation
// IMPORT LIBRARY PACKAGES NEEDED BY YOUR PROGRAM
// SOME CLASSES WITHIN A PACKAGE MAY BE RESTRICTED
// DEFINE ANY CLASS AND METHOD NEEDED
// CLASS BEGINS, THIS CLASS IS REQUIRED
public class Solution {
  // METHOD SIGNATURE BEGINS, THIS METHOD IS REQUIRED
  public int[] cellCompete(int[] states, int days) {
    for (int j = 0; j < days; j++) {
      int pre = 0;

      for (int i = 0; i < states.Length - 1; i++) {
        int temp = states[i];
        // overwrite here was really fucking it up!!
        states[i] = pre ^ states[i + 1];
        pre = temp;
      }

      states[states.Length - 1] = pre ^ 0;
    }
    return states;
  }
  // METHOD SIGNATURE ENDS
}
