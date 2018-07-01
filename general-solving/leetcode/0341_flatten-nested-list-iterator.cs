/***************************************************************************
* Problem Name: Flatten Nested List Iterator
* Problem URL : https://leetcode.com/problems/flatten-nested-list-iterator
* Date        : Feb 4 2017
* Complexity  : O(n) Time
* Author      : Atiq Rahman
* Status      : Accepted
* Notes       : All we have to do is properly use the interface provided
*   Not a binary tree related problem at all;
*    for example, "Flatten Binary Tree to Linked List"
* meta        : tag-easy, tag-data-structure
***************************************************************************/
public class NestedIterator {
  List<int> fNumList;
  int index = 0;
  public NestedIterator(IList<NestedInteger> nestedList) {
    fNumList = new List<int>();
    FlattenRec(nestedList);
  }

  private void FlattenRec(IList<NestedInteger> nList) {
    for (int i=0; i< nList.Count; i++) {
      if (nList[i].IsInteger())
        fNumList.Add(nList[i].GetInteger());
      else
        FlattenRec(nList[i].GetList());
    }
  }

  public bool HasNext() {
    return index < fNumList.Count;
  }

  public int Next() {
    return fNumList[index++];
  }
}

/*
 * Your NestedIterator will be called like this:
 * NestedIterator i = new NestedIterator(nestedList);
 * while (i.HasNext()) v[f()] = i.Next();
 */
