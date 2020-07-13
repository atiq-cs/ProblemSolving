/***************************************************************************************************
* Title : Queues: A Tale of Two Stacks
* URL   : https://www.hackerrank.com/challenges/ctci-queue-using-two-stacks
* Date  : 2017-09-07
* Comp  : O(n), O(1)
* Author: Atiq Rahman
* Status: Accepted
* Notes :
* meta  : tag-linked-list, tag-easy
***************************************************************************************************/
using System;
using System.Collections.Generic;

class MyQueue {
  private Stack<int> myStack1;
  private Stack<int> myStack2;
  
  // initialize stack objects
  public MyQueue() {
    myStack1 = new Stack<int>();  // acts like stack
    myStack2 = new Stack<int>();  // make it act a like reverse stack
  }
  
  // Time complexity: Θ(1)
  public void Enqueue(int item) {
    myStack1.Push(item); 
  }
  
  // Time complexity: O(n)
  private void Epilogue() {
    if (myStack2.Count > 0)
      return;
    // pop items from first stack till it becomes empty
    while (myStack1.Count > 0)
      myStack2.Push(myStack1.Pop());
  }

  // Time complexity: O(n) due to Epilogue
  public int Dequeue() {
    if (myStack1.Count == 0 && myStack2.Count == 0)
      return -1;
    Epilogue();
    return myStack2.Pop();
  }

  // Time complexity: O(n) due to Epilogue
  public int Peek() {  // peek into myStack2
    if (myStack1.Count == 0 && myStack2.Count == 0)
      return -1;
    Epilogue();
    return myStack2.Peek();
  }
}

class Solution {
  static void Main(String[] args) {
    MyQueue queue = new MyQueue();
    int T = int.Parse(Console.ReadLine());
    while (T-- > 0) {
      string[] tokens = Console.ReadLine().Split();
      switch (tokens[0]) {
        case "1":  // enqueue
          queue.Enqueue(int.Parse(tokens[1]));
          break;
        case "2":  // dequeue
          queue.Dequeue();
          break;
        case "3":  // display
          Console.WriteLine(queue.Peek());
          break;
        default: // should not be here
          break;
      }      
    }
  }
}
