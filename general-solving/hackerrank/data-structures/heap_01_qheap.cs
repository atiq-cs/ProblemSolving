/***************************************************************************************************
* Title : QHEAP1
* URL   : https://www.hackerrank.com/challenges/qheap1
* Date  : 2017-09-11
* Author: Atiq Rahman
* Status: Accepted
* Notes : 
*   1. For this easy hackerrank problem I would assume for delete
*   they are happy with a linear look up.
*   As per, https://stackoverflow.com/q/13337162
*   Lookup can be implemented to be in constant time by maintaining
*   additional data structure
*   2. Too easy test cases; don't depend on it
*   
*   'hackerrank/CCI/DataStructure/008_find-the-running-median.cs'
*   implements an abstract class to derive min and max heap
*   
*   Finally, 'codeforces/681C_HeapOperations.cs' is probably an
*   updated version for Heap implementation.
* ref   : https://courses.csail.mit.edu/6.006/fall10/handouts/
*   recitation10-8.pdf (max heap though)
* meta  : tag-heap, tag-easy
***************************************************************************************************/
// MinHeap is at 'ds/Heap.cs'
class Solution {
  static void Main(String[] args) {
    MinHeap minHp = new Heap((a, b) => { return a < b; });
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      switch (tokens[0]) {
        case "1":  // insert
          minHp.Insert(int.Parse(tokens[1]));
          break;
        case "2":  // delete
          minHp.DeleteItem(int.Parse(tokens[1]));
          break;
        case "3":  // print minimum
          Console.WriteLine(minHp.GetMin());
          break;
        default: // should not be here
          break;
      }      
    }
  }
}
