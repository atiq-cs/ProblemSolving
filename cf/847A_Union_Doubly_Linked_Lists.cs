/***************************************************************************
* Title : Union of Doubly Linked Lists
* URL   : http://codeforces.com/problemset/problem/847/A
* Contst: 2017-2018 ACM-ICPC NEERC, Southern Subregional Contest, qualification
* Date  : 2018-04-22
* Author: Atiq Rahman
* Comp  : O(N)
* Status: Accepted
* Notes : This is not really a good problem for practicing implementation of
*   doubly linked list. Building LinkedList is not trivial since nodes are out
*   of order.. we can say this place for practicing alternative doubly linked
*   list representation.

*   Pragmatically, I use a representation similar to the input. To do this we
*   use an array of nodes which can be accessed by index and have properties,
*   previous and next.
*   First thought that came to mind is to find groups from the input. Each
*   group represents a list. Then, it looks like only having the list of heads
*   for a group suffices.
*   
*   Observations,
*   - nodes having 0 as previous are heads
*   - nodes having 0 as next are tails
*   
*   Since the order of joining the lists doesn't matter we can start with each
*   list and reach to tail. Every time we reach tail we update the next of tail
*   and previous for next head.
* meta  : tag-linked-list, tag-easy
***************************************************************************/
using System;
using System.Collections.Generic;

public class DoublyLLUtil {
  internal class Node {
    public int prev;
    public int next;
    public int index;   // makes access to this property easier in UnionLists
    public Node(int p, int n, int i) {
      prev = p;
      next = n;
      index = i;
    }
  }

  private int N;
  private List<Node> headList;
  private Node[] nodes;

  public void UnionLists()
  {
    if (N == 0)
      return;
    // One less because we do not need to do anything for the last List
    for (int i = 0; i < headList.Count-1; i++) {
      Node tail = GetTail(headList[i]);
      tail.next = headList[i + 1].index;
      headList[i + 1].prev = tail.index;
    }
  }

  private Node GetTail(Node head)
  {
    Node current = head;
    while (current.next != -1)
      current = nodes[current.next];
    return current;
  }

  // O(N), build list of heads as well
  public void Input()
  {
    N = int.Parse(Console.ReadLine());
    nodes = new Node[N];
    headList = new List<Node>();

    for (int i = 0; i < N; i++) {
      string[] tokens = Console.ReadLine().Split();
      nodes[i] = new Node(int.Parse(tokens[0]) - 1, int.Parse(tokens[1])-1, i);
      if (nodes[i].prev == -1)
        headList.Add(nodes[i]);
    }
  }

  public void Output()
  {
    foreach (Node node in nodes)
      Console.WriteLine("{0} {1}", node.prev + 1, node.next + 1);
  }
}

public class CFSolution {
  public static void Main() {
    DoublyLLUtil doublyLLDemo = new DoublyLLUtil();
    doublyLLDemo.Input();
    doublyLLDemo.UnionLists();
    doublyLLDemo.Output();
  }
}
