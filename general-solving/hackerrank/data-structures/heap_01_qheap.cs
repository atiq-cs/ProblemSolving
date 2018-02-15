/***************************************************************************
* Title       : QHEAP1
* URL         : https://www.hackerrank.com/challenges/qheap1
* Date        : Sep 11 2017
* Complexity  : Insert Item O(log n)
*               Delete Item O(n) + O(log n) = O(n)
*               Print Minimum O(1)
*               Extract Min O(log n)
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : 
*               1. For this easy hackerrank problem I would assume for delete
*               they are happy with a linear look up.
*               As per, https://stackoverflow.com/q/13337162
*               Lookup can be implemented to be in constant time by maintaining
*               additional data structure
*               2. Too easy test cases; don't depend on it
*               
*               'hackerrank/CCI/DataStructure/008_find-the-running-median.cs'
*               implements an abstract class to derive min and max heap
*               
*               Finally, 'codeforces/681C_HeapOperations.cs' is probably an
*               updated version for Heap implementation.
* Ref         : https://courses.csail.mit.edu/6.006/fall10/handouts/
*               recitation10-8.pdf (max heap though)
* meta        : tag-heap, tag-easy
***************************************************************************/
using System;
using System.Collections.Generic;

class MinHeap {
  List<int> Arr;
  int Size;
  public MinHeap() {
    Arr = new List<int>(); Size = 0;
  }

  private int GetParent(int i) { return (i - 1) / 2; }
  private int GetLeftChild(int i) { return 2*i + 1; }
  private int GetRightChild(int i) { return 2*i + 2; }

  public void Insert(int item) {
    if (Size < Arr.Count)
      Arr[Size] = item;
    else
      Arr.Add(item);
    int  i = Size++;
    // Similar to Decrease Key
    while (i > 0 && Arr[GetParent(i)] > Arr[i]) {
      Swap(i, GetParent(i));
      i = GetParent(i);
    }
  }

  public void Heapify(int i) {
    int l = GetLeftChild(i);
    int r = GetRightChild(i);
    int smallest = i;
    if (l < Size && Arr[l] < Arr[smallest])
      smallest = l;
    if (r< Size && Arr[r] < Arr[smallest])
      smallest = r;
    if (smallest != i) {
      Swap(smallest, i);
      Heapify(smallest);
    }
  }

  public int ExtractMin() {
    int max = Arr[0];
    Arr[0] = Arr[--Size];
    Heapify(0);
    return max;
  }

  // A naive implementation
  // Complexity: O(n)
  public void DeleteItem(int item) {
    int i = 0;
    for (; i < Size; i++)
      if (Arr[i] == item)
        break;
    Arr[i] = Arr[--Size];
    Heapify(i);
  }

  public int PrintMin() { return Size>0? Arr[0]:-1; }

  public void Swap(int i, int j) {
    int tmp = Arr[i];
    Arr[i] = Arr[j];
    Arr[j] = tmp;
  }
}

class Solution {
  static void Main(String[] args) {
    MinHeap min_heap = new MinHeap();
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      switch (tokens[0]) {
        case "1":  // insert
          min_heap.Insert(int.Parse(tokens[1]));
          break;
        case "2":  // delete
          min_heap.DeleteItem(int.Parse(tokens[1]));
          break;
        case "3":  // print minimum
          Console.WriteLine(min_heap.PrintMin());
          break;
        default: // should not be here
          break;
      }      
    }
  }
}
